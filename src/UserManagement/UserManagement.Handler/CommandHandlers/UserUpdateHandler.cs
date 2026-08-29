using JobPortal.Shared.Interfaces.CommandHandler;
using UserManagement.AggregateRoot;
using UserManagement.AggregateRoot.Mapping.Interface;
using UserManagement.DTO.Command;
using UserManagement.Repository.Repositories.Interfaces;

namespace UserManagement.Handler.CommandHandlers
{
    public class UserUpdateHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserUpdateHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task HandleAsync(UserUpdateCommand command)
        {
            var user = _userRepo.GetUserByEmail(command.Email);
            if (user == null && user.FullName != command.FullName)
                throw new InvalidOperationException("User doesn't exists.");

            var newUser= _mapper.BindToEntity(user, command);
            _userRepo.Update(newUser.Result);
            await _userRepo.SaveChangeAsync();
        }
    }
}
