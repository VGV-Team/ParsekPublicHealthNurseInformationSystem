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
        public List<Service> Services { get; set; }

        [Display(Name = "Tip obiska")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int SelectedServiceId { get; set; }

        public void CreateWorkOrderVisitTypeViewModel(bool isDoctor)
        {
            Services = isDoctor ? DB.Services.ToList() : DB.Services.Where(x => x.PreventiveVisit == true).ToList();
        }
    }
}