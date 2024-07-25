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
    public class ActiveDirectoryImporterComputerService : IComputerActiveDirectoryImporter<ActiveDirectoryComputer>
    {
        public virtual ActiveDirectoryComputer FindComputerFromGivenLDAPPath(string ldap, string computerName)
        {
            DirectoryEntry directoryEntry = new DirectoryEntry(ldap);
            directoryEntry.AuthenticationType = AuthenticationTypes.Secure;

            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                PageSize = 10000,
                Filter = $"(&(objectClass=Computer)(cn={computerName}))"

            };
            var results = directorySearcher.FindOne();

            return ModelDirectorySearcherResults(results);
        }

        public virtual IEnumerable<ActiveDirectoryComputer> FindComputersFromGivenLDAPPath(string ldap)
        {
            List<ActiveDirectoryComputer> activeDirectoryComputers= new List<ActiveDirectoryComputer>();
            DirectoryEntry directoryEntry = new DirectoryEntry(ldap);
            directoryEntry.AuthenticationType = AuthenticationTypes.Secure;

            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                PageSize = 10000,
                Filter = "(&(objectClass=Computer)(cn=*))"

            };
            var results = directorySearcher.FindAll();

            foreach (SearchResult entry in results)
            {
                activeDirectoryComputers.Add(ModelDirectorySearcherResults(entry));
            }

            return activeDirectoryComputers;
        }

        //To review, there might be a better implementation idea
        private ActiveDirectoryComputer ModelDirectorySearcherResults(SearchResult searchResult)
        {
            ActiveDirectoryComputer activeDirectoryComputer = new();

            if (searchResult != null)
            {
                try
                {
                    activeDirectoryComputer.ComputerName = searchResult?.Properties["name"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryComputer.ComputerName = string.Empty;
                }

                try
                {
                    activeDirectoryComputer.OperatingSystem = searchResult?.Properties["operatingSystem"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryComputer.OperatingSystem = string.Empty;
                }
                try
                {
                    activeDirectoryComputer.OperatingSystemVersion = searchResult?.Properties["operatingSystemVersion"][0].ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryComputer.OperatingSystemVersion = string.Empty;
                }
                try
                {
                    activeDirectoryComputer.LastLogonTimeStamp = DateOnly.Parse(searchResult?.Properties["lastLogonTimestamp"][0].ToString());
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    activeDirectoryComputer.LastLogonTimeStamp = null;
                }
            }


            return activeDirectoryComputer;
        }

    }
}
