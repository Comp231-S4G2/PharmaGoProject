using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Pharmacy
{
    public class UpdateStockMedicineViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Medicine Name")]
        public string MedName { get; set; }

        public long MedId { get; set; }

        [Range(1, 65000)]
        [Required]
        public int Quantity { get; set; }
    }
}
