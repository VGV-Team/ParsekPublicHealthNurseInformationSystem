using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitPatientViewModel
    {
        [Display(Name = "Obiski")]
        public List<Models.Visit> Visits { get; set; }


        public List<MyPatientVisit> MyPatientVisits { get; set; }

        public struct MyPatientVisit
        {
            public Models.Patient Patient { get; set; }
            public List<Models.Visit> Visits { get; set; }
        }
    }
}