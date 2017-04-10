using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderSummaryViewModel
    {
        public ViewModels.WorkOrderViewModel WorkOrderVM { get; set; }

        public List<string> Patients { get; set; }
        public string Doctor { get; set; }
        public string ActivityTitle { get; set; }

        public List<string> Medicine { get; set; }

        public ViewModels.WorkOrderNurseSelectionViewModel WorkOrderNurseVM { get; set; }

        public string Nurse { get; set; }
        public string NurseReplacement { get; set; }
    }
}