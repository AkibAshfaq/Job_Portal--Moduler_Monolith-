using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;

namespace UserManagment.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUserByEmail(string email);
    }
}
