using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }


        [Required]
        public string ServiceCode { get; set; }
        [Required]
        public string ServiceTitle { get; set; }

        [Required]
        public string ActivityCode { get; set; }
        [Required]
        public string ActivityTitle { get; set; }

        public string Report { get; set; }

        [Required]
        public bool PreventiveVisit { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }


        public bool RequiresMedicine => (ServiceCode == "50" && ActivityCode == "10");
        public bool RequiresBloodSample => (ServiceCode == "60" && ActivityCode == "10");
    }
}