using UserManagment.DTO.Command;
using UserManagment.Handler.Abstractions;

namespace UserManagment.Handler.CommandHandlers
{
    public class UserDeletationHandler : ICommandHandler<UserDeleteCommand>
    {
        public Task HandleAsync(UserDeleteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
