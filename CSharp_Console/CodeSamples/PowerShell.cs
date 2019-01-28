using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Powershell scripte in C# to collect information regarding KB installation
    /// </summary>

    public class PowerShell
    {
        /// <summary>
        /// Is checking and return a string value if a given KB is installed on the given client
        /// </summary>
        /// <param name="computerName">Computer Name</param>
        /// <param name="KB">Full name on the KB "KB45872"</param>
        /// <returns></returns>
        public string CheckKB(string computerName, string KB)
        {
            string script = string.Format(@"Get-HotFix -Id {0} -ComputerName {1}", KB.ToUpper(), computerName);

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");

            ICollection<PSObject> results = pipeline.Invoke();
            runspace.Close();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results) { if (obj.ToString().Contains(KB)) { return "true"; } }
            return "false";
        }
    }
}
