using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}