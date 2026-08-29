using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Repository.Context;
using UserManagement.Repository.Repositories.Interfaces;
using UserManagement.AggregateRoot;

namespace UserManagement.Repository.Repositories
{
    internal class UserRepository : GenericRepository<UsersAggregateRoot>, IUserRepository
    {
        public UserRepository(PortalDbUserContext context) : base(context){}

        public UsersAggregateRoot? GetUserByEmail(string email)
        {

            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

    }
}
