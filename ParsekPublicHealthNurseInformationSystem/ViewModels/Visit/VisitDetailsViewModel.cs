using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitDetailsViewModel
    {
        public Models.Visit Visit { get; set; }
        //public List<Models.ActivityInput> ActivityInputs { get; set; }

        public ParsedData PatientData { get; set; }
        public List<ParsedData> ChildPatientData { get; set; }

        public ParsedData GeneralData { get; set; }

        public class ParsedData
        {
            public List<string> ParsedDetails;
            public List<string> ParsedDetailsTitles;
            public List<string> Categories;
            public List<int> CategoryItemCount;
            public string PatientName;

            public ParsedData()
            {
                ParsedDetails = new List<string>();
                ParsedDetailsTitles = new List<string>();
                Categories = new List<string>();
                CategoryItemCount = new List<int>();
            }
        }

    }

    
}