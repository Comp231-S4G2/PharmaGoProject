using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using ThirdPartyHelper.Model;

namespace ThirdPartyHelper
{
    public class MailJobs
    {
        public static void SendEmail(SendEmailModel sendMail)
        {
            try
            {
                if (IsSendEmailModelValid(sendMail))
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress(sendMail.MailFrom);

                    foreach (var receipientMail in sendMail.ReceiverEmails)
                        message.To.Add(new MailAddress(receipientMail));

                    message.Subject = sendMail.Subject;
                    message.IsBodyHtml = true;
                    message.Body = sendMail.HtmlBody;
                    smtp.Port = sendMail.PortNumber;
                    smtp.Host = sendMail.HostIP; //specify  host  or DN:Domain Name
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendMail.MailFrom, sendMail.Credential);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static bool IsSendEmailModelValid(SendEmailModel sendMail)
        {
            try
            {
                if (sendMail.Credential.Trim() != "" && sendMail.HostIP.Trim() != ""
                    && sendMail.HtmlBody.Trim() != "" && sendMail.MailFrom.Trim() != ""
                    && sendMail.PortNumber > 0 && sendMail.ReceiverEmails.Count > 0 && sendMail.Subject.Trim() != "")
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
