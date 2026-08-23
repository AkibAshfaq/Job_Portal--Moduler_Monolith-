using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagment.AggregateRoot.PasswordHasher.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string providedPassword, string hashedPassword);
    }
}
