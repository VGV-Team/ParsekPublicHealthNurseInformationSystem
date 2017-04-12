using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderDetailsViewModel
    {
        [Display(Name="Izdajatelj")]
        public string Supervisor { get; set; }

        [Display(Name = "Aktivnost")]
        public string ActivityTitle { get; set; }

        [Display(Name = "Zadolžena sestra")]
        public string Nurse { get; set; }

        [Display(Name = "Nadomestna sestra")]
        public string NurseReplacement { get; set; }

        [Display(Name = "Preventivni obisk")]
        public string PreventiveActivity { get; set; }

        [Display(Name = "Izvajalec")]
        public string ContractorName { get; set; }

        [Display(Name = "Pacienti")]
        public List<string> Patients { get; set; }

        [Display(Name = "Zdravila")]
        public List<string> Medicine { get; set; }

        [Display(Name = "Obiski")]
        public List<string> Visits { get; set; }
        public List<int> VisitIds { get; set; }

        [Display(Name = "Bolezni")]
        public string Disease { get; set; }

        [Display(Name = "Barva epruvet")]
        public string BloodVialColor { get; set; }

        [Display(Name = "Število epruvet")]
        public int BloodVialCount { get; set; }


        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }

        



    }
}