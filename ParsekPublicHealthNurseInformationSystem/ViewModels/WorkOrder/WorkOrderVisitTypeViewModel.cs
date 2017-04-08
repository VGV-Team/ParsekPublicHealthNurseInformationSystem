using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderVisitTypeViewModel
    {
        private EntityDataModel DB = new EntityDataModel();

        [Display(Name = "Seznam aktivnosti")]
        public List<Activity> Activities { get; set; }

        [Display(Name = "Tip obiska")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedActivityId { get; set; }

        public void CreateWorkOrderVisitTypeViewModel(bool isDoctor)
        {
            Activities = !isDoctor ? DB.Activities.Where(x => x.PreventiveVisit == false).ToList() : DB.Activities.ToList();
        }
    }
}