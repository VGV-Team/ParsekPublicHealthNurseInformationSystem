using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        // Attributes?



        public virtual ICollection<MedicineWorkOrder> MedicineWorkOrders { get; set; }
    }
}