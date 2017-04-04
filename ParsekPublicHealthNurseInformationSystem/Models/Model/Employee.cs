using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Employee
    {
        
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public JobTitle Title { get; set; }

        public virtual User User { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual District District { get; set; } // Only for HealthVisitor
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public enum JobTitle
        {
            Doctor, //Doktor
            Head, // Vodja
            HealthNurse, // PS
            Coworker // Sodelavec
        };
    }
    
}