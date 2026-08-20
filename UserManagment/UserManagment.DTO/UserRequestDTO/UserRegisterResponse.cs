using UserManagment.DTO.Enums;

namespace UserManagment.DTO.UserRequestDTO
{
    public class UserRegisterResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
