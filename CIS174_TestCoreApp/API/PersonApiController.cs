using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CIS174_TestCoreApp.API
{
    [Route("api/person")]
    [FeatureEnabled(IsEnabled = true)]
    [ValidateModel]
    [HandleException]
    [ApiController]

    public class PersonApiController : ControllerBase
    {
        public readonly PersonService _personService;
        public readonly PersonContext _context;

        public PersonApiController(PersonService personService)
        {
            _personService = personService;
        }

        [AddLastModifiedHeader]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var detail = _personService.GetPersonDetails(id);
            return Ok(detail);
        }

        public void UpdatePerson(int id, UpdatePersonCommand command)
        {
            var person = _context.People.Find(id);

            if (person == null)
            {
                throw new Exception("Unable to find person");
            }

            person.FirstName = command.FirstName;
            person.LastName = command.LastName;
            person.BirthDate = command.BirthDate;
            person.City = command.City;
            person.State = command.State;

            _context.SaveChanges();
        }
    }
}