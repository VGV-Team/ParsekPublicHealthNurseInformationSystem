using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitPlannerViewModel
    {

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Date)]
        [Display(Name = "Odpri plan za")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlanDate { get; set; }

        public List<Models.Visit> MandatoryVisits { get; set; }
        public List<Models.Visit> OptionalVisits { get; set; }
        public List<Models.Visit> OverdueVisits { get; set; }

        public string ViewMessage { get; set; }

    }
}