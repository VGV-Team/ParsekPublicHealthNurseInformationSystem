using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class MedicineWorkOrder
    {
        [Key]
        public int MedicineWorkOrderId { get; set; }


        public virtual WorkOrder WorkOrder { get; set; }
        public virtual Medicine Medicine { get; set; }

    }
}