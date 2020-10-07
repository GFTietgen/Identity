using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebAPI.Domiain
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> userRoles { get; set; }
    }
}
