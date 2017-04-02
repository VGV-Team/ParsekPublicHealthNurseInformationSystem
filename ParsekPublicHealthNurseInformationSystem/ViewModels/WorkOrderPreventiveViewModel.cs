using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderPreventiveViewModel
    {
        public VisitTitle Title { get; set; }

        public enum VisitTitle
        {
            VisitPregnantWomen,
            VisitPuerperium,
            VisitNewborn,
            VisitElderly

        }
    }
}