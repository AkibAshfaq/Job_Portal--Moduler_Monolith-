using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DAL.Context;
using UserManagment.AggregateRoot.Entities;

namespace UserManagment.Repository.Repositories
{
    public class GetUserByMailRepository
    {
        private readonly PortalDbContext _context;
        private readonly DbSet<User> _dbset;
        public GetUserByMailRepository(PortalDbContext context)
        {
            _context = context;
            _dbset = _context.Set<User>();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbset.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
