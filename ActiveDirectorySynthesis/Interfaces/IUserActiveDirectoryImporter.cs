using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.Interfaces
{
    public interface IUserActiveDirectoryImporter<T> where T : class
    {
        public T FindUserFromGivenLDAPPath(string ldap, string userName);

        public IEnumerable<T> FindUsersFromGivenLDAPPath(string ldap);

    }
}
