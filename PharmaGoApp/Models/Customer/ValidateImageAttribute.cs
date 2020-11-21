using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Customer
{
    public class ValidateImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 2; //Max 2 MB file
            string[] AllowedFileExtensions = new
            string[] {
                ".jpg",
                ".pdf",
                ".png",
                ".docx"
            };
            var file = value as IFormFile;
            if (file == null)
                return false;
            else if (!AllowedFileExtensions.Contains((file != null) ?
              file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower() :
              string.Empty))
            {
                ErrorMessage = "Please upload Your Photo of type: " +
                 string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (file.Length > MaxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " +
                 (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}
