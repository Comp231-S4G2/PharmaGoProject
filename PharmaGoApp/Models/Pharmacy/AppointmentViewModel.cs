using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Pharmacy
{
    public class AppointmentViewModel
    {
        public long Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string TimeSlot { get; set; }

        public string AppointmentDate { get; set; }
    }
}
