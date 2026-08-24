using JobPortal.Shared.Interfaces.CommandHandler;
using LoginManagement.DTO.Commands;

namespace LoginManagement.Handler.CommandHandler
{
    public class Loginhandler : ICommandHandler<LoginCommand>
    {
        public Task HandleAsync(LoginCommand command)
        {
            
            throw new NotImplementedException();
        }
    }
}
