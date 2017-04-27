using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class ActivityInputWorkOrder
    {
        [Key]
        public int ActivityInputWorkOrderId { get; set; }

        public string Value { get; set; }

        public ActivityInput ActivityInput { get; set; }

        public Visit Visit { get; set; }
    }
}