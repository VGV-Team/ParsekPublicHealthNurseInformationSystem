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
        public string PatientName { get; set; }

        public DateTime DateTimeOfFirstVisit { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public int NumberOfVisits { get; set; }
        public DateTime TimeFrame { get; set; }
        public int TimeBetweenVisits { get; set; }



        public WorkOrderCurativeViewModel CurativeVisit { get; set; }
        public WorkOrderPreventiveViewModel PreventiveVisit { get; set; }

        public VisitType Type { get; set; }

        public enum VisitType
        {
            [Display(Name = "Kurativni obisk")] CurativeVisit = 1,
            [Display(Name = "Preventivni obisk")] PreventiveVisit = 2,
        }



    }
}