﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisitPlannerViewModel
    {

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Date)]
        [Display(Name = "Odpri plan za")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlanDate { get; set; }

        public List<Models.Visit> MandatoryVisits { get; set; }

        public List<List<Models.Visit>> Visits { get; set; }

        public int VisitsDays { get; set; }
        public int? HiddenVisitId { get; set; }

        public List<Models.Visit> OptionalVisits { get; set; }
        public List<Models.Visit> OverdueVisits { get; set; }

        // Material list
        
        public List<List<MaterialList>> Materials { get; set; }

        public struct MaterialList
        {
            public string MaterialName;
            public int Count;
        }

        //////////////////////////
        

        public string ViewMessage { get; set; }

    }
}