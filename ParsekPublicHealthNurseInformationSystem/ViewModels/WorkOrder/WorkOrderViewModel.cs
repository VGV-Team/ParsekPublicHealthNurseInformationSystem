using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderViewModel
    {
        public string SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorSurname { get; set; }
        public string SupervisorTitle { get; set; }

        public string[] PatientIds { get; set; } // ids for all patients (in case of mother - child relationships)

        


        public DateTime DateTimeOfFirstVisit { get; set; }
        public bool MandatoryFirstVisit { get; set; }
        public int NumberOfVisits { get; set; }
        public DateTime TimeFrame { get; set; }


        public WorkOrderPreventiveViewModel PreventiveVisit { get; set; }
        public WorkOrderCurativeViewModel CurativeVisit { get; set; }


    }
}