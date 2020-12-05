using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Common
{
    public class EmailJobHelperViewModel
    {
        public string ReceiverMailId { get; set; }
        public string Subject { get; set; }
        public string HtmlMessage { get; set; }
    }
}
