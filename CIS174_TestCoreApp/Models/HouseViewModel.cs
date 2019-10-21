using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class HouseViewModel
    {
        [Required]
        [Range(1, 100)]
        public uint Id { get; set; }

        [Required]
        [Range(1, 10)]
        public uint Bedrooms { get; set; }

        [Required]
        [Range(100, 10000)]
        public uint SquareFeet { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateBuilt { get; set; }

        [Required]
        public String Flooring { get; set; }
    }
}
