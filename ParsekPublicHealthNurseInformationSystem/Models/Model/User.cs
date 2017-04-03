using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        

        public virtual Role Role { get; set; }

        public virtual Patient Patient { get; set; } // Only 1 of each!!
        public virtual Employee Employee { get; set; } // Only 1 of each!!

    }
}