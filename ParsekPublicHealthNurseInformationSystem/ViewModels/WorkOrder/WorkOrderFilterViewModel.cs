using ParsekPublicHealthNurseInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderFilterViewModel
    {

        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        /*[Display(Name = "Vrsta obiska")]
        public VisitTypeEnum VisitType { get; set; }*/
        [Display(Name = "Vrsta obiska")]
        public List<Service> Services { get; set; }

        public int? ServiceId { get; set; }

        [Display(Name = "Izdajatelj")]
        public List<Models.Employee> Issuers { get; set; }

        [Display(Name = "Pacient")]
        public List<Models.Patient> Patients { get; set; }

        [Display(Name = "Zadolžena sestra")]
        public List<Models.Employee> Nurse { get; set; }

        [Display(Name = "Nadomestna sestra")]
        public List<Models.Employee> NurseReplacement { get; set; }


        public int SelectedIssuerId { get; set; }
        public int SelectedPatientId { get; set; }
        public int SelectedNurseId { get; set; }
        public int SelectedNurseReplacementId { get; set; }

        // We have VisitType instead of this
        //public List<Models.Service> Services { get; set; }

        [Display(Name = "Delovni nalogi")]
        public List<Models.WorkOrder> WorkOrders { get; set; }
        public List<bool> CanDelete { get; set; }

        public enum VisitTypeEnum
        {
            [Display(Name = "Preventivni")]
            Preventive = 1,
            [Display(Name = "Kurativni")]
            Curative
        }

    }
}