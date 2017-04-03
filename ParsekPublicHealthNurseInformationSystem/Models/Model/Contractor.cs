using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        [Required]
        public string Title { get; set; }



        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual PostOffice PostOffice { get; set; }

    }
}