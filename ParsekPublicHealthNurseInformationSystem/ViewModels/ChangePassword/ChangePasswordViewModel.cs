using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels.ChangePassword
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Novo geslo")]
        [Required(ErrorMessage = "Vnesite novo geslo")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }
        [Display(Name = "Ponovite novo geslo")]
        [Required(ErrorMessage = "Ponovite novo geslo")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        public string ViewMessage { get; set; }
    }
}