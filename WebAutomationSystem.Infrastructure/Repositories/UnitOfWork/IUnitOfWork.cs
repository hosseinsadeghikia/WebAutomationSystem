using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.ApplicationCore.Entities.Roles;
using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Infrastructure.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<ApplicationUsers> UsersRepository { get; }
        IGenericRepository<ApplicationRoles> RolesRepository { get; }
        IGenericRepository<JobsChart> JobsChartRepository { get; }
        void SaveChanges();
    }
}
