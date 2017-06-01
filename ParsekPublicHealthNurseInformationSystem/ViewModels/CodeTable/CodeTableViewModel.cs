using System;
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
        public CodeCategory Category { get; set; }

        public List<Medicine> Medicines { get; set; }
        public List<Contractor> Contractors { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Relationship> Relationships { get; set; }
        public List<Service> Services { get; set; }
        public List<Activity> Activities { get; set; }
        public List<ActivityInput> ActivityInputs { get; set; }
        public List<Role> Roles { get; set; }
        public List<JobTitle> JobTitles { get; set; }

        public List<bool> Deleted { get; set; }

        public Medicine Medicine { get; set; }
        public Contractor Contractor { get; set; }
        public Disease Disease { get; set; }
        public Relationship Relationship { get; set; }
        public Service Service { get; set; }
        public Activity Activity { get; set; }
        public ActivityInput ActivityInput { get; set; }
        public Role Role { get; set; }
        public JobTitle JobTitle { get; set; }

        [Display(Name = "Iskanje:")]
        public string SelectedId { get; set; }
        public bool IsNew { get; set; }

        public List<PostOffice> PostOffices { get; set; }

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
            Service,
            [Display(Name = "Šifranti aktivnosti")]
            Activity,
            [Display(Name = "Šifranti vnosov")]
            ActivityInput,
            [Display(Name = "Šifranti vlog")]
            Role,
            [Display(Name = "Šifranti zdravstvenih delavcev")]
            JobTitle
        }


        

    }
}