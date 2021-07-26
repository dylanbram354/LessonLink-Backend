using Microsoft.AspNetCore.Identity;

namespace capstoneBackend.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentEmail { get; set; }
        public string PreferredContact { get; set; }
    }
}
