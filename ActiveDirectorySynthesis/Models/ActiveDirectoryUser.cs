using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.Models
{
    public class ActiveDirectoryUser
    {
        public string? FirstName { get; set; } = null; 
        public string? LastName { get; set;} = null;
        public string? Email { get; set; } = null;
        public string? Login { get; set; } = null;
        public string? TelephoneNumber { get; set; } = null;
        public string? Mobile { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Street { get; set; } = null;
        public string? PostalCode { get; set; } = null;
        public string? Department { get; set;} = null;
        public string? Title { get; set; } = null;
        public string? Manager { get; set; } = null;
    }
}
