using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Patient
    {
        [ForeignKey("User")]
        public int PatientId { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        // ...


        public virtual User User { get; set; }


        public virtual PostOffice PostOffice { get; set; }
        public virtual District District { get; set; }



        public int? ParentPatientId { get; set; }
        [ForeignKey("ParentPatientId")]
        public virtual Patient ParentPatient { get; set; }
        public virtual ICollection<PatientWorkOrder> PatientWorkOrders { get; set; }
    }
}