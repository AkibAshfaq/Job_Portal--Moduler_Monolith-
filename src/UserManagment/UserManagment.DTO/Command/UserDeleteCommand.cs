using JobPortal.Shared.Interfaces.Command;

namespace UserManagement.DTO.Command
{
    public class UserDeleteCommand: ICommand
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
