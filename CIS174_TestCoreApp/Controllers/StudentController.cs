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
            //You can change the id variable here to see the different access levels
            int id = 4;
            if(id <= 2)
            {
                var viewModel = new StudentViewModel
                {
                    Title = "You do not have suffiecient access level to view this data.",
                    Students = new List<string> { }
                };
                return View(viewModel);
            }
            else if(id >= 2 && id <= 8)
            {
                var viewModel = new StudentViewModel
                {
                    Title = "Student Registry",
                    Students = new List<string>
                    {
                        "Harry Potter", "Hermione Granger", "Ronald Weasley", "Draco Malfoy", "Luna Lovegood"
                    }
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new StudentViewModel
                {
                    Title = "Hello, Admin!",
                    Students = new List<string>
                    {
                        "Harry Potter - B", "Hermione Granger - A+", "Ronald Weasley - C", "Draco Malfoy - B-", "Luna Lovegood - A-"
                    }
                };
                return View(viewModel);
            }

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
