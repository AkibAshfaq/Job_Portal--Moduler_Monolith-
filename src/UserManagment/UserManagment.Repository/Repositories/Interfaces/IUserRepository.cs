using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.AggregateRoot;

namespace UserManagement.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<UsersAggregateRoot>
    {
        UsersAggregateRoot? GetUserByEmail(string email);
    }
}
