using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class ServiceActivity
    {
        [Key]
        public int ServiceActivityId { get; set; }


        public virtual Service Service { get; set; }

        public virtual Activity Activity { get; set; }

        // Deleted?
        public bool Active { get; set; }

    }
}