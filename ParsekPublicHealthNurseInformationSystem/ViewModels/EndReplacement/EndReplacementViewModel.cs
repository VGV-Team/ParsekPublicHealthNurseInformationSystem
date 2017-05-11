using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class EndReplacementViewModel
    {
        [Display(Name = "Sestre")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public List<Employee> AllNurses { get; set; }

        [Display(Name = "Odsotna sestra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string NurseId { get; set; }

        public string ViewMessage { get; set; }

        [Display(Name = "Delovni nalogi")]
        public List<Models.Absence> Absences { get; set; }
        public List<bool> CanDelete { get; set; }
    }
}