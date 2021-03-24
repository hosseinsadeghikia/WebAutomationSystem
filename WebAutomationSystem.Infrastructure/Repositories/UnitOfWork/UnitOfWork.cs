using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.ApplicationCore.Entities.Roles;
using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories.Generic;
using WebAutomationSystem.Infrastructure.Repositories.Jobs;
using WebAutomationSystem.Infrastructure.Repositories.Roles;
using WebAutomationSystem.Infrastructure.Repositories.Users;

namespace WebAutomationSystem.Infrastructure.Repositories.UnitOfWork
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

        private IGenericRepository<JobsChart> _jobsChartRepository;
        public IGenericRepository<JobsChart> JobsChartRepository
        {
            get
            {
                if (_jobsChartRepository == null)
                {
                    _jobsChartRepository = new JobsChartRepository(_context);
                }

                return _jobsChartRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
