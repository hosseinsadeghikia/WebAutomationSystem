using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.ApplicationCore.Entities.Users;

namespace WebAutomationSystem.Infrastructure.FluentConfig.FluentEntities
{
    public class FluentJobsChart : IEntityTypeConfiguration<JobsChart>
    {
        public void Configure(EntityTypeBuilder<JobsChart> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.Property(u => u.Name).HasMaxLength(256);
            modelBuilder.Property(u => u.Description).HasMaxLength(512);
        }
    }
}
