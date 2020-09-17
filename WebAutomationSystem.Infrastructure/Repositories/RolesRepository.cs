using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.DbContexts;

namespace WebAutomationSystem.Infrastructure.Repositories
{
    public class RolesRepository : GenericRepository<ApplicationRoles>
    {
        public RolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
