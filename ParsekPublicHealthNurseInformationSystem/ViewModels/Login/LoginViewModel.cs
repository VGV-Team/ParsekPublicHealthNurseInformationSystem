using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels.Login
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Vpišite svoje uporabniško ime")]
        public string Email { get; set; }
        [Display(Name = "Geslo")]
        [Required(ErrorMessage = "Vnesite geslo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ViewMessage { get; set; }
    }
}