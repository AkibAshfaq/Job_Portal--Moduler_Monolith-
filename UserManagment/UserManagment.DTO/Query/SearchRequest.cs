using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.DTO.Query.Abstractions;

namespace UserManagment.DTO.Query
{
    public class SearchRequest : IQuery
    {
        public string? SearchTerm { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
