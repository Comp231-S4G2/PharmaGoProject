#region Namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace ThirdPartyHelper.Model
{
    /// <summary>
    /// Model for Mail Helper
    /// </summary>
    public class SendEmailModel
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public List<string> ReceiverEmails { get; set; }

        [Required]
        public string HtmlBody { get; set; }

        [Required]
        public string MailFrom { get; set; }

        [Required]
        public string Credential { get; set; }

        [Required]
        public string HostIP { get; set; }

        [Required]
        public int PortNumber { get; set; }
    }
}
