using Microsoft.AspNetCore.Identity;

namespace CIS174_TestCoreApp.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
