using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderCurativeViewModel
    {

        public string[] InjectionMedications { get; set; }
        public string[] BloodVialColors { get; set; }
        public int[] BloodVialCounts { get; set; }

        public VisitTitle Title { get; set; }
        public enum VisitTitle
        {
            [Display(Name = "Izberite iz seznama")] Default = 0,
            [Display(Name = "Aplikacija injekcij")] InjectionApplication = 1,
            [Display(Name = "Odvzem krvi")] BloodSample = 2,
            [Display(Name = "Kontrola zdravstvenega stanja")] CheckingHealthCondition = 3
        }

    }
}