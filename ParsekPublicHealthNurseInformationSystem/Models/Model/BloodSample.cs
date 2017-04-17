using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class BloodSample
    {
        [Key]
        public int BloodSampleId { get; set; }

        [Required]
        public int BloodVialRedCount { get; set; }
        [Required]
        public int BloodVialBlueCount { get; set; }
        [Required]
        public int BloodVialYellowCount { get; set; }
        [Required]
        public int BloodVialGreenCount { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
    }
}