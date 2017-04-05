using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class AdminConsoleViewModel
    {

        [Display(Name = "Tip zaposlenega")]
        [Required]
        public Models.Employee.JobTitle JobTitle;
        [Display(Name = "Ime")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Priimek")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Šifra")]
        [Required]
        public string Number { get; set; }
        [Display(Name = "Izvajalec dejavnosti")] // sifra
        [Required]
        public List<Models.Contractor> Contractors { get; set; }
        [Display(Name = "Telefonska številka")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required(ErrorMessage = "Email ni popoln!")]
        public string Email { get; set; }
        [Display(Name = "Geslo")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Geslo ponovno")]
        [Required]
        public string PasswordRepeat { get; set; }


        [Display(Name = "Okoliš")]
        public List<Models.District> Districts { get; set; }

        public int SelectedDistrictId { get; set; }
        public int SelectedContractorId { get; set; }

    }
}