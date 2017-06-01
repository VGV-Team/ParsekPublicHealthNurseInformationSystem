using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class VisualizationViewModel
    {
        public List<Patient> Patients { get; set; }

        [Required]
        [Display(Name = "Pacient")]
        public string PatientId { get; set; }


        public int? MainPatientId { get; set; }



        [Required]
        [Display(Name = "Od")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "Do")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public List<DateTime> Dates;
        public List<double> SystolicValues;
        public List<double> DiastolicValues;
    }
}