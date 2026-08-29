using BCrypt.Net;
using UserManagement.AggregateRoot.PasswordHasher.Interfaces;


namespace UserManagement.AggregateRoot.PasswordHasher
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
