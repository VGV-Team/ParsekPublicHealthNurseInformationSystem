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
        public DateTime DateConfirmed { get; set; }

        [Required]
        public bool Mandatory { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        [Required]
        public bool Done { get; set; }


        //public bool Completed { get; set; }

        // Solution for replacement nurse
        // no replacement: null
        public virtual Employee NurseReplacement { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }

        public virtual ICollection<ActivityInputData> ActivityInputDatas { get; set; }
    }
}