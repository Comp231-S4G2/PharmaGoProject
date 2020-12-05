#region Namespaces

using System;
using System.Net;
using System.Net.Mail;
using ThirdPartyHelper.Model;

#endregion

namespace ThirdPartyHelper
{
    /// <summary>
    /// Helper class to send mail
    /// </summary>
    public class MailJobs
    {
        /// <summary>
        /// Method is responsible to trigger mail
        /// </summary>
        /// <param name="sendMail">Send Email Model </param>
        public static void SendEmail(SendEmailModel sendMail)
        {
            try
            {
                //validate the data
                if (IsSendEmailModelValid(sendMail))
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress(sendMail.MailFrom);

                    //iterate through loop for each recipients
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
                    //trigrring mail
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            {
                //logging error on console
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// method is responsible to validate the data before triggering mail
        /// </summary>
        /// <param name="sendMail">Send Email View Model</param>
        /// <returns></returns>
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
