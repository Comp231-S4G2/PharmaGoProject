using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Constant
{
    public static class MailConstant
    {
        public static string AccountCreatedSubjectSubject = "Account Created Successfully";
        public static string AccountDeletionSubjectSubject = "Account Deleted Successfully";
        public static string AccountCreatedMessge(string userName) 
        {
            return @"<h2> Hello "+ userName + ",</h2> " +
                            "<h2 style='background:green'> Your Account has been created successfully.</h2>" +
                            "<h2>We are very glad to assist you,Now you can use GoPharmaApp</h2>";
        }
        public static string AccountDeletionMessge(string userName)
        {
            return @"<h2> Hello " + userName + ",</h2> " +
                            "<h2 style='background:red'> Your Account has been deleted successfully.</h2>" +
                            "<h2>We are very sorry to loose you out.</h2>";
        }
    }
}
