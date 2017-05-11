using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class ProfileViewModel
    {

        public int PatientId { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Email { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Name { get; set; }

        [Display(Name = "Priimek")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Surname { get; set; }

        [Display(Name = "Številka kartice ZZ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Number { get; set; }

        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string Address { get; set; }

        [Display(Name = "Telefonska številka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
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

        [Display(Name = "Kontaktna oseba")]
        public bool HasContactPerson { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string ContactName { get; set; }

        [Display(Name = "Priimek")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string ContactSurname { get; set; }

        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string ContactAddress { get; set; }

        [Display(Name = "Telefonska številka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string ContactPhone { get; set; }

        [Display(Name = "Okoliš")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedDistrictId { get; set; }

        [Display(Name = "Poštna številka")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedPostOfficeId { get; set; }

        [Display(Name = "Razmerje")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedRelationshipId { get; set; }

        public List<Models.PostOffice> PostOffices { get; set; }
        public List<Models.District> Districts { get; set; }
        public List<Models.Relationship> Relationships { get; set; }

        public string ViewMessage { get; set; }

        public class CheckDateRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null) return true;

                DateTime dt = (DateTime)value;
                if (dt < DateTime.UtcNow)
                {
                    return true;
                }
                return false;
            }
        }


        public List<CarePatientData> CarePatientDatas { get; set; }

        public struct CarePatientData
        {
            public int PatientId { get; set; }

            [Display(Name = "Ime")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public string Name { get; set; }

            [Display(Name = "Priimek")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public string Surname { get; set; }

            [Display(Name = "Številka kartice ZZ")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public string Number { get; set; }

            [Display(Name = "Naslov")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public string Address { get; set; }

            [Display(Name = "Telefonska številka")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "Polje mora vsebovati številko brez presledkov")]
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

            [Display(Name = "Okoliš")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public int SelectedDistrictId { get; set; }

            [Display(Name = "Poštna številka")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public int SelectedPostOfficeId { get; set; }

            [Display(Name = "Razmerje z mano")]
            [Required(ErrorMessage = "Polje je obvezno")]
            public int SelectedRelationshipId { get; set; }

            public List<Models.PostOffice> PostOffices { get; set; }
            public List<Models.District> Districts { get; set; }
            public List<Models.Relationship> Relationships { get; set; }

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
}