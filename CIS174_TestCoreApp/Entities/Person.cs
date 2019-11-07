using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Entities
{
    public class Person
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Maximum of 25 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Must be between 2-25 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "Must be between 2-25 characters")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Must be an abbreviation of a state. (Ex. CA, MI, IA")]
        [Display(Name = "State")]
        public string State { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Accomplishment> Accomplishments { get; set; }
    }
}
