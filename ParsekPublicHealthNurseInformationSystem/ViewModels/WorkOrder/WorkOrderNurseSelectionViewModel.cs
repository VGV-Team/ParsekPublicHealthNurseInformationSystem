using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderNurseSelectionViewModel
    {
        public List<Employee> PossibleNurses { get; set; }

        [Display(Name = "Izbrana patronažna sestra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedNurseId { get; set; }

        public List<Employee> PossibleNursesReplacement { get; set; }
        [Display(Name = "Izbrana nadomestna sestra")]
        public int? SelectedNurseReplacementId { get; set; }

        public int WorkOrderId { get; set; }

        public List<District> Districts { get; set; }
    }
}