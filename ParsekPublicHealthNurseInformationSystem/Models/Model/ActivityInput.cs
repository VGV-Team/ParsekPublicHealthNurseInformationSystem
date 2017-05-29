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
        
        public string Title { get; set; }

        public string FullNameWithCode => $"{Title} ({ActivityInputId})";

        public InputTypeEnum InputType { get; set; }

        // For dropdown only
        public string PossibleValues { get; set; }

        public virtual ICollection<ActivityActivityInput> ActivityActivityInputs { get; set; } 


        // TODO: dropdown generation -- DONE?

        public enum InputTypeEnum
        {
            [Display(Name = "Besedilo")]
            Free = 1,
            [Display(Name = "Datum")]
            Date,
            [Display(Name = "Seznam")]
            Dropdown,
            [Display(Name = "Številka")]
            Number
        }

        public bool Active { get; set; }
    }
}