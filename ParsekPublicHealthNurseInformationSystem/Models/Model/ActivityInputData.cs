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

        public virtual Patient Patient { get; set; }

        public virtual Visit Visit { get; set; }
    }
}