using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Pharmacy
{
    public class AddSlotViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Time")]
        public DateTime ScheduleTime { get; set; }
    }
}
