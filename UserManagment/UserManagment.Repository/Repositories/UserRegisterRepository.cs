using UserManagment.AggregateRoot.Entities;
using UserManagment.Repository.Context;


namespace UserManagment.Repository.Repositories
{
    public class UserRegisterRepository
    {
        private readonly PortalDbContext _context;
        public UserRegisterRepository(PortalDbContext context)
        {
            _context = context;
        }
        
        public bool RegisterUserSync(User user)
        {
            try
            {
                _context.Users.Add(user);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SaveChangeAsync()
        {
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
