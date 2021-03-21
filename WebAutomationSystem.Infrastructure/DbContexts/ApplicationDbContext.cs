using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAutomationSystem.ApplicationCore.Entities.Roles;
using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.FluentConfig.FluentEntities;

namespace WebAutomationSystem.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, int>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API Configurations goes in here
            modelBuilder.ApplyConfiguration(new FluentApplicationUser());
        }
    }
}
