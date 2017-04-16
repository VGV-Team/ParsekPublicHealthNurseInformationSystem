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
        public int BloodVialCount { get; set; }

        [Required]
        public string BloodVialColor { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
    }
}