using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// To create process in windows, both local and remote
    /// </summary>

    public class WinProcess
    {
        /// <summary>
        /// Is the main core to start the new process after a given desire
        /// </summary>
        /// <param name="_FileName">Full filename and path</param>
        /// <param name="_Arguments">Arguments need to the file</param>
        /// <param name="_Hide">TRUE if it shelle hide the process or FALSE if not</param>
        private void SimpleProcess(string _FileName, string _Arguments, bool _Hide)
        {
            Process process = new Process();
            ProcessStartInfo Info = new ProcessStartInfo
            {
                FileName = _FileName,
                Arguments = _Arguments,
            };
            if (_Hide) { Info.WindowStyle = ProcessWindowStyle.Hidden; }

            process.StartInfo = Info;
            process.Start();
        }

        /// <summary>
        /// Is the main core to start the new process after a given desire
        /// </summary>
        /// <param name="_fileName">Full filename and path</param>
        /// <param name="_arguments">Arguments need to the file</param>
        /// <param name="_domain"></param>
        /// <param name="_userName"></param>
        /// <param name="_passsWord"></param>
        /// <param name="_hide">TRUE if it shelle hide the process or FALSE if not</param>
        private void AdvProcess(string _fileName, string _arguments, string _domain, string _userName, SecureString _passsWord, bool _hide)
        {
            Process process = new Process();
            ProcessStartInfo Info = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                FileName = "shutdown.exe",
                Verb = "runas",
                UserName = _userName,
                Domain = _domain,
                Password = _passsWord,
                Arguments = _arguments
            };
            if (_hide) { Info.WindowStyle = ProcessWindowStyle.Hidden; }

            process.StartInfo = Info;
            process.Start();
        }


        public void RemoteReboot(string userName, string domain, SecureString passsWord)
        {
            AdvProcess("shutdown.exe", "-m \\\\[COMPUTERNANE] -r -f  -t 60", domain,  userName, passsWord, true);
        }


        public void RemoteConnectDrive(string ComputerName, string AdminUsername, SecureString AdminPasssword)
        {
            SimpleProcess("explorer.exe", @"file://[COMPUTERNANE]\C$\", false);
        }
    }
}
