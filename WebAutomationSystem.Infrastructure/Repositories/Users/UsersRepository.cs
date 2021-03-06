﻿using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Infrastructure.Repositories.Users
{
    public class UsersRepository : GenericRepository<ApplicationUsers>
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
