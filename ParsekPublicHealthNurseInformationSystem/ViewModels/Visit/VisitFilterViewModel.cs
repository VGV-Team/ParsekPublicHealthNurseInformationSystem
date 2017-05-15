using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitFilterViewModel
    {

        [Display(Name = "Od (predvideno)")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Do (predvideno)")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Od (dejansko)")]
        [DataType(DataType.Date)]
        public DateTime? DateStartConfirmed { get; set; }

        [Display(Name = "Do (dejansko)")]
        [DataType(DataType.Date)]
        public DateTime? DateEndConfirmed { get; set; }

        [Display(Name = "Vrsta obiska")]
        public List<Service> Services { get; set; }

        public int? ServiceId { get; set; }

        [Display(Name = "Izdajatelj delovnega naloga")]
        public List<Models.Employee> Issuers { get; set; }

        [Display(Name = "Pacient")]
        public List<Models.Patient> Patients { get; set; }

        [Display(Name = "Zadolžena sestra")]
        public List<Models.Employee> Nurse { get; set; }

        [Display(Name = "Nadomestna sestra")]
        public List<Models.Employee> NurseReplacement { get; set; }

        [Display(Name = "Opravljen")]
        public VisitDoneEnum VisitDone { get; set; }


        public int SelectedIssuerId { get; set; }
        public int SelectedPatientId { get; set; }
        public int SelectedNurseId { get; set; }
        public int SelectedNurseReplacementId { get; set; }

        // We have VisitType instead of this
        //public List<Models.Service> Services { get; set; }

        [Display(Name = "Obiski")]
        public List<Models.Visit> Visits { get; set; }

        public enum VisitDoneEnum
        {
            [Display(Name = "Da")]
            Yes = 1,
            [Display(Name = "Ne")]
            No
        }

    }
}