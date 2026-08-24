using JobPortal.Shared.Exceptions;
using JobPortal.Shared.Interfaces.CommandHandler;
using UserManagement.DTO.Command;
using UserManagement.Repository.Repositories.Interfaces;

namespace UserManagement.Handler.CommandHandlers
{
    public class UserDeletationHandler : ICommandHandler<UserDeleteCommand>
    {
        private readonly IUserRepository _userRepo;
        public UserDeletationHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task HandleAsync(UserDeleteCommand command)
        {
            var user = _userRepo.GetUserByEmail(command.Email);

            if (user is null || user.FullName != command.FullName)
                throw new NotFoundException($"User '{command.Email}' was not found.");

            _userRepo.Remove(user);
            await _userRepo.SaveChangeAsync();
        }
    }
}
