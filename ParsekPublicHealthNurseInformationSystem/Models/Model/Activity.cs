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

        [Required]
        public InputForType ActivityInputFor { get; set; }

        public virtual Service Service { get; set; }

        public virtual ICollection<ActivityInput> ActivityInputs { get; set; }

        public enum InputForType
        {
            All = 0,
            ParentOnly = 1,
            PatientOnly = 2
        }
    }
}