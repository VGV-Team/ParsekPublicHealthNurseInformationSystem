using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class EditVisitInputViewModel
    {

        [Display(Name = "Izberi vrsto obiska")]
        public List<Models.Service> VisitTypesList { get; set; }
        public int SelectedVisitType { get; set; }

        public List<Models.Activity> ActivityInputList { get; set; }
        public List<Models.Activity> ActivityInputListNoNumber { get; set; }


        //new input
        [Display(Name = "Izberi meritev")]
        public List<Models.Activity> InputActivityList { get; set; }
        public int SelectedInputActivity { get; set; }

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