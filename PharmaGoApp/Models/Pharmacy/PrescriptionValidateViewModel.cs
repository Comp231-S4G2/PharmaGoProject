using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Pharmacy
{
    public class PrescriptionValidateViewModel
    {
        public string FilePath { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public long PrescriptionId { get; set; }
    }
}
