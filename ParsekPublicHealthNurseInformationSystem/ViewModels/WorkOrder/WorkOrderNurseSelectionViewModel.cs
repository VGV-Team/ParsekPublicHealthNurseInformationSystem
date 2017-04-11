using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderNurseSelectionViewModel
    {
        private EntityDataModel DB = new EntityDataModel();

        public List<Employee> PossibleNurses { get; set; }

        [Display(Name = "Izbrana patronažna sestra")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedNurseId { get; set; }

        public List<Employee> PossibleNursesReplacement { get; set; }
        [Display(Name = "Izbrana nadomestna sestra")]
        public int? SelectedNurseReplacementId { get; set; }

        public List<int> Districts { get; set; }

        public void CreateWorkOrderNurseSelectionViewModel(List<int> districts = null)
        {
            if(districts != null)
                Districts = districts;
            PossibleNursesReplacement = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
            PossibleNurses = PossibleNursesReplacement.Where(x => Districts.Contains(x.District.DistrictId)).ToList();
            if (PossibleNurses == null || PossibleNurses.Count == 0)
                PossibleNurses = PossibleNursesReplacement;
        }
    }
}