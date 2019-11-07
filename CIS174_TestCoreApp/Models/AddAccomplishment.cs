using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class AddAccomplishmentBase
    {
        [StringLength(150)]
        public string Name { get; set; }

        public DateTime DateOfAccomplishment { get; set; }
    }
}
