using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domiain;

namespace WebAPI.Repository
{
    public class Context : IdentityDbContext<User, 
                                             Role, 
                                             int,
                                             IdentityUserClaim<int>, 
                                             UserRole, 
                                             IdentityUserLogin<int>,
                                             IdentityRoleClaim<int>, 
                                             IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Organization>(org =>
            {
                org.ToTable("Organizations");
                org.HasKey(x => x.Id);

                org.HasMany<User>()
                   .WithOne()
                   .HasForeignKey(user => user.OrgId)
                   .IsRequired(false);
            });

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.userRoles)
                        .HasForeignKey(r => r.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.userRoles)
                        .HasForeignKey(r => r.UserId)
                        .IsRequired();
            });
        }
    }
}
