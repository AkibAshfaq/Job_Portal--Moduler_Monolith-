using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;
using UserManagment.Repository.Repositories;

namespace UserManagment.Handler.QueryHandler
{
    public class GetUsersHandler
    {
        private readonly GetUsersRepository _getUsersRepository;

        public GetUsersHandler(GetUsersRepository getUsersRepository)
        {
            _getUsersRepository = getUsersRepository;
        }

        public async Task<IEnumerable<User>> Handler()
        {
            try
            {
                var users = await _getUsersRepository.GetUsersAsync();
                return users;
            }
            catch (Exception)
            {
                throw new InvalidDataException("An error occurred while retrieving users.");
            }

        }

    }
}
