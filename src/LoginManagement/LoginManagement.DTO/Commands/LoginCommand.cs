using JobPortal.Shared.Interfaces.Command;

namespace LoginManagement.DTO.Commands
{
    public class LoginCommand: ICommand
    {
        public string username { get; set; }
        public string password { get; set; }

    }
}
