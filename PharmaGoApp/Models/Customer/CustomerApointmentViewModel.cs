using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Customer
{
    public class CustomerApointmentViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name ="Patient Name")]
        public string PatientName { get; set; }
        public string Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime ScheduleTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime ScheduleEndTime { get; set; }

        public long StoreId { get; set; }
        public string StoreName { get; set; }

    }
}
