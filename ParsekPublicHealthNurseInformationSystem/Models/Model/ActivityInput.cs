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

        public InputTypeEnum InputType { get; set; }

        // For dropdown only
        public string PossibleValues { get; set; }

        // Only for first visit
        public bool OneTime { get; set; }


        public virtual Activity Activity { get; set; }

        public virtual ICollection<ActivityInputData> ActivityInputDatas { get; set; }

        // TODO: dropdown generation -- DONE?

        public enum InputTypeEnum
        {
            Free = 1,
            Date,
            Dropdown,
            Number
        }

    }
}