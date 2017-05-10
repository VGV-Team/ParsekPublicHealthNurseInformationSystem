using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels.NurseReplacement
{
    public class NurseReplacementViewModel
    {
        [Display(Name = "Sestre")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public List<Employee> AllNurses { get; set; }

        [Display(Name = "Odsotna sestra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string NurseId { get; set; }
        [Display(Name = "Nadomestna sestra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string ReplacementNurseId { get; set; }

        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public string ViewMessage { get; set; }
    }
}