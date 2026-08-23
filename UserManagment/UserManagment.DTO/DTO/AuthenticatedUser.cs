using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagment.DTO.DTO
{
    public class AuthenticatedUser
    {
        public string? id { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? EyncPassword { get; set; }
    }
}
