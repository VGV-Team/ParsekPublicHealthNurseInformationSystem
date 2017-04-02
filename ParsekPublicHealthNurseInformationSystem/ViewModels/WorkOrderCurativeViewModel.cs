using System;
using System.Collections.Generic;
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
            InjectionApplication,
            BloodSample,
            CheckingHealthCondition

        }

    }
}