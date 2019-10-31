using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Entities
{
    public class Accomplishment
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Person ID")]
        public int PersonId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Accomplishment")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Accomplished")]
        [DataType(DataType.Date)]
        public string DateOfAccomplishment { get; set; }
    }
}
