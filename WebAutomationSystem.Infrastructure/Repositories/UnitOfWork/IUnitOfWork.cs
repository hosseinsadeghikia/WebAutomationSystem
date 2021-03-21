using WebAutomationSystem.ApplicationCore.Entities.Roles;
using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<ApplicationUsers> UsersRepository { get; }
        IGenericRepository<ApplicationRoles> RolesRepository { get; }
        void SaveChanges();
    }
}
