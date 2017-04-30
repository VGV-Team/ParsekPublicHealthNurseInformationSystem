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

        public List<string> ParsedDetails;
        public List<string> ParsedDetailsTitles;
        public List<string> Categories;
        public List<int> CategoryItemCount;
    }
}