using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.Interfaces
{
    public interface IComputerActiveDirectoryImporter<T> where T : class
    {
        public T FindComputerFromGivenLDAPPath(string ldap, string computerName);

        public IEnumerable<T> FindComputersFromGivenLDAPPath(string ldap);
    }
}
