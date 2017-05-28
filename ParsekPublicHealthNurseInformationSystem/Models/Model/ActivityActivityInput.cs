using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class ActivityActivityInput
    {
        [Key]
        public int ActivityActivityInputId { get; set; }


        public virtual Activity Activity { get; set; }

        public virtual ActivityInput ActivityInput { get; set; }

        public virtual ICollection<ActivityInputData> ActivityInputDatas { get; set; }

        // Deleted?
        public bool Active { get; set; }

        public bool Required { get; set; }
        // Only for first visit
        public bool OneTime { get; set; }


        public enum InputForType
        {
            [Display(Name = "Vsi")]
            All = 0,
            [Display(Name = "Samo starši")]
            ParentOnly = 1,
            [Display(Name = "Samo otroci")]
            PatientOnly = 2
        }

        [Required]
        public InputForType ActivityInputFor { get; set; }
    }
}