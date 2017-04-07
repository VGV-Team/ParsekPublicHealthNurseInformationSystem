using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }



        public virtual Role Role { get; set; }

        public virtual Patient Patient { get; set; } // Only 1 of each!!
        public virtual Employee Employee { get; set; } // Only 1 of each!!

        //[ForeignKey("Patient")]
        //public int PatientId { get; set; }
        //[ForeignKey("Employee")]
        //public int EmployeeId { get; set; }
    }
}