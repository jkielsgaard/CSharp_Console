using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Send mail through exchange server 
    /// </summary>

    public class Mail
    {
        /// <summary>
        /// Send mail function
        /// </summary>
        /// <param name="toMail"></param>
        /// <param name="ccMail"></param>
        public void SendMail(string toMail, string ccMail, string exchangeServer, string domain)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(toMail));
            if (ccMail != "Null Value") { msg.CC.Add(new MailAddress(ccMail)); }
            msg.From = new MailAddress("[MAIL]");
            msg.Subject = "";
            msg.IsBodyHtml = true;

            // Mail //
            msg.Body = "";

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("", "", domain);
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = exchangeServer;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(msg);
        }
    }
}
