using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Name { get; set; }
        [Display(Name = "Priimek")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Surname { get; set; }
        [Display(Name = "Številka kartice ZZ")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Number { get; set; }
        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Address { get; set; }
        [Display(Name = "Potna številka")]
        [Required(ErrorMessage = " ")]
        public List<Models.PostOffice> PostOffices { get; set; }
        [Display(Name = "Okoliš")]
        [Required(ErrorMessage = " ")]
        public List<Models.District> Districts { get; set; }
        [Display(Name = "Telefonska številka")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Neveljaven E-mail naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Email { get; set; }
        [Display(Name = "Datum rojstva")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [DataType(DataType.Date)]
        [CheckDateRangeAttribute(ErrorMessage = "Neustrezen datum")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Spol")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public Models.Patient.GenderEnum? Gender { get; set; }
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

        [Display(Name = "Ime")]
        public string ContactName { get; set; }
        [Display(Name = "Priimek")]
        public string ContactSurname { get; set; }
        [Display(Name = "Naslov")]
        public string ContactAddress { get; set; }
        [Display(Name = "Telefonska številka")]
        public string ContactPhone { get; set; }
        [Display(Name = "Razmerje")]
        public string ContactRelationsip { get; set; }


        public int SelectedDistrictId { get; set; }
        public int SelectedPostOfficeId { get; set; }

        public string ViewMessage { get; set; }

        public class CheckDateRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dt = (DateTime)value;
                if (dt <= DateTime.UtcNow && dt >= DateTime.Parse("1/1/1900"))
                {
                    return true;
                }

                return false;
            }

        }
    }
}