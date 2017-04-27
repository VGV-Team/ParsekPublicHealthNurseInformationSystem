using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderDataViewModel
    {
        public int PatientId { get; set; }
        public List<int> PatientIds { get; set; }
        public int SelectedServiceId { get; set; }
        public DateTime DateTimeOfFirstVisit { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public int NumberOfVisits { get; set; }
        public bool MultipleVisits { get; set; }
        public DateTime TimeFrame { get; set; }
        public int TimeInterval { get; set; }
        public WorkOrderViewModel.VisitTimeType? TimeType { get; set; }
        public List<int> MedicineIds { get; set; }

        public int BloodVialRedCount { get; set; }
        public int BloodVialBlueCount { get; set; }
        public int BloodVialYellowCount { get; set; }
        public int BloodVialGreenCount { get; set; }

        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }
        public bool EnterPatients { get; set; }
        public int SupervisorId { get; set; }
        public int SelectedNurseId { get; set; }
    }
}