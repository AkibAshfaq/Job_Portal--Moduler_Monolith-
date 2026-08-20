using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Context;
using UserManagment.AggregateRoot.Entities;

namespace UserManagment.Repository.Repositories
{
    public class UserRegisterRepository
    {
        private readonly PortalDbContext _context;
        public UserRegisterRepository(PortalDbContext context)
        {
            _context = context;
        }

        public Task RegisterUserSync(User user)
        {
            _context.Users.Add(user);
            return Task.CompletedTask;
        }

        public Task SaveChangeAsync()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
