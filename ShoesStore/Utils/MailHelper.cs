using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ShoesStore.Utils
{
    public class MailHelper
    {
        public bool ReplySubscribe(string toEmailAdress, string subject, string body)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAdress"].ToString();
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

                bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

                MailMessage message =
                    new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAdress));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                using (var client = new SmtpClient())
                {
                    client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                    client.Host = smtpHost;
                    client.EnableSsl = enableSsl;
                    client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                    client.Send(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}