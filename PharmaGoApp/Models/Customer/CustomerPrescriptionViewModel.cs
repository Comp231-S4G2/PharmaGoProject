using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Customer
{
    public class CustomerPrescriptionViewModel
    {
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Please Type Item Name")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Upload File")]
        [ValidateImage] //This is custom Attribute class, Can be removed
        public IFormFile formFile { get; set; }
    }
}
