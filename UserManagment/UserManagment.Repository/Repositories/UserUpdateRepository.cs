using TestProject.DAL.Context;
using UserManagment.AggregateRoot.Entities;

namespace UserManagment.Repository.Repositories
{
    public class UserUpdateRepository
    {
        private readonly PortalDbContext _context; 
        public UserUpdateRepository(PortalDbContext context)
        {
            _context = context;
        }

        public Task UpdateUserSync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public Task SaveChangeAsync()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
