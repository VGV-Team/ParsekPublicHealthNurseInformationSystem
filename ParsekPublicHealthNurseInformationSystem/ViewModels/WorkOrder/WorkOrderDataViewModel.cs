using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderDataViewModel
    {
        public List<int> PatientIds { get; set; }
        public int SelectedActivityId { get; set; }
        public DateTime DateTimeOfFirstVisit { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public int NumberOfVisits { get; set; }
        public bool MultipleVisits { get; set; }
        public DateTime TimeFrame { get; set; }
        public int TimeInterval { get; set; }
        public WorkOrderViewModel.VisitTimeType TimeType { get; set; }
        public List<int> MedicineIds { get; set; }
        public string BloodVialColor { get; set; }
        public int BloodVialCount { get; set; }
        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }
        public int SupervisorId { get; set; }
        public int SelectedNurseId { get; set; }
        public int? SelectedNurseReplacementId { get; set; }
    }
}