using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DTO.Command;
using UserManagement.DTO.DTO;
using UserManagement.DTO.Responses;

namespace UserManagement.AggregateRoot.Mapping.Interface
{
    public interface IMapper
    {
        UsersAggregateRoot RequestToEntity(UserRegisterCommand request);
        UserRegisterResponse EntityToResponse(UsersAggregateRoot user);
        UserDTO EntityToDTO(UsersAggregateRoot user);
        Task<UsersAggregateRoot> BindToEntity(UsersAggregateRoot user, UserUpdateCommand request);
    }
}
