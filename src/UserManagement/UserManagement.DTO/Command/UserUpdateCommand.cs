using JobPortal.Shared.Interfaces.Command;

namespace UserManagement.DTO.Command
{
    public class UserUpdateCommand: ICommand
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
