using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Active Directory functions
    /// </summary>

    public class ActiveDirectory
    {
        /// <summary>
        /// Return a TRUE or FALSE if the user is in the specific AD groupe
        /// </summary>
        /// <param name="Username">Username on user to lookup and see if exist in the AD group</param>
        /// <returns></returns>
        public bool MembershipCheck(string Username)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "[DOMAIN]");
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, "[ADGROUP]");

            if (grp != null)
            {
                foreach (Principal p in grp.GetMembers(true))
                {
                    string ADMembers = p.ToString().ToUpper();
                    if (ADMembers == Username) { return true; }
                }
                grp.Dispose();
                ctx.Dispose();
            }
            return false;
        }

        /// <summary>
        /// Search for computer information on AD
        /// </summary>
        /// <param name="computerName"></param>
        public void Search(string computerName)
        {

            string strPath = "LDAP://[DOMAIN]";
            DirectoryEntry entry = new DirectoryEntry(strPath);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            TimeSpan waitTime = new TimeSpan(0, 0, 30); //LET THIS TIME OUT 1 SECOND BEFORE OUR TIMEOUT
            mySearcher.ClientTimeout = waitTime; //wait this much time to display results 

            mySearcher.Filter = "(&(objectCategory=computer)(name=" + computerName + "))";
            mySearcher.PropertiesToLoad.Add("manageby");

            //mySearcher.PropertiesToLoad.Add("CN");
            //mySearcher.PropertiesToLoad.Add("givenname"); // firstname
            //mySearcher.PropertiesToLoad.Add("sn"); // lastname
            //mySearcher.PropertiesToLoad.Add("mail"); // mail  

            foreach (SearchResult result in mySearcher.FindAll())
            {
                string AD_User = "";

                DirectoryEntry Dir_Entry = result.GetDirectoryEntry();
                if (Dir_Entry.Name != null) AD_User = Dir_Entry.Name.Remove(0, 3);

                if (Dir_Entry.Properties["manageby"].Value != null) AD_User = Dir_Entry.Properties["manageby"].Value.ToString();

                //if (Dir_Entry.Properties["CN"].Value != null) Computer = Dir_Entry.Properties["CN"].Value.ToString();
                //if (Dir_Entry.Properties["givenname"].Value != null) First_Name = Dir_Entry.Properties["givenname"].Value.ToString();
                //if (Dir_Entry.Properties["sn"].Value != null) Last_Name = Dir_Entry.Properties["sn"].Value.ToString();
                //if (Dir_Entry.Properties["mail"].Value != null) mail = Dir_Entry.Properties["mail"].Value.ToString();

                Console.WriteLine(AD_User);
                Console.ReadLine();
            }
        }
    }
}
