using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories;

namespace WebAutomationSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IGenericRepository<ApplicationUsers> _userRepository;
        public IGenericRepository<ApplicationUsers> UsersRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UsersRepository(_context);
                }

                return _userRepository;
            }
        }

        private IGenericRepository<ApplicationRoles> _roleRepository;
        public IGenericRepository<ApplicationRoles> RolesRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RolesRepository(_context);
                }

                return _roleRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
