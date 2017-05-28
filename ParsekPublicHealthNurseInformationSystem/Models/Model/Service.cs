using ParsekPublicHealthNurseInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string ServiceCode { get; set; }
        [Required]
        public string ServiceTitle { get; set; }

        [Required]
        public bool PreventiveVisit { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual ICollection<ServiceActivity> ServiceActivities { get; set; }

        //public virtual ICollection<Activity> Activities { get; set; }

        //public bool RequiresMedicine => (ServiceCode == "50" && ServiceCode == "10");
        //public bool RequiresBloodSample => (ServiceCode == "60" && ServiceCode == "10");
        public bool RequiresMedicine { get; set; }
        public bool RequiresBloodSample { get; set; }

        public bool RequiresPatients { get; set; }
    }
}