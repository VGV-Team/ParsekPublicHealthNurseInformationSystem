using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }

        /*
        [Required]
        public RoleEnum Title { get; set; }

        //public virtual ICollection<User> Categories { get; set; }

        public enum RoleEnum
        {
            Admin = 1,
            Employee,
            Patient
        }
        */

        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string Patient = "Patient";
    }
}