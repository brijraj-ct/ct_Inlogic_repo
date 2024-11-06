using Microsoft.AspNetCore.Identity;

namespace User_Registration_Demo.Infrastructure.Models
{
    public class Users : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
    }
}
