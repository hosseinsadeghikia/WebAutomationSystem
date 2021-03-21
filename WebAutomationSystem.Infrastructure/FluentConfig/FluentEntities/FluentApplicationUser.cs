using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAutomationSystem.ApplicationCore.Entities.Users;

namespace WebAutomationSystem.Infrastructure.FluentConfig.FluentEntities
{
    public class FluentApplicationUser : IEntityTypeConfiguration<ApplicationUsers>
    {
        public void Configure(EntityTypeBuilder<ApplicationUsers> modelBuilder)
        {
            modelBuilder.Property(u => u.FirstName).HasMaxLength(256);
            modelBuilder.Property(u => u.LastName).HasMaxLength(256);
            modelBuilder.Property(u => u.PersonalCode).HasMaxLength(10);
            modelBuilder.Property(u => u.NationalCode).HasMaxLength(10);
            modelBuilder.Property(u => u.BirthDate).HasMaxLength(20);
        }
    }
}
