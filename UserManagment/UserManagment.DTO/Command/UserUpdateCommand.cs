using UserManagment.DTO.Command.Abstractions;

namespace UserManagment.DTO.Command
{
    public class UserUpdateCommand: ICommand
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserType { get; set; }

    }
}
