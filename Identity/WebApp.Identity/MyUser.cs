using Microsoft.AspNetCore.Identity;

namespace WebApp.Identity
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Member { get; set; } = "Member";
        public string OrganizationId { get; set; }
    }
}
