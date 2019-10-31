using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp
{
    public class PersonContext : DbContext
    {
        public PersonContext (DbContextOptions<PersonContext> options)
            : base (options)
        {

        }

        readonly PersonContext _context;

        public int CreatePerson(CreatePersonCommand cpc)
        {
            var person = new Person
            {
                FirstName = cpc.FirstName,
                LastName = cpc.LastName,
                BirthDate = cpc.BirthDate,
                City = cpc.City,
                State = cpc.State,
                Accomplishments = cpc.Accomplishments?.Select(i =>
                    new Accomplishment
                    {
                        Name = i.Name,
                        DateOfAccomplishment = i.DateOfAccomplishment,
                    }).ToList()
            };
            _context.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public DbSet<Accomplishment> Accomplishments { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=tcp:cis174week10.database.windows.net,1433;Initial Catalog=Week10;Persist Security Info=False;User ID=tlkelly;Password=Password!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


    }
}
