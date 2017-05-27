using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models.Model
{
    public class ServiceMeasurement
    {
        [Key]
        public int ServiceMeasurementId { get; set; }

        public virtual Service Service { get; set; }

        public virtual Measurement Measurement { get; set; }

        public bool Active { get; set; }


    }
}