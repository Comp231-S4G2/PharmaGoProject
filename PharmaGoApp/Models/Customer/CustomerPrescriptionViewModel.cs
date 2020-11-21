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

        [Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Upload Prescription File")]
        [ValidateImage] //This is custom Attribute class, Can be removed
        public IFormFile formFile { get; set; }
    }
}
