using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.DbContexts;

namespace WebAutomationSystem.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<ApplicationUsers>
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
