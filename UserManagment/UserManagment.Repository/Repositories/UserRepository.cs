using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;
using UserManagment.Repository.Context;
using UserManagment.Repository.Repositories.Interfaces;

namespace UserManagment.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PortalDbContext context) : base(context){}

        public User? GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
