using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Send Email by local outlook
    /// </summary>

    public class OutlookMail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toMail"></param>
        /// <param name="subject"></param>
        /// <param name="mailMsg"></param>
        private static void Sendmail(string toMail, string subject, string mailMsg)
        {
            // Start outlook if not started
            if (!Process.GetProcessesByName("OUTLOOK").Any()) { Process.Start("OUTLOOK.exe"); }

            // Create and send mail
            Outlook.Application outlookApplication = new Outlook.Application();
            Outlook.MailItem _mail = (Outlook.MailItem)outlookApplication.CreateItem(Outlook.OlItemType.olMailItem);
            _mail.Subject = subject;
            _mail.Display(false);
            _mail.To = toMail;
            _mail.HTMLBody = mailMsg;
            _mail.Send();
        }
    }
}
