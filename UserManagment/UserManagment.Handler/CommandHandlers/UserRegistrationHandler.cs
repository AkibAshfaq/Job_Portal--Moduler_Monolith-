
using UserManagment.AggregateRoot.Aggregates;
using UserManagment.AggregateRoot.Aggregates.Interfaces;
using UserManagment.DTO.Command;
using UserManagment.DTO.Responses;
using UserManagment.Handler.Abstractions;
using UserManagment.Repository.Repositories;
using UserManagment.Repository.Repositories.Interfaces;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserRegistrationHandler : ICommandHandler<UserRegisterCommand>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserRegisterAggregate _userAgg;

        public UserRegistrationHandler(IUserRepository userRepo, IUserRegisterAggregate userAgg)
        {
            _userRepo = userRepo;
            _userAgg = userAgg;
        }

        public async Task HandleAsync(UserRegisterCommand request)
        {
            try
            {
                var user = _userRepo.GetUserByEmail(request.Email);
                if (user != null) throw new InvalidOperationException("User with this email already exists.");

                var newUser = _userAgg.ToEntity(request);

                await _userRepo.AddAsync(newUser);
                
                await _userRepo.SaveChangeAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"User registration failed: {ex.Message}");
            }
        }
    }
}
