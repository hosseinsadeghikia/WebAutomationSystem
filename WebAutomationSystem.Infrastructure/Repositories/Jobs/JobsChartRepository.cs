using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories.Generic;
namespace WebAutomationSystem.Infrastructure.Repositories.Jobs
{
    public class JobsChartRepository : GenericRepository<JobsChart>
    {
        public JobsChartRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
