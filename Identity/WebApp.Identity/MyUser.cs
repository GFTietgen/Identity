using Microsoft.AspNetCore.Identity;

namespace WebApp.Identity
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }
        public string OrganizationId { get; set; }
    }
}
