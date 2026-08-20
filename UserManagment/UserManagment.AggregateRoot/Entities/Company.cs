using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagment.AggregateRoot.Entities
{
    public class Company
    {
        public string? CompanyName { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? Industry { get; set; }
        public string? CompanyAddress { get; set; }
        public string? LogUrl { get; set; }
        public string? Description { get; set; }
    }
}
