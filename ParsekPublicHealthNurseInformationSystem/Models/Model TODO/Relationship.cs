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
        public int RelatinshipId { get; set; } // Strong table, preferably should be weak
        [Required]
        public string Description { get; set; } // "Parent", "Son", "Uncle", ...

        public virtual Patient Patient { get; set; }
        public virtual ContactPerson ContactPerson { get; set; }
    }
}