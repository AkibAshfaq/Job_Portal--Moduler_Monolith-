using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.DTO;
using UserManagment.DTO.Query;
using UserManagment.Handler.Abstractions;
using UserManagment.Repository.Repositories;
using UserManagment.Repository.Repositories.Interfaces;

namespace UserManagment.Handler.QueryHandler
{
    public class GetUsersHandler: IQueryHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepo;

        public GetUsersHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> HandleAsync(GetUsersQuery query)
        {
            try
            {
                var users = await _userRepo.GetAllAsync();
                return users;
            }
            catch (Exception)
            {
                throw new InvalidDataException("An error occurred while retrieving users.");
            }

        }

    }
}
