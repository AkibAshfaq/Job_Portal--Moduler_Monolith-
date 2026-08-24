using JobPortal.Shared.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DTO.Query
{
    public class SearchRequest : IQuery
    {
        public string? SearchTerm { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
