using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class PostOffice
    {
        [Key]
        public int PostOfficeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Number { get; set; }

        public string FullName => $"{Number} - {Title}";

        //public virtual ICollection<Patient> Patients { get; set; }
        //public virtual ICollection<Contractor> Contractor { get; set; }

        public bool Active { get; set; }
    }
}