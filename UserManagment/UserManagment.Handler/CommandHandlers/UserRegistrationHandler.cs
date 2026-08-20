
using UserManagment.AggregateRoot;
using UserManagment.AggregateRoot.Aggregates;
using UserManagment.DTO.UserRequestDTO;
using UserManagment.Repository.Repositories;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserRegistrationHandler
    {
        private readonly GetUserByMailRepository _getUserByMailRepository;
        private readonly UserRegisterRepository _userRegisterRepository;
        private readonly UserRegisterAggregate _UserRegisterAggregator;

        public UserRegistrationHandler(GetUserByMailRepository getUserByMailRepository, UserRegisterRepository userRegisterRepository, UserRegisterAggregate userRegisterAggregator)
        {
            _getUserByMailRepository = getUserByMailRepository;
            _userRegisterRepository = userRegisterRepository;
            _UserRegisterAggregator = userRegisterAggregator;
        }

        public UserRegisterResponse RegisterUserAsync(UserRegisterRequest request)
        {
            try
            {
                var user = _getUserByMailRepository.GetUserByEmailAsync(request.Email);
                if (user) throw new InvalidOperationException("User with this email already exists.");

                var newUser = _UserRegisterAggregator.ToEntity(request);

                var createdUser = _userRegisterRepository.RegisterUserSync(newUser);
                
                if(createdUser) _userRegisterRepository.SaveChangeAsync();
                else throw new InvalidOperationException("Failed to save the new user to the database.");

                return _UserRegisterAggregator.ToResponse(newUser);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"User registration failed: {ex.Message}");
            }
        }
    }
}
