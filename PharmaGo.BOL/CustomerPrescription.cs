using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BOL
{
    public class CustomerPrescription
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public GPAUser user { get; set; }
        public string PrescriptionPath { get; set; }
        public List<MedDemand> MedDemands { get; set; }

    }
}
