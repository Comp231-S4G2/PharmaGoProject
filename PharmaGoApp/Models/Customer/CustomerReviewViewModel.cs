using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Customer
{
    public class CustomerReviewViewModel
    {
        [Required]
        [Display(Name = "Flu Shot Services")]
        [Range(0,5)]
        public int FluShotServices { get; set; }

        [Required]
        [Display(Name = "Application Performance")]
        [Range(0, 5)]
        public int ApplicationPerformance { get; set; }

        [Required]
        [Display(Name = "Technical Assistance Response")]
        [Range(0, 5)]
        public int TechnicalAssistanceResponse { get; set; }

        [Required]
        [Display(Name = "Over All Review")]
        [Range(0, 5)]
        public int OverallReview { get; set; }
    }
}
