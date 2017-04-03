using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        // Attributes?


        
        public virtual ICollection<MaterialWorkOrder> MaterialWorkOrders { get; set; }
    }
}