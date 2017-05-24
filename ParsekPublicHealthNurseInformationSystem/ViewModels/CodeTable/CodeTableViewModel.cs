﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class CodeTableViewModel
    {
        [Display(Name = "Željena kategorija")]
        public CodeCategory SelectedCodeCategory { get; set; }

        public List<Medicine> Medicines { get; set; }
        public List<Contractor> Contractors { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Relationship> Relationships { get; set; }
        public List<Service> Services { get; set; }

        public Medicine Medicine { get; set; }
        public Contractor Contractor { get; set; }
        public Disease Disease { get; set; }
        public Relationship Relationship { get; set; }
        public Service Service { get; set; }




        public enum CodeCategory
        {
            [Display(Name = "Šifranti zdravil")]
            Medicine = 1,
            [Display(Name = "Šifranti izvajalcev zdravstvene dejavnosti")]
            Contractor,
            [Display(Name = "Šifranti bolezni")]
            Disease,
            [Display(Name = "Šifranti sorodstvenih razmerij")]
            Relationship,
            [Display(Name = "Šifranti storitev")]
            Service
        }
        /*
        
         /šifrant vrst obiskov, 
         šifrant možnih uporabniških vlog, 
         /šifrant sorodstvenih razmerij, 
         /šifrant bolezni, 
         /šifrant zdravil, 
         šifrant meritev, 
         šifrant zdravstvenih delavcev (zdravnikov in patronažnih sester) in 
         /šifrant izvajalcev zdravstvene dejavnosti

        */
    }
}