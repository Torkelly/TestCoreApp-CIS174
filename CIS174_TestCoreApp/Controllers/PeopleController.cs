using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class PeopleController : Controller
    {

        [FeatureEnabled(IsEnabled = true)]

        public PersonService _service;
        public PeopleController(PersonService service)
        {
            _service = service;
        }

        [AddLastModifiedHeader]
        [ValidateModel]
        [HandleException]

        public IActionResult Index()
        {
            var models = _service.GetPeople();

            return View(models);
        }

        public IActionResult View(int id)
        {
            var model = _service.GetPersonDetails(id);

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreatePersonCommand());
        }

        [HttpPost]
        public IActionResult Create(CreatePersonCommand command)
        {
            var id = _service.CreatePerson(command);

            return View(command);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetPersonForUpdate(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdatePersonCommand command)
        {
            _service.UpdatePerson(command);

            return View(command);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeletePerson(id);

            return RedirectToAction(nameof(Index));
        }
    }
}