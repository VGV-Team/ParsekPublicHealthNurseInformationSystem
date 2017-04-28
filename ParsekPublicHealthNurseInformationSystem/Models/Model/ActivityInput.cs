using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class ActivityInput
    {
        [Key]
        public int ActivityInputId { get; set; }

        public bool Required { get; set; }

        public string Title { get; set; }


        public virtual Activity Activity { get; set; }

        public virtual ICollection<ActivityInputData> ActivityInputDatas { get; set; }

        // TODO: dropdown generation
    }
}