using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.Interfaces
{
    public interface IActiveDirectoryGroupOperations
    {
        public bool CheckUserGroupMembership(string domain, string groupName, string userName);
        public IEnumerable<Principal> GetGroupMembers(string domain, string groupName);
        public void AddUserToGroup(string domain, string groupName, string userName);
        public void RemoveUserFromGroup(string domain, string groupName, string userName);
    }
}
