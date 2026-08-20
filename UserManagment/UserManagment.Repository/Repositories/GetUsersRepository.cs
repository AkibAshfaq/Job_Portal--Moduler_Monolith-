using Microsoft.EntityFrameworkCore;
using UserManagment.AggregateRoot.Entities;
using UserManagment.Repository.Context;

namespace UserManagment.Repository.Repositories
{
    public class GetUsersRepository
    {
        private readonly PortalDbContext _context;

        private readonly DbSet<User> _dbset;
        public GetUsersRepository(PortalDbContext context)
        {
            _context = context;
            _dbset = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var users = await _dbset.ToListAsync();
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
