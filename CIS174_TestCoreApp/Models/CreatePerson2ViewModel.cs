using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIS174_TestCoreApp.Models
{
    public class CreatePerson2ViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Maximum of 25 characters")]
        [Display(Name = "Your Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Must be between 2-25 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Country { get; set; }

        public IEnumerable<SelectListItem> Countries = new List<SelectListItem>
        {
            new SelectListItem{Value = "", Text="Please select country"},
            new SelectListItem{Value = "Canada", Text="Canada"},
            new SelectListItem{Value = "Mexico", Text="Mexico"},
            new SelectListItem{Value = "United States", Text="United States"}
        };
    }
}
