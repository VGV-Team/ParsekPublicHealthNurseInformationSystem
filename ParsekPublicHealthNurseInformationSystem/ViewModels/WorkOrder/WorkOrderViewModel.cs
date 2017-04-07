using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderViewModel
    {
        public Employee CurrentEmployee { get; set; }

        //public Patient Patient { get; set; }

        public List<int> AllPatients { get; set; }
        public int PatientId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTimeOfFirstVisit { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public int NumberOfVisits { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeFrame { get; set; }
        public int TimeInterval { get; set; }
        public VisitTimeType TimeType { get; set; }


        public WorkOrderCurativeViewModel CurativeVisit { get; set; }
        public WorkOrderPreventiveViewModel PreventiveVisit { get; set; }

        public VisitType Type { get; set; }

        public enum VisitType
        {
            [Display(Name = "Izberite iz seznama")] Default = 0,
            [Display(Name = "Kurativni obisk")] CurativeVisit = 1,
            [Display(Name = "Preventivni obisk")] PreventiveVisit = 2
        }

        public enum VisitTimeType
        {
            [Display(Name = "Izberite iz seznama")] Default = 0,
            [Display(Name = "Časovno obdobje")] TimeFrame = 1,
            [Display(Name = "Časovni interval")] TimeInterval = 2
        }

    }
}