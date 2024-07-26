using ActiveDirectorySynthesis.Interfaces;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.ServiceImplementation
{
    public class ActiveDirectoryGroupOperationsImplementation : IActiveDirectoryGroupOperations
    {
        public bool CheckUserGroupMembership(string domain, string groupName, string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(ctx, userName);
            GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName);

            if (userPrincipal.IsMemberOf(groupPrincipal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Principal> GetGroupMembers(string domain, string groupName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);
            GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName);

            return groupPrincipal.GetMembers().ToList();
        }


        public void AddUserToGroup(string domain, string groupName, string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(ctx, userName);
            GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName);

            groupPrincipal.Members.Add(userPrincipal);
        }

        public void RemoveUserFromGroup(string domain, string groupName, string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(ctx, userName);
            GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName);

            groupPrincipal.Members.Remove(userPrincipal);
        }
    }
}
