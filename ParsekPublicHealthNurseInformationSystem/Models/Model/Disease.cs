using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseId { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }

        public string FullNameWithCode => $"{Description}  [{Code}] ({DiseaseId})";

        //public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public bool Active { get; set; }
    }
}