using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderViewModel
    {
        // TODO: validation not working??


        public WorkOrderViewModel()
        {
            NumberOfVisits = 1;
        }

        [Display(Name = "Pacienti")]
        public List<Patient> AllPatients { get; set; }

        [Display(Name = "Izbran pacient")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int PatientId { get; set; }

        
        [Display(Name = "Datum prvega obiska")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Polje je obvezno")]
        //[CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        public DateTime DateTimeOfFirstVisit { get; set; }

        [Display(Name = "Obvezen prvi obisk")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public bool MandatoryFirstVisit { get; set; }

        [Display(Name = "Število obiskov")]
        [Range(1, 10, ErrorMessage = "Št. obiskov mora biti med 1 in 10")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int NumberOfVisits { get; set; }

        [Display(Name = "Obdobje vseh obiskov")]
        [DataType(DataType.Date)]
        //[CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public DateTime TimeFrame { get; set; }

        [Display(Name = "Interval med obiski")]
        [Range(1, 30, ErrorMessage = "Čas med obiskoma mora biti med 1 in 30.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int TimeInterval { get; set; }

        [Display(Name = "Tip časovnega vnosa")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public VisitTimeType TimeType { get; set; }

        /*
        public WorkOrderCurativeViewModel CurativeVisit { get; set; }
        public WorkOrderPreventiveViewModel PreventiveVisit { get; set; }

        public VisitType Type { get; set; }

        public enum VisitType
        {
            [Display(Name = "Izberite iz seznama")] Default = 0,
            [Display(Name = "Kurativni obisk")] CurativeVisit = 1,
            [Display(Name = "Preventivni obisk")] PreventiveVisit = 2
        }
        */

        public enum VisitTimeType
        {
            [Display(Name = "Časovno obdobje")] TimeFrame = 1,
            [Display(Name = "Časovni interval")] TimeInterval = 2
        }
        
        public class CheckDateMaxRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
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