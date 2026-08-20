using UserManagment.AggregateRoot.Entities;
using UserManagment.AggregateRoot.PasswordHasher;
using UserManagment.DTO.DTO;
using UserManagment.DTO.UserRequestDTO;

namespace UserManagment.AggregateRoot.Aggregates
{
    public class UserRegisterAggregate
    {
        private readonly PasswordHash _passwordHasher;

        public UserRegisterAggregate(PasswordHash passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public User ToEntity(UserRegisterRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (!request.UserType.HasValue) throw new ArgumentException("UserType is required", nameof(request.UserType));

            return new User
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

        public UserRegisterResponse ToResponse(User user)
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

        public UserDTO ToDTO(User user)
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
    }
}