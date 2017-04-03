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
        public string Name { get; set; }


        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}