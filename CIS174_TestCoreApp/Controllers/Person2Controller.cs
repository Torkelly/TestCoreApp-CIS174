using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Person2Controller : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new CreatePerson2ViewModel
            { 
            
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePerson2ViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }
    }
}