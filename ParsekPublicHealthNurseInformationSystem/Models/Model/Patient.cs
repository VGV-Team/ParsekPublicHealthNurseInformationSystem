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
        //[ForeignKey("User")]
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public virtual PostOffice PostOffice { get; set; }
        [Required]
        public virtual District District { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // Contact person
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactRelationship { get; set; }
        //

        public string FullName => $"{Surname} {Name}";
        public string FullNameWithCode => $"{Surname} {Name} - {PatientId}";

        public virtual ICollection<User> User { get; set; } // ONE TO ONE WORKAROUND

        public virtual Relationship ParentPatientRelationship { get; set; } // optional parent Patient relationship
        public int? ParentPatientId { get; set; } // optional parent Patient ID
        [ForeignKey("ParentPatientId")]
        public virtual Patient ParentPatient { get; set; } // optional FK for parent Patient
        public virtual ICollection<Patient> ChildPatients { get; set; } // optional child Patients


        public virtual ICollection<PatientWorkOrder> PatientWorkOrders { get; set; }

        public enum GenderEnum
        {
            [Display(Name = "Moški")]
            Male = 'M',
            [Display(Name = "Ženski")]
            Female = 'Ž'
        }
    }
}