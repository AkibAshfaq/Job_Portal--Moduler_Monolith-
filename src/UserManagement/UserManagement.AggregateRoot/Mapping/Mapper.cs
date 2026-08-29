using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.AggregateRoot.Mapping.Interface;
using UserManagement.AggregateRoot.PasswordHasher.Interfaces;
using UserManagement.DTO.Command;
using UserManagement.DTO.DTO;
using UserManagement.DTO.Responses;

namespace UserManagement.AggregateRoot.Mapping
{
    internal class Mapper : IMapper
    {
        private readonly IPasswordHasher _passwordHasher;
        public Mapper(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public UsersAggregateRoot RequestToEntity(UserRegisterCommand request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (!request.UserType.HasValue) throw new ArgumentException("UserType is required", nameof(request.UserType));

            return new UsersAggregateRoot
            {
                FullName = request.FullName.Trim(),
                Email = request.Email.Trim().ToLowerInvariant(),
                PasswordHashed = _passwordHasher.HashPassword(request.Password),
                PhoneNumber = request.PhoneNumber,
                UserType = request.UserType.Value,
                CreatedAt = DateTime.UtcNow,
                AccessFailedCount = 0,
                IsSuspended = false,
                IsDeleted = false
            };
        }

        public UserRegisterResponse EntityToResponse(UsersAggregateRoot user)
        {
            return new UserRegisterResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                CreatedAt = user.CreatedAt
            };
        }

        public UserDTO EntityToDTO(UsersAggregateRoot user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PasswordHashed = user.PasswordHashed,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                AccessFailedCount = user.AccessFailedCount,
                LockoutEnd = user.LockoutEnd,
                IsSuspended = user.IsSuspended,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public Task<UsersAggregateRoot> BindToEntity(UsersAggregateRoot user, UserUpdateCommand request)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                if (request == null) throw new ArgumentNullException(nameof(request));
                user.FullName = request.FullName?.Trim() ?? user.FullName;
                user.Email = request.Email?.Trim().ToLowerInvariant() ?? user.Email;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                if (request.Password == request.ConfirmPassword && !string.IsNullOrEmpty(request.Password))
                {
                    user.PasswordHashed = _passwordHasher.HashPassword(request.Password);
                }
            }
            catch (Exception ex)
            {
                return Task.FromException<UsersAggregateRoot>(ex);
            }
            return Task.FromResult(user);
        }
    }
}
