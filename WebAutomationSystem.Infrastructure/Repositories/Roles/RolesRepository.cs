using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Infrastructure.Repositories.Roles
{
    public class RolesRepository : GenericRepository<ApplicationRoles>
    {
        public RolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
