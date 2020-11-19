using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Admin
{
    public class StoreViewModel
    {
        public long PharmacyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
    }
}
