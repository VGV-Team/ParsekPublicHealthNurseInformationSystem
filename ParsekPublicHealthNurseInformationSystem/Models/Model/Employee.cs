using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Employee
    {
        
        [ForeignKey("User")]
        public int EmployeeId { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public JobTitle Title { get; set; }
        [Required]
        public virtual Contractor Contractor { get; set; }
        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }
        public virtual District District { get; set; } // Only for HealthNurse

        //public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<Visit> Visits { get; set; } //Only nurse

        public string DisplayName { get { return string.Format("{0} {1} [{2}]", Name, Surname, Number); } }

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

        public string FullNameWithCode => $"{Surname} {Name} - ({EmployeeId})" + (Title == JobTitle.HealthNurse ? $" - {District.Name}" : "");

        public string FullName => $"{Surname} {Name}";
    }
    
}