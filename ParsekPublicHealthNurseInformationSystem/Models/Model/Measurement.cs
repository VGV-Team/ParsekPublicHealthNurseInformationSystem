using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models.Model
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }

        [Required]
        public string MeasurementTitle { get; set; }

        public virtual Service Service { get; set; }

        public virtual ICollection<ActivityInput> ActivityInputs { get; set; }

        public InputForType InputFor { get; set; }

        // For dropdown only
        public string PossibleValues { get; set; }

        public bool Required { get; set; }

        // Only for first visit
        public bool OneTime { get; set; }

        public enum InputForType
        {
            All = 0,
            ParentOnly = 1,
            PatientOnly = 2
        }

    }
}