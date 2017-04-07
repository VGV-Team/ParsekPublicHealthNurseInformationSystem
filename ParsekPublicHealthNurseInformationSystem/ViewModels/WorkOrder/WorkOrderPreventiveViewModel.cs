using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderPreventiveViewModel
    {
        public VisitTitle Title { get; set; }

        public enum VisitTitle
        {
            [Display(Name = "Obisk nosečnice")] VisitPregnantWomen = 1,
            [Display(Name = "Obisk otročnice")] VisitPuerperium = 2,
            [Display(Name = "obisk novorojenčka")] VisitNewborn = 3,
            [Display(Name = "Preventiva starostnika")] VisitElderly = 4

        }
    }
}