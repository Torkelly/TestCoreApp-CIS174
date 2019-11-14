
using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp
{
    public class PersonContext : IdentityDbContext<ApplicationUser>
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {

        }

        readonly PersonContext _context;

        public int CreatePerson(CreatePersonCommand cmd)
        {
            var person = new Person
            {
                FirstName = cmd.FirstName,
                LastName = cmd.LastName,
                BirthDate = cmd.BirthDate,
                City = cmd.City,
                State = cmd.State,
                Accomplishments = cmd.Accomplishments?.Select(i =>
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

        public DbSet<Person> People { get; set; }
        public DbSet<Accomplishment> Accomplishments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=tcp:cis174week10.database.windows.net,1433;Initial Catalog=Week10;Persist Security Info=False;User ID=tlkelly;Password=Password!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


    }
}
