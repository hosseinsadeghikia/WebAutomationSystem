using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAutomationSystem.Infrastructure.Entities;

namespace WebAutomationSystem.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers,ApplicationRoles,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // To Change Table Name and Property Name for Identity
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<ApplicationUsers>(entity =>
        //    {
        //        entity.ToTable(name: "YourTableName");
        //        entity.Property(u => u.Id).HasColumnName("UserId");
        //    });
        //}
    }
}
