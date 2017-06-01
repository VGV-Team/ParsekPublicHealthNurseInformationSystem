using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels.ServiceCost
{
    public class ServiceCostViewModel
    {
        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public bool Print { get; set; }
        public string ViewMessage { get; set; }
        public string[] ServiceType { get; set; }
        public int[] Count { get; set; }
        public double[] ServiceTotal { get; set; }
        public double[] MedicineTotal { get; set; }
        public double[] Total { get; set; }
    }
}