using ActiveDirectorySynthesis.Interfaces;
using ActiveDirectorySynthesis.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynthesis.ServiceImplementation
{
    public class ActiveDirectoryImporterUserService : IUserActiveDirectoryImporter<ActiveDirectoryUser>
    {
        public virtual ActiveDirectoryUser FindUserFromGivenLDAPPath(string ldap, string userName)
        {
            DirectoryEntry directoryEntry = new DirectoryEntry(ldap);
            directoryEntry.AuthenticationType = AuthenticationTypes.Secure;

            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                PageSize = 10000,
                Filter = $"(&(objectClass=User)(cn={userName}))"

            };
            var results = directorySearcher.FindOne();

            return ModelDirectorySearcherResults(results);

        }

        public virtual IEnumerable<ActiveDirectoryUser> FindUsersFromGivenLDAPPath(string ldap)
        {
            List<ActiveDirectoryUser> activeDirectoryUsers = new List<ActiveDirectoryUser>();
            DirectoryEntry directoryEntry = new DirectoryEntry(ldap);
            directoryEntry.AuthenticationType = AuthenticationTypes.Secure;

            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                PageSize = 10000,
                Filter = "(&(objectClass=User)(cn=*))"

            };
            var results = directorySearcher.FindAll();

            foreach (SearchResult entry in results)
            {
                activeDirectoryUsers.Add(ModelDirectorySearcherResults(entry));
            }

            return activeDirectoryUsers;
        }

        //To review, there might be a better implementation idea
        private ActiveDirectoryUser ModelDirectorySearcherResults(SearchResult searchResult)
        {

            ActiveDirectoryUser activeDirectoryUser = new();

            if (searchResult != null)
            {
                try
                {
                    activeDirectoryUser.FirstName = searchResult?.Properties["givenName"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.FirstName = string.Empty;
                }
                try
                {
                    activeDirectoryUser.LastName = searchResult?.Properties["cn"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.LastName = string.Empty;
                }

                try
                {
                    activeDirectoryUser.Email = searchResult?.Properties["mail"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Email = string.Empty;
                }

                try
                {
                    activeDirectoryUser.Login = searchResult?.Properties["sAMAccountName"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Login = string.Empty;
                }

                try
                {
                    activeDirectoryUser.TelephoneNumber = searchResult?.Properties["telephoneNumber"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.TelephoneNumber = string.Empty;
                }

                try
                {
                    activeDirectoryUser.Mobile = searchResult?.Properties["mobile"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Mobile = string.Empty;
                }
                try
                {
                    activeDirectoryUser.Country = searchResult?.Properties["co"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Country = string.Empty;
                }
                try
                {
                    activeDirectoryUser.City = searchResult?.Properties["l"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.City = string.Empty;
                }
                try
                {
                    activeDirectoryUser.Street = searchResult?.Properties["street"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Street = string.Empty;
                }
                try
                {
                    activeDirectoryUser.PostalCode = searchResult?.Properties["postalCode"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.PostalCode = string.Empty;
                }
                try
                {
                    activeDirectoryUser.Department = searchResult?.Properties["department"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Department = string.Empty;
                }
                try
                {
                    activeDirectoryUser.Title = searchResult?.Properties["title"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Title = string.Empty;
                }
                try
                {
                    activeDirectoryUser.Manager = searchResult?.Properties["manager"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryUser.Manager = string.Empty;
                }
            }

            return activeDirectoryUser;
        }
    }
}
