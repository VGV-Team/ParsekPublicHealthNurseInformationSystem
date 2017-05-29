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

        public string FullNameWithCode => $"{Name} ({RelationshipId})";

        public virtual ICollection<Patient> Patients { get; set; }

        public bool Active { get; set; }
    }
}