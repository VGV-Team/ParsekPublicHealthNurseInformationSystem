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


        public virtual Employee Issuer { get; set; }
        public virtual Employee Nurse { get; set; } 
        public virtual Employee NurseReplacement { get; set; }
        public virtual Patient Patient { get; set; }


        public virtual Contractor Contractor { get; set; }
        public virtual Disease Disease { get; set; }
        public virtual Service Service { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<PatientWorkOrder> PatientWorkOrders { get; set; }
        public virtual ICollection<MaterialWorkOrder> MaterialWorkOrders { get; set; }
        public virtual ICollection<MedicineWorkOrder> MedicineWorkOrders { get; set; }
        public virtual ICollection<BloodSample> BloodSamples { get; set; }

    }
}