using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Web;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.ViewModels
{
    public class WorkOrderViewModel
    {
        // TODO: validation not working??
        // TODO: hidden fields still validating??
        // TODO: dropdowns can be empty??

        private EntityDataModel DB = new EntityDataModel();

        public WorkOrderViewModel()
        {
            NumberOfVisits = 1;
            AllPatients = DB.Patients.ToList(); // TODO: horrible fix!! Change this!
            AllMedicines = DB.Medicines.ToList();
        }

        [Display(Name = "Pacienti")]
        public List<Patient> AllPatients { get; set; }

        [Display(Name = "Izbran pacient")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string PatientIds { get; set; }

        [Display(Name = "Tip obiska")]
        public int SelectedActivityId { get; set; }

        [Display(Name = "Datum prvega obiska")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Polje je obvezno")]
        [CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        public DateTime DateTimeOfFirstVisit { get; set; }

        [Display(Name = "Obvezen prvi obisk")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public bool MandatoryFirstVisit { get; set; }

        [Display(Name = "Število obiskov")]
        [Range(1, 10, ErrorMessage = "Št. obiskov mora biti med 1 in 10")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int NumberOfVisits { get; set; }

        [Display(Name = "Več obiskov")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public bool MultipleVisits { get; set; }

        [Display(Name = "Obdobje vseh obiskov")]
        [DataType(DataType.Date)]
        [CheckDateMaxRangeAttribute(ErrorMessage = "Neustrezen datum")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public DateTime TimeFrame { get; set; }

        [Display(Name = "Interval med obiski")]
        [Range(1, 30, ErrorMessage = "Čas med obiskoma mora biti med 1 in 30.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int TimeInterval { get; set; }

        [Display(Name = "Tip časovnega vnosa")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public VisitTimeType? TimeType { get; set; }



        public List<Medicine> AllMedicines { get; set; }
        public List<string> AllColors = new List<string> { "Rdeča", "Modra", "Rumena", "Zelena" };

        [Display(Name = "Seznam zdravil")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string MedicineIds { get; set; }

        [Display(Name = "Barva epruvete")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public string BloodVialColor { get; set; }

        [Display(Name = "Število epruvet")]
        [Range(1, 30, ErrorMessage = "Število epruvet mora biti med 1 in 10.")]
        [Required(ErrorMessage = "Polje je obvezno")]
        public int BloodVialCount { get; set; }

        public bool EnterMedicine { get; set; }
        public bool EnterBloodSample { get; set; }

        public enum VisitTimeType
        {
            [Display(Name = "Časovno obdobje")] TimeFrame = 1,
            [Display(Name = "Časovni interval")] TimeInterval = 2
        }
        
        public class CheckDateMaxRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null) return true;

                DateTime dt = (DateTime)value;
                if (dt >= DateTime.UtcNow && dt <= DateTime.UtcNow.AddMonths(6))
                {
                    return true;
                }
                return false;
            }
        }


        public string GenerateDropDown(List<Medicine> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var medicine in list)
            {
                converterToStrings.Add(medicine.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public string GenerateDropDown(List<Patient> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var patient in list)
            {
                converterToStrings.Add(patient.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }


        public string GenerateDropDown(List<string> list, string id, bool multiChoice = true)
        {
            string str = "<script>\n" +
                         "$(function() {\n" +
                         "var availableTags = [\n";


            for (var index = 0; index < list.Count; index++)
            {
                str += "\"" + list[index] + "\"";

                if (index < list.Count-1)
                    str += ",";
            }
            if (multiChoice)
            {
                str += "];\n" +
                       "function split(val) {\n" +
                       "return val.split(/,\\s*/);\n" +
                       "}\n" +
                       "function extractLast(term) {\n" +
                       "return split(term).pop();\n" +
                       "}\n" +
                       "$(\"#" + id + "\")\n" +
                       "// don't navigate away from the field on tab when selecting an item\n" +
                       ".on(\"keydown\", function (event) {\n" +
                       "if (event.keyCode === $.ui.keyCode.TAB &&\n" +
                       "$(this).autocomplete(\"instance\").menu.active) {\n" +
                       "event.preventDefault();\n" +
                       "}\n" +
                       "}).autocomplete({\n" +
                       "minLength: 0,\n" +
                       "source: function (request, response) {\n" +
                       "// delegate back to autocomplete, but extract the last term\n" +
                       "response($.ui.autocomplete.filter(\n" +
                       "availableTags, extractLast(request.term)));\n" +
                       "},\n" +
                       "focus: function () {\n" +
                       "// prevent value inserted on focus\n" +
                       "return false;\n" +
                       "},\n" +
                       "select: function (event, ui) {\n" +
                       "var terms = split(this.value);\n" +
                       "// remove the current input\n" +
                       "terms.pop();\n" +
                       "// add the selected item\n" +
                       "terms.push(ui.item.value);\n" +
                       "// add placeholder to get the comma-and-space at the end\n" +
                       "terms.push(\"\");\n" +
                       "this.value = terms.join(\", \");\n" +
                       "return false;\n" +
                       "}\n" +
                       "});\n" +
                       "});\n" +
                       "</script>";
            }
            else
            {
                str += "];" +
                       "$(\"#" + id +"\").autocomplete({\n" +
                       "source: availableTags\n" +
                       "});" +
                       "} );" +
                       "</script>";
            }
            return str;
        }

        
    }
}