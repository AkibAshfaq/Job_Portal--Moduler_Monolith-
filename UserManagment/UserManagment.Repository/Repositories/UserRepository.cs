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

        public async Task<bool> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await GetByIdWithoutTrackingAsync(u => u.Email == email);
                return user != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
