using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.Command;
using UserManagment.DTO.DTO;
using UserManagment.DTO.Responses;

namespace UserManagment.AggregateRoot.Aggregates.Interfaces
{
    public interface IUserRegisterAggregate
    {
        User ToEntity(UserRegisterCommand request);
        UserRegisterResponse ToResponse(User user);
        UserDTO ToDTO(User user);
    }
}
