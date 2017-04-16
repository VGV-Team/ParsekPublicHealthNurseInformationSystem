using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class MaterialWorkOrder
    {
        [Key]
        public int MaterialWorkOrderId { get; set; }




        public virtual WorkOrder PatientWorkOrder { get; set; }
        public virtual Material Material { get; set; }
    }
}