
using JobPortal.Shared.Exceptions;
using JobPortal.Shared.Interfaces.CommandHandler;
using UserManagement.AggregateRoot;
using UserManagement.AggregateRoot.Mapping.Interface;
using UserManagement.DTO.Command;
using UserManagement.Repository.Repositories.Interfaces;

namespace UserManagement.Handler.CommandHandlers
{
    public class UserRegistrationHandler : ICommandHandler<UserRegisterCommand>
    {
        private readonly IUserRepository _userRepo;
        private readonly UsersAggregateRoot _userAgg;
        private readonly IMapper _mapper;

        public UserRegistrationHandler(IUserRepository userRepo, UsersAggregateRoot userAgg, IMapper mapper)
        {
            _userRepo = userRepo;
            _userAgg = userAgg;
            _mapper = mapper;
        }

        public async Task HandleAsync(UserRegisterCommand request)
        {
            var existing = _userRepo.GetUserByEmail(request.Email);

            if (existing is not null)
                throw new DtoValidationException($"Email '{request.Email}' is already registered.");

            var newUser = _mapper.RequestToEntity(request);

            await _userRepo.AddAsync(newUser);
            await _userRepo.SaveChangeAsync();
        }
    }
}
