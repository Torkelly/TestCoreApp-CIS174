using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new StudentModel
            {
                
            };

            return View(viewModel);
        }

        public IActionResult List()
        {
            return View("Views/Student/List.cshtml");
        }

        [HttpPost]
        public IActionResult Index(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Student");
        }
        
    }
}
