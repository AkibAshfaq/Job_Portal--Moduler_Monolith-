using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.UserRequestDTO;

namespace UserManagment.AggregateRoot.Aggregates
{
    public class UserUpdateAggregate
    {
        public UserUpdateAggregate() { }

        
        public User ChangeToUpdateEntity(UserUpdateRequest request)
        {
            User user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserType= Enum.Parse<UserType>("JobSeeker"),
                Company = new Company()
                {
                    CompanyName = request.Company.CompanyName,
                    CompanyWebsite = request.Company.CompanyWebsite,
                    Industry = request.Company.Industry,
                    CompanyAddress = request.Company.CompanyAddress,
                    LogUrl = request.Company.LogUrl,
                    Description = request.Company.Description
                } ?? null
            };
            return user;
        }
    }
}