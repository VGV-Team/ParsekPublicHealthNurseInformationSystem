using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderSummaryViewModel
    {
        public string Supervisor { get; set; }
        public string ServiceTitle { get; set; }
        public string Nurse { get; set; }

        public string Patient { get; set; }
        public List<string> Patients { get; set; }
        public bool MultipleVisits { get; set; }
        public WorkOrderViewModel.VisitTimeType? TimeType { get; set; }
        public int NumberOfVisits { get; set; }
        public DateTime DateTimeOfFirstVisit { get; set; }
        public DateTime TimeFrame { get; set; }
        public int TimeInterval { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public List<string> Medicine { get; set; }

        public int BloodVialRedCount { get; set; }
        public int BloodVialBlueCount { get; set; }
        public int BloodVialYellowCount { get; set; }
        public int BloodVialGreenCount { get; set; }

        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }
        public bool EnterPatients { get; set; }
        
    }
}