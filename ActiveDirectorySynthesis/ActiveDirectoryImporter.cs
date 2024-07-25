using ActiveDirectorySynthesis.Interfaces;
using ActiveDirectorySynthesis.Models;
using System.DirectoryServices;
using System.Runtime.CompilerServices;

namespace ActiveDirectorySynthesis
{
    public class ActiveDirectoryImporter<T> where T : class
    {
        private readonly string _ldap;
        private readonly IUserActiveDirectoryImporter<T> _userActiveDirectoryImporter;
        private readonly IComputerActiveDirectoryImporter<T> _computerActiveDirectoryImporter;

        public ActiveDirectoryImporter(string ldap, IUserActiveDirectoryImporter<T> userActiveDirectoryImporter)
        {
            _ldap = ldap;
            _userActiveDirectoryImporter = userActiveDirectoryImporter;
        }

        public ActiveDirectoryImporter(string ldap, IComputerActiveDirectoryImporter<T> computerActiveDirectoryImporter)
        {
            _ldap = ldap;
            _computerActiveDirectoryImporter = computerActiveDirectoryImporter;
        }


        public T RetrieveSpecificUser(string user)
        {
            return _userActiveDirectoryImporter.FindUserFromGivenLDAPPath(_ldap, user);
        }

        public IEnumerable<T> RetrieveAlldDUsers()
        {
            return _userActiveDirectoryImporter.FindUsersFromGivenLDAPPath(_ldap);
        }

        public T RetrieveSpecificComputer(string computer)
        {
            return _computerActiveDirectoryImporter.FindComputerFromGivenLDAPPath(_ldap, computer);
        }

        public IEnumerable<T> RetrieveAdDComputers()
        {
            return _computerActiveDirectoryImporter.FindComputersFromGivenLDAPPath(_ldap);
        }
    }
}
