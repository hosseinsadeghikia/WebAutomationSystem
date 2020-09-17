using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.Repositories;

namespace WebAutomationSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<ApplicationUsers> UsersRepository { get; }
        IGenericRepository<ApplicationRoles> RolesRepository { get; }
        void SaveChanges();
    }
}
