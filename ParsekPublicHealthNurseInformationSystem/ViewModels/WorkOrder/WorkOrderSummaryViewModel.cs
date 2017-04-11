using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderSummaryViewModel
    {
        public string Supervisor { get; set; }
        public string ActivityTitle { get; set; }
        public string Nurse { get; set; }
        public string NurseReplacement { get; set; }

        public List<string> Patients { get; set; }
        public bool MultipleVisits { get; set; }
        public WorkOrderViewModel.VisitTimeType TimeType { get; set; }
        public int NumberOfVisits { get; set; }
        public DateTime DateTimeOfFirstVisit { get; set; }
        public DateTime TimeFrame { get; set; }
        public int TimeInterval { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public List<string> Medicine { get; set; }
        public string BloodVialColor { get; set; }
        public int BloodVialCount { get; set; }
        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }
    }
}