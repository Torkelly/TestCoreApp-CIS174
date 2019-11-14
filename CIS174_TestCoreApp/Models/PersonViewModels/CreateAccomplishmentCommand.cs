using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class CreateAccomplishmentCommand
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Accomplishment")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Accomplished")]
        [DataType(DataType.Date)]
        public string DateOfAccomplishment { get; set; }

        public Accomplishment MakeAccomplishment()
        {
            return new Accomplishment
            {
                Name = Name,
                DateOfAccomplishment = DateOfAccomplishment,
            };
        }
    }
}
