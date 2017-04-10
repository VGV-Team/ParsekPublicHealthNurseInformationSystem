using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class IpLog
    {
        [Key]
        public int IpId { get; set; }
        [Required]
        public string Ips { get; set; }
        [Required]
        public int counter { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastTry { get; set; }
    }
}