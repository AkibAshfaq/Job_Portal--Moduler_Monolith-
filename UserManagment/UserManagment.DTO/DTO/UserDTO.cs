using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.DTO.Enums;

namespace UserManagment.DTO.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
