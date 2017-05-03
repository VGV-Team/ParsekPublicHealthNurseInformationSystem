using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Web;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderViewModel
    {
        private EntityDataModel DB = new EntityDataModel();

        public WorkOrderViewModel()
        {
            NumberOfVisits = 1;
            AllPatients = DB.Patients.Where(x => x.ParentPatient==null).ToList();
            AllMedicines = DB.Medicines.ToList();
        }

        [Display(Name = "Dodatni pacienti")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public List<Patient> AllPatients { get; set; }

        [Display(Name = "Pacient")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string PatientId { get; set; }

        [Display(Name = "Izbran pacient")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string PatientIds { get; set; }

        [Display(Name = "Tip obiska")]
        public int SelectedServiceId { get; set; }

        [Display(Name = "Datum prvega obiska")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Polje je obvezno")]
        [CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        public DateTime DateTimeOfFirstVisit { get; set; }

        [Display(Name = "Obvezen prvi obisk")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public bool MandatoryFirstVisit { get; set; }

        [Display(Name = "Število obiskov")]
        [Range(1, 10, ErrorMessage = "Št. obiskov mora biti med 1 in 10")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int NumberOfVisits { get; set; }

        [Display(Name = "Več obiskov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public bool MultipleVisits { get; set; }

        [Display(Name = "Obdobje vseh obiskov")]
        [DataType(DataType.Date)]
        [CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public DateTime TimeFrame { get; set; }

        [Display(Name = "Interval med obiski")]
        [Range(1, 30, ErrorMessage = "Čas med obiskoma mora biti med 1 in 30.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int TimeInterval { get; set; }

        [Display(Name = "Tip časovnega vnosa")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public VisitTimeType? TimeType { get; set; }



        public List<Medicine> AllMedicines { get; set; }

        [Display(Name = "Seznam zdravil")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string MedicineIds { get; set; }



        [Display(Name = "Št. rdečih epruvet")]
        [Range(0, 30, ErrorMessage = "Število epruvet mora biti med 0 in 10.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int BloodVialRedCount { get; set; }
        [Display(Name = "Št. modrih epruvet")]
        [Range(0, 30, ErrorMessage = "Število epruvet mora biti med 0 in 10.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int BloodVialBlueCount { get; set; }
        [Display(Name = "Št. rumenih epruvet")]
        [Range(0, 30, ErrorMessage = "Število epruvet mora biti med 0 in 10.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int BloodVialYellowCount { get; set; }
        [Display(Name = "Št. zelenih epruvet")]
        [Range(0, 30, ErrorMessage = "Število epruvet mora biti med 0 in 10.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int BloodVialGreenCount { get; set; }




        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }
        public bool EnterPatients { get; set; }

        public enum VisitTimeType
        {
            [Display(Name = "Časovno obdobje")] TimeFrame = 1,
            [Display(Name = "Časovni interval")] TimeInterval = 2
        }
        
        public class CheckDateMaxRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null) return true;

                DateTime dt = (DateTime)value;
                if (dt >= DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(6))
                {
                    return true;
                }
                return false;
            }
        }
    }
}