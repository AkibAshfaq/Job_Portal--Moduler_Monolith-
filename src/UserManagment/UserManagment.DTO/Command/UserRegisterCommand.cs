using JobPortal.Shared.Interfaces.Command;
using UserManagement.DTO.Enums;

namespace UserManagement.DTO.Command
{
    public class UserRegisterCommand : ICommand
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
    }
}
