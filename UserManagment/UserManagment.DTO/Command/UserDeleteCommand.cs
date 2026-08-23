using UserManagment.DTO.Command.Abstractions;

namespace UserManagment.DTO.Command
{
    public class UserDeleteCommand: ICommand
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
