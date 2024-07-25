using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.Models
{
    public class ActiveDirectoryComputer
    {
        public string? ComputerName { get; set; } = null;
        public string? OperatingSystem { get; set; } = null;
        public string? OperatingSystemVersion { get; set; } = null;
        public DateOnly? LastLogonTimeStamp { get; set; } = null;

    }
}
