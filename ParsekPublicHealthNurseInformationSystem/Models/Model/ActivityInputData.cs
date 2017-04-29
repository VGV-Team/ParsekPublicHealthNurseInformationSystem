using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class ActivityInputData
    {
        [Key]
        public int ActivityInputDataId { get; set; }

        public string Value { get; set; }

        public virtual ActivityInput ActivityInput { get; set; }

        public Patient Patient { get; set; }

        public Visit Visit { get; set; }
    }
}