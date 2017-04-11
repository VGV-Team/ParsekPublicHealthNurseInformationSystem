using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Mandatory { get; set; }

        [Required]
        public bool Confirmed { get; set; }


        public virtual WorkOrder WorkOrder { get; set; }
    }
}