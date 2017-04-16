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
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }


        //public virtual ICollection<Patient> Patients { get; set; }
        //public virtual Employee Employee { get; set; } // Only HealthVisitor
        public virtual Contractor Contractor { get; set; }
    }
}