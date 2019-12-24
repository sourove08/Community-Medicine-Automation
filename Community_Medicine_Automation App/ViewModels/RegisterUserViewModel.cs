using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Community_Medicine_Automation_App.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Location { set; get; }
        public string RoleId { set; get; }
    }
}