using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class AdminConsoleViewModel
    {

        [Display(Name = "Tip zaposlenega")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public Models.Employee.JobTitle JobTitle { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Name { get; set; }

        [Display(Name = "Priimek")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Surname { get; set; }

        [Display(Name = "Šifra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
        public string Number { get; set; }

        [Display(Name = "Izvajalec dejavnosti")] // sifra
        [Required(ErrorMessage = " ")]
        public List<Models.Contractor> Contractors { get; set; }

        [Display(Name = "Telefonska številka")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Neveljaven E-mail naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Email { get; set; }

        [Display(Name = "Geslo")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Geslo ponovno")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [MinLength(8, ErrorMessage = "Najmanjše število znakov je 8")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Gesli se ne ujemata!")]
        public string PasswordRepeat { get; set; }


        [Display(Name = "Okoliš")]
        public List<Models.District> Districts { get; set; }

        public int SelectedDistrictId { get; set; }
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedContractorId { get; set; }

        public string ViewMessage { get; set; }

        [Display(Name = "Zaposleni")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public List<Employee> AllEmployees { get; set; }

        [Display(Name = "Izbrani zaposleni")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string EmployeeId { get; set; }

        [Display(Name = "Izvajalec")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Contractor { get; set; }

        [Display(Name = "Okoliš")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string District { get; set; }

        public int Id { get; set; }

    }
}