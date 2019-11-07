
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Entities;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Person3Controller : Controller
    {
        private readonly PersonService _service;
        private readonly UserManager<ApplicationUser> _userService;
        private readonly IAuthorizationService _authService;

        public Person3Controller(
            PersonService service,
            UserManager<ApplicationUser> userService,
            IAuthorizationService authService)
        {
            _service = service;
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var models = _service.GetPeople();

            return View(models);
        }

        [Authorize]
        public IActionResult Accomplishments()
        {
            var model = _service.GetAccomplishments();

            return View(model);
        }

        public IActionResult View(int id)
        {
            var model = _service.GetPersonDetails(id);

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View(new CreatePersonCommand());
        }

        [HttpPost, Authorize]
        public IActionResult Create(CreatePersonCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _service.CreatePerson(command);
                    return RedirectToAction(nameof(View), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the person"
                    );
            }
            return View(command);
        }

        [Authorize]
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
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdatePerson(command);
                    return RedirectToAction(nameof(View), new { id = command.Id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the person"
                    );
            }

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