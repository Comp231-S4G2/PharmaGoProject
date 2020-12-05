#region Namespaces

using PharmaGoApp.Models.Common;
using System;
using ThirdPartyHelper;
using ThirdPartyHelper.Model;

#endregion

namespace PharmaGoApp.Helper
{
    /// <summary>
    /// help controller action methods to fire mail
    /// </summary>
    public class EmailJobHelper
    {
        /// <summary>
        /// method is responsible to populate Send Email View Model
        /// and then trigger the mail
        /// </summary>
        /// <param name="mailViewModel">Email Job Helper ViewModel</param>
        /// <returns></returns>
        public static bool SendMailHelper(EmailJobHelperViewModel mailViewModel)
        {
            try
            {
                //popullating data
                var sendMailJob = new SendEmailModel()
                {
                    MailFrom = "gopharmaappcontact@gmail.com",
                    PortNumber = 587,
                    HostIP = "smtp.gmail.com",
                    Subject = mailViewModel.Subject,
                    HtmlBody = mailViewModel.HtmlMessage,
                    Credential = "Harsimran@1996",
                    ReceiverEmails = new System.Collections.Generic.List<string>() { mailViewModel.ReceiverMailId }
                };

                //triggering mail
                MailJobs.SendEmail(sendMailJob);
                return true;
            }
            catch(Exception ex)
            {
                //in case of exception return false;
                return false;
            }
        }
    }
}
