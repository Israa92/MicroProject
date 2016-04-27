using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MikroProject.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Enter a user name")]
        public string LoginName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }
    }
}
