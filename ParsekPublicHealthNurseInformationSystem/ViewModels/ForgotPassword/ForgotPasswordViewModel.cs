using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class ForgotPasswordViewModel
    {

        [Required(ErrorMessage = "Vnesite email s katerim ste se registritali")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Novo geslo")]
        [Required(ErrorMessage = "Vnesite novo geslo")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Novo geslo (ponovno)")]
        [Required(ErrorMessage = "Ponovno vnesite novo geslo")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Gesli se ne ujemata!")]
        public string PasswordRepeat { get; set; }

        public string ViewMessage { get; set; }

    }
}