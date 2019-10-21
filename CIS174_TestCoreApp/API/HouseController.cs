using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.API
{
    [Route("API/house")]
    [ApiController]
    public class HouseController : Controller
    {
        IEnumerable<HouseViewModel> Houses = new List<HouseViewModel>()
        {
            new HouseViewModel() 
            {
                Id = 1, Bedrooms = 4, 
                SquareFeet = 1854, 
                DateBuilt = DateTime.Parse("05/28/1973"), 
                Flooring = "Carpet"
            },
            new HouseViewModel() 
            {
                Id = 2, Bedrooms = 3, 
                SquareFeet = 1675, 
                DateBuilt = DateTime.Parse("10/17/2015"), 
                Flooring = "Hardwood"
            }
        };

        [HttpGet("")]
        public IActionResult GetHouses()
        {
            return Ok(Houses);
        }

        [HttpGet("{id}")]
        [Produces("application/xml")]
        public IActionResult GetHouse(int id)
        {
            if (id >= 1 && id <= Houses.Count())
            {
                return Ok(Houses.ElementAt(id - 1));
            }
            return NotFound();
        }

        [HttpPost("create")]
        public IActionResult CreateHouse(HouseViewModel obj)
        {
            Houses = Houses.Append(obj);
            return StatusCode(201, Houses);
        }
    }
}