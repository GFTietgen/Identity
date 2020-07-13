using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Identity
{
    public class MyUserDbContext : IdentityDbContext<MyUser>
    {
        public MyUserDbContext(DbContextOptions<MyUserDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Organization>(org =>
            {
                org.ToTable("Organizations");
                org.HasKey(x => x.Id);

                org.HasMany<MyUser>()
                   .WithOne()
                   .HasForeignKey(user => user.OrganizationId)
                   .IsRequired(false);
            });
        }
    }
}
