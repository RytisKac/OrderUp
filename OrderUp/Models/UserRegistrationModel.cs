using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class UserRegistrationModel
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Elektroninis paštas privalomas")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Slaptažodis privalomas")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
