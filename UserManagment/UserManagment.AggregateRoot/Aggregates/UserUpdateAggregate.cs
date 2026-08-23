using UserManagment.AggregateRoot.Aggregates.Interfaces;
using UserManagment.AggregateRoot.Entities;
using UserManagment.AggregateRoot.PasswordHasher.Interfaces;
using UserManagment.DTO.Command;


namespace UserManagment.AggregateRoot.Aggregates
{
    public class UserUpdateAggregate : IUserUpdateAggregate
    {
        private readonly IPasswordHasher _passwordHasher;
        public UserUpdateAggregate(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public Task<User> BindToEntity(User user, UserUpdateCommand request)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                if (request == null) throw new ArgumentNullException(nameof(request));
                user.FullName = request.FullName?.Trim() ?? user.FullName;
                user.Email = request.Email?.Trim().ToLowerInvariant() ?? user.Email;
                user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
                if(request.Password == request.ConfirmPassword && !string.IsNullOrEmpty(request.Password))
                {
                    user.PasswordHashed = _passwordHasher.HashPassword(request.Password);
                }
            }
            catch (Exception ex)
            {
                return Task.FromException<User>(ex);
            }
            return Task.FromResult(user);
        }
    }
}