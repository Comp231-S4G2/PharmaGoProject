using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Admin
{
    public class CreateStoreViewModel
    {
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

        [Required]
        [Display(Name="Pharmacist Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Pharmacist First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Pharmacist Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Pharmacist Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Pharmacist Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Pharmacist ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = " Assistant Pharmacist Name")]
        public string AsstUserName { get; set; }

        [Required]
        [Display(Name = "Assistant Pharmacist First Name")]
        public string AsstFirstName { get; set; }

        [Display(Name = "Assistant Pharmacist Last Name")]
        public string AsstLastName { get; set; }

        [EmailAddress]
        [Display(Name = " Assistant Pharmacist Email")]
        public string AsstEmail { get; set; }

        [Required]
        [Display(Name = " Assistant Pharmacist Password ")]
        public string AsstPassword { get; set; }

        [Compare("AsstPassword")]
        [Display(Name = " Assistant Pharmacist ConfirmPassword")]
        public string AsstConfirmPassword { get; set; }
    }
}
