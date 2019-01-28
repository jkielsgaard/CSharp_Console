using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// WMI (Windows Management Instrumentation) 
    /// </summary>

    public class WMI_Process
    {
        /// <summary>
        /// The main RunWMI process for other function in this class
        /// </summary>
        /// <param name="process">process ID/Name</param>
        /// <param name="computerName">Computer Name</param>
        private void RunWMI(object[] process, string computerName)
        {
            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;
            connection.EnablePrivileges = true;
            ManagementScope wmiScope = new ManagementScope(string.Format("\\\\{0}\\root\\cimv2", computerName), connection);
            wmiScope.Connect();
            ManagementClass wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
            wmiProcess.InvokeMethod("Create", process);
        }

        /// <summary>
        /// Run a fil on remote computer 
        /// </summary>
        /// <param name="computerName">Computer Name</param>
        /// <param name="filePath">Path to CMD file that need to be run</param>
        /// <returns>Will return then the task is done</returns>
        public string runCMD(string computerName, string filePath)
        {
            try
            {
                object[] process = new[] { @"cmd /c " + filePath };

                RunWMI(process, computerName);
            }
            catch (Exception ex) { return ex.Message.ToString(); }
            return "";
        }

        /// <summary>
        /// Run a fil on remote computer 
        /// </summary>
        /// <param name="computerName">Computer Name</param>
        /// <param name="filePath">Path to EXE file that need to be run</param>
        /// <returns>Will return then the task is done</returns>
        public string runEXE(string computerName, string filePath)
        {
            try
            {
                object[] process = new[] { @"C:\" + filePath };
                RunWMI(process, computerName);
            }
            catch (Exception ex) { return ex.Message.ToString(); }
            return "";
        }
    }
}
