using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagment.DTO.UserRequestDTO
{
    public class UserRegisterRequest
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserType { get; set; }
    }
}
