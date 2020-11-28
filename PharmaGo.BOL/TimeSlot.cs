using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaGo.BOL
{
    public class TimeSlot
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime ScheduleStartTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime ScheduleEndTime { get; set; }
        public Pharmacy Pharmacy { get; set; }

        [ForeignKey("Pharmacy")]
        public long PharmacyId { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
