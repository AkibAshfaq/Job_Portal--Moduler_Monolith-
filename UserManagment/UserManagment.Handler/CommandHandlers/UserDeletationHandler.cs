using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;
using UserManagment.Repository.Repositories.Interfaces;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserDeletationHandler : ICommandHandler<UserDeleteCommand>
    {
        private readonly IUserRepository _userRepo;
        public UserDeletationHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task HandleAsync(UserDeleteCommand command)
        {
            var user = _userRepo.GetUserByEmail(command.Email);
            if (user == null || user.FullName != command.FullName)
                return Task.FromException(new InvalidOperationException("User doesn't exists."));

            _userRepo.Remove(user);
            _userRepo.SaveChangeAsync();
            return Task.CompletedTask;
        }
    }
}
