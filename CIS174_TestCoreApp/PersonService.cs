using CIS174_TestCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp
{
    public class PersonService
    {
        readonly PersonContext _context;

        public PersonService(PersonContext context)
        {
            _context = context;
        }

        public ICollection<PersonSummary> GetPeople()
        {
            return _context.People
                .Select(p => new PersonSummary
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                })
                .ToList();
        }

        public PersonDetails GetPersonDetails(int id)
        {
            return _context.People
                .Where(x => x.Id == id)
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

        public int CreatePerson(CreatePersonCommand cpc)
        {
            var person = cpc.ToPerson();
            _context.Add(person);
            _context.SaveChanges();
            return person.Id;
        }


        public void UpdatePerson(UpdatePersonCommand cpc)
        {
            var person = _context.People.Find(cpc.Id);
            if (person == null) { throw new Exception("Unable to update"); }

            cpc.UpdatePerson(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.People.Find(id);

            _context.SaveChanges();
        }
    }
}
