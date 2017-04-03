using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public virtual User User { get; set; }
        public virtual Relationship Relationship { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual District District { get; set; }
        public virtual Patient ParentPatient { get; set; }
        // TODO:
        // Mahnic!!
        //public virtual ICollection<PatientWorkOrder> PatientWorkOrders { get; set; }
    }
}