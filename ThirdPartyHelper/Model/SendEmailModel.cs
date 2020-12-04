using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ThirdPartyHelper.Model
{
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
