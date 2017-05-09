using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; }

        [Required]
        public virtual Employee AbsenceNurse { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}