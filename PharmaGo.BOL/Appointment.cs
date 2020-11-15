using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BOL
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime ApptTime { get; set; }
        public string CustomerId { get; set; }
        public long StoreId { get; set; }

        public GPAUser Customer { get; set; }
        public Pharmacy Store { get; set; }
    }
}
