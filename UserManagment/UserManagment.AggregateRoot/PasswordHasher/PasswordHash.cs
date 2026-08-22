using BCrypt.Net;
using UserManagment.AggregateRoot.PasswordHasher.Interfaces;


namespace UserManagment.AggregateRoot.PasswordHasher
{
    public class PasswordHash : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
    }
}
