namespace PharmaGoApp.Models.Constant
{
    /// <summary>
    /// Constant file for Mail
    /// </summary>
    public static class MailConstant
    {
        #region Mail_Subject

        public static string AccountCreatedSubject= "Account Created Successfully";
        public static string AccountDeletionSubject = "Account Deleted Successfully";
        public static string AccountRevokedSubject = "Account Revoked";

        #endregion

        #region HtmlMessage

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

        public static string AccountRevokedMessge(string userName)
        {
            return @"<h2> Hello " + userName + ",</h2> " +
                            "<h2 style='background:red'> Due to improper use your account has been Revoked.</h2>" +
                            "<h2>We are very sorry to loose you out.</h2>";
        }

        #endregion
    }
}
