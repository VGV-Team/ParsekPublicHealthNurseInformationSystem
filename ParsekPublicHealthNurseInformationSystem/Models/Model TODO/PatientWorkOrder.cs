using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class PatientWorkOrder
    {
        [Key]
        public int PatientWorkOrderId { get; set; }
        



        public virtual Patient Patient { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public virtual ICollection<MaterialWorkOrder> MaterialWorkOrders { get; set; }
        public virtual ICollection<MedicineWorkOrder> MedicineWorkOrders { get; set; }
    }
}