using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Control services on local and remote computer
    /// </summary>

    public class ServicesController
    {
        /// <summary>
        /// Restart a services on remote computer
        /// </summary>
        /// <param name="services">Name on services on remote computer</param>
        /// <param name="computerName">Name on remote computer on network</param>
        /// <returns></returns>
        public string RestartServices(string services, string computerName)
        {
            //ServiceController sc = new ServiceController();
            //sc.ServiceName = services;

            try
            {
                ServiceController sc = new ServiceController(services, computerName);
                if (sc.Status == ServiceControllerStatus.Stopped) { sc.Start(); }
                else
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 60));
                    sc.Start();
                }
            }
            catch (Exception ex) { return ex.Message.ToString(); }
            return "";
        }
    }
}
