using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitViewModel
    {
        // TODO: add date
        // TODO: add required

        public int VisitId { get; set; }
        public List<Input> ActivityInputs { get; set; }

        
        //public string ActivityTitle { get; set; }
        public List<int> ActivityInputIds { get; set; }
        //public List<string> ActivityInputTitle { get; set; }
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
            }
        }
    }
}