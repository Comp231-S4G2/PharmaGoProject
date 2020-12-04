using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Admin
{
    public class UsersViewModel
    {
        public string Id { get; set; }

        [Display(Name ="First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }       
    }
}
