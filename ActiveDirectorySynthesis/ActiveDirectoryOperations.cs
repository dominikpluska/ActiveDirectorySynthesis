using ActiveDirectorySynthesis.Interfaces;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis
{
    public class ActiveDirectoryOperations
    {
        private readonly string _domain;
        private readonly string _userName;
        private readonly string _groupName;
        private readonly IActiveDirectoryGroupOperations _activeDirectoryGroupOperations;


        public ActiveDirectoryOperations(string domain, string groupName, IActiveDirectoryGroupOperations  activeDirectoryGroupOperations)
        {
            _domain = domain;
            _groupName = groupName;
        }

        public ActiveDirectoryOperations(string domain, string userName, string groupName)
        {
            _domain = domain;
            _userName = userName;
            _groupName = groupName;
        }

        public bool CheckUserGroupMembership()
        {
            return _activeDirectoryGroupOperations.CheckUserGroupMembership(_domain, _groupName, _userName);
        }


        public IEnumerable<Principal> GetGroupMembers()
        {
            return _activeDirectoryGroupOperations.GetGroupMembers(_domain, _groupName);
        }

        public void AddUserToGroup()
        {
            _activeDirectoryGroupOperations.AddUserToGroup(_domain, _groupName, _userName);
        }

        public void RemoveUserFromGroup()
        {
            _activeDirectoryGroupOperations.RemoveUserFromGroup(_domain, _groupName, _userName);
        }
    }
}
