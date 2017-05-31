using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisualizationViewModel
    {
        public int MainPatientId { get; set; }

        public List<ActivityInputData> Datas { get; set; }

        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}