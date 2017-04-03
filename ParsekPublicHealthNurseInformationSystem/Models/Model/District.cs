using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Required]
        public string Name { get; set; }

        // GPS?
        public string Lat { get; set; }
        public string Lon { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
        public virtual Employee Employee { get; set; } // Only HealthVisitor
    }
}