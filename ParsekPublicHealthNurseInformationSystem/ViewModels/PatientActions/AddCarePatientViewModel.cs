using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class AddCarePatientViewModel
    {
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Name { get; set; }

        [Display(Name = "Priimek")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Surname { get; set; }

        [Display(Name = "Številka kartice ZZ")]
        public string Number { get; set; }

        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Address { get; set; }

        [Display(Name = "Poštna številka")]
        [Required(ErrorMessage = " ")]
        public List<Models.PostOffice> PostOffices { get; set; }

        [Display(Name = "Okoliš")]
        [Required(ErrorMessage = " ")]
        public List<Models.District> Districts { get; set; }

        [Display(Name = "Telefonska številka")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Datum rojstva")]
        [Required(ErrorMessage = "Polje je obvezno")]
        [DataType(DataType.Date)]
        [CheckDateRangeAttribute(ErrorMessage = "Neustrezen datum")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Spol")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public Models.Patient.GenderEnum? Gender { get; set; }

        [Display(Name = "Sorodstveno razmerje")]
        [Required(ErrorMessage = " ")]
        public List<Models.Relationship> Relationships { get; set; }

        public int SelectedDistrictId { get; set; }
        public int SelectedPostOfficeId { get; set; }
        public int SelectedRelationshipId { get; set; }

        public string ViewMessage { get; set; }

        // READ ONLY
        public List<Models.Patient> CarePatients { get; set; }
        //

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