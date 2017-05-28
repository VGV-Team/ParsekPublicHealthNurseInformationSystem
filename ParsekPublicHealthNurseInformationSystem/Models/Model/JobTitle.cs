using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public const string Doctor = "Doktor";
        public const string Head = "Vodja";
        public const string HealthNurse = "Sestra";
        public const string Coworker = "Sodelavec";

        /*
        //[Display(Name = "Tip zaposlenega")]
        public enum JobTitle
        {
            [Display(Name = "Doktor")]
            Doctor = 1, //Doktor
            [Display(Name = "Vodja")]
            Head, // Vodja
            [Display(Name = "Patronažna sestra")]
            HealthNurse, // PS
            [Display(Name = "Sodelavec")]
            Coworker // Sodelavec
        };
        */
    }
}