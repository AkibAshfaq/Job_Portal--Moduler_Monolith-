using UserManagement.DTO.Enums;
using UserManagement.DTO.Responses.Abstractions;

namespace UserManagement.DTO.Responses
{
    public class UserRegisterResponse: IResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
