using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual Disease Disease { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
        // TODO:
        // MAHNIC!
        //public virtual ICollection<PatientWorkOrder> PatientWorkOrders { get; set; }


    }
}