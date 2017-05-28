using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ParsekPublicHealthNurseInformationSystem.Models.ActivityActivityInput;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels.EditActivity
{
    public class EditActivityViewModel
    {
        [Display(Name = "Izberi meritev")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public List<Models.Activity> ActivityList { get; set; }
        public int SelectedActivity { get; set; }

        public List<Models.ActivityActivityInput> ActivityActivityInputList { get; set; }



        //new input
        [Display(Name = "Dodaj vnos")]
        public List<Models.ActivityInput> ActivityInputList { get; set; }
        public int SelectedActivityInput { get; set; }

        [Display(Name = "Obvezen vnos")]
        public bool Required { get; set; }

        [Display(Name = "Enkraten vnos")]
        public bool OneTime { get; set; }

        public InputForType ActivityInputFor { get; set; }

        /*[Display(Name = "Naziv vnosa")]
        public string InputTitle { get; set; }

        [Display(Name = "Obvezen vnos")]
        public bool InputRequired { get; set; }

        [Display(Name = "Najmanjša vrednost")]
        public int InputMinValue { get; set; }

        [Display(Name = "Najvišja vrednost")]
        public int InputMaxValue { get; set; }*/
    }
}