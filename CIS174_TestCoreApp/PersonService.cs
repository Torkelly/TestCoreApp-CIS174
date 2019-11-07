
using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp
{
    public class PersonService
    {
        readonly PersonContext _context;
        readonly ILogger _logger;
        public PersonService(PersonContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<PersonService>();
        }

        public ICollection<PersonSummary> GetPeople()
        {
            return _context.People
                .Where(p => !p.IsDeleted)
                .Select(p => new PersonSummary
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    NumberOfAccomplishments = p.Accomplishments.Count,
                })
                .ToList();
        }

        public ICollection<AccomplishmentSummary> GetAccomplishments()
        {
            return _context.Accomplishments
                .Select(a => new AccomplishmentSummary
                {
                    PersonId = a.PersonId,
                    Id = a.Id,
                    Name = a.Name,
                    DateOfAccomplishment = a.DateOfAccomplishment,
                })
                .ToList();
        }

        public bool DoesPersonExist(int id)
        {
            return _context.People
                .Where(r => !r.IsDeleted)
                .Where(r => r.Id == id)
                .Any();
        }

        public bool IsNameCorrect(string first, string last)
        {
            return _context.People
                .Where(r => !r.IsDeleted)
                .Where(r => r.FirstName == first)
                .Where(r => r.LastName == last)
                .Any();
        }

        public PersonDetails GetPersonDetails(int id)
        {
            return _context.People
                .Where(x => x.Id == id)
                .Where(x => !x.IsDeleted)
                .Select(x => new PersonDetails
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    City = x.City,
                    State = x.State,
                    Accomplishments = x.Accomplishments
                    .Select(item => new PersonDetails.Item
                    {
                        Name = item.Name,
                        DateOfAccomplishment = item.DateOfAccomplishment
                    })
                })
                .SingleOrDefault();
        }

        public UpdatePersonCommand GetPersonForUpdate(int Id)
        {
            return _context.People
                .Where(x => x.Id == Id)
                .Where(x => !x.IsDeleted)
                .Select(x => new UpdatePersonCommand
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    City = x.City,
                    State = x.State,
                })
                .SingleOrDefault();
        }

        public int CreatePerson(CreatePersonCommand cmd)
        {
            var person = cmd.ToPerson();
            _context.Add(person);
            _context.SaveChanges();
            return person.Id;
        }


        public void UpdatePerson(UpdatePersonCommand cmd)
        {
            var person = _context.People.Find(cmd.Id);
            if (person == null) { throw new Exception("Unable to find the person"); }
            if (person.IsDeleted) { throw new Exception("Unable to update a deleted person"); }

            cmd.UpdatePerson(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.People.Find(id);
            if (person.IsDeleted) { throw new Exception("Unable to delete a deleted person"); }

            person.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}