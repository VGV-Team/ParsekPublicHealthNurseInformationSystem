using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitViewModel
    {
        // TODO: add date

        public int VisitId { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }

        public int PatientId { get; set; }
        
        public Patient MainPatient { get; set; }
        public List<Patient> ChildPatients { get; set; }

        public List<Input> ActivityInputs { get; set; }

        
        public List<int> ActivityInputIds { get; set; }
        public List<string> ActivityInputValues { get; set; }
        

        public struct Input
        {
            public string ActivityTitle;
            public List<InputData> ActivityInputDatas;

            public struct InputData
            {
                public int ActivityInputId;
                public string ActivityInputTitle;
                //public string ActivityInputValue;

                public bool Required;
                public bool ReadOnly;

                public ActivityInput.InputTypeEnum InputType;

                // Dropdown possible values
                public List<string> PossibleValues;
            }
        }
    }
}