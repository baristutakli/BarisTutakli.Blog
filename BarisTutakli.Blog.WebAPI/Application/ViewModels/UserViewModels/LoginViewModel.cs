using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarisTutakli.Blog.WebAPI.Application.ViewModels.UserViewModels
{
    [NotMapped]
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
