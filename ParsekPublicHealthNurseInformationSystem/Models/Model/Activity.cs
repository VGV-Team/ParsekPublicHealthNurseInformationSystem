using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        public int ActivityCode { get; set; }
        [Required]
        public string ActivityTitle { get; set; }

        //public virtual Service Service { get; set; }

        public virtual ICollection<ServiceActivity> ServiceActivities { get; set; }

        public virtual ICollection<ActivityActivityInput> ActivityActivityInputs { get; set; }

        
    }
}