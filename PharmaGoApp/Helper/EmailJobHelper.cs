using PharmaGoApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyHelper;
using ThirdPartyHelper.Model;

namespace PharmaGoApp.Helper
{
    public class EmailJobHelper
    {
        public static bool SendMailHelper(EmailJobHelperViewModel mailViewModel)
        {
            try
            {
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
                MailJobs.SendEmail(sendMailJob);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
