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
        public virtual JobTitle JobTitle { get; set; }
        [Required]
        public virtual Contractor Contractor { get; set; }
        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }
        public virtual District District { get; set; } // Only for HealthNurse

        //public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<Visit> Visits { get; set; } //Only nurse

        public virtual ICollection<Absence> Absences { get; set; } //Only nurse

        public string DisplayName => $"{Name} {Surname} [{Number}]";

        public string FullNameWithCode => $"{Surname} {Name} - ({EmployeeId})" + (JobTitle.Title == JobTitle.HealthNurse ? $" - {District.Name}" : "");

        public string FullName => $"{Surname} {Name}";
    }
    
}