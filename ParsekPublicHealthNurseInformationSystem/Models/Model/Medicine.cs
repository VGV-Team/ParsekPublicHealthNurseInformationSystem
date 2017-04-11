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

        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }

        public string FullNameWithCode => $"{Code}; {Title}; ({MedicineId})";

        public string FullName => $"{Code}; {Title}";

        //public virtual ICollection<MedicineWorkOrder> MedicineWorkOrders { get; set; }
    }
}