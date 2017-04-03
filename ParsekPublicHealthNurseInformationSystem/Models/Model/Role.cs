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

        public virtual ICollection<User> Categories { get; set; }
    }
}