using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public static class Globals
    {
        public const string SystolicBloodPressureTitle = "Sistolični (mm Hg)";
        public const string DiastolicBloodPressureTitle = "Diastolični (mm Hg)";


        public static int[] GetIdsFromString(string input)
        {
            string[] splits = input.Split(',');
            List<int> ids = new List<int>();
            for (int i = 0; i < splits.Length; i++)
            {
                string idString = splits[i].Split('(').Last().Split(')').First();
                int id;
                if (int.TryParse(idString, out id) && id != 0)
                {
                    ids.Add(id);
                }
            }

            return ids.ToArray().Distinct().ToArray();
        }


        #region Graph

        public static string GenerateGraph(string chartName, int? width, int? height, List<string> labels, string title1, List<double> values1, string title2, List<double> values2)
        {

            string str = @"
                <canvas id='" + chartName + "' " + (width != null ? "width='" + width.ToString() + "' " : "") +
                         (height != null ? "height='" + height.ToString() + "' " : "") + @"></canvas>
                <script>
	                var ctx" + chartName + @" = document.getElementById('" + chartName + @"').getContext('2d');
	                var myLineChart = new Chart(ctx" + chartName + @",
		                {
			                'type': 'line',
			                'data':
			                {
				                'labels': [";

                for(int i = 0; i < labels.Count; i++)
                {
                    if (i != 0)
                        str += ",";
                    str += "'" + labels[i] + "'";
                }

            str +=
                                @"],
				                'datasets': [";

            str += @"
                {
                    'label': '" + title1 + @"',
                    'data': [";

            for (int i = 0; i < values1.Count; i++)
            {
                if (i != 0)
                    str += ",";
                str += "'" + values1[i] + "'";
            }

            str += @"],
                'fill': false,
			    'borderColor': 'rgb(75, 192, 192)',
			    'lineTension': 0.1
            }";

            if (title2 != null && values2 != null)
            {
                str += @",
                {
                    'label': '" + title2 + @"',
                    'data': [";

                for (int i = 0; i < values2.Count; i++)
                {
                    if (i != 0)
                        str += ",";
                    str += "'" + values2[i] + "'";
                }

                str += @"],
                'fill': false,
			    'borderColor': 'rgb(192, 25, 64)',
			    'lineTension': 0.1
                }";
            }

            str +=		      @"]
			                },
			                'options': {}
		                }
	                );
                </script>
            ";

            return str;
        }

        #endregion


        #region DropDown

        public static string GenerateDropDown(List<Medicine> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var medicine in list)
            {
                converterToStrings.Add(medicine.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Contractor> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var contractor in list)
            {
                converterToStrings.Add(contractor.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Disease> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var disease in list)
            {
                converterToStrings.Add(disease.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Relationship> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var relationship in list)
            {
                converterToStrings.Add(relationship.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Service> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var service in list)
            {
                converterToStrings.Add(service.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Activity> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var activity in list)
            {
                converterToStrings.Add(activity.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<ActivityInput> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var activityInput in list)
            {
                converterToStrings.Add(activityInput.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Role> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var role in list)
            {
                converterToStrings.Add(role.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<JobTitle> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var jobTitle in list)
            {
                converterToStrings.Add(jobTitle.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Patient> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var patient in list)
            {
                converterToStrings.Add(patient.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        public static string GenerateDropDown(List<Employee> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var employee in list)
            {
                converterToStrings.Add(employee.FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }

        /*
        public static string GenerateDropDown(List<object> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var element in list)
            {
                if(element.GetType() == typeof(Medicine))
                    converterToStrings.Add(((Medicine)element).FullNameWithCode);
                if (element.GetType() == typeof(Contractor))
                    converterToStrings.Add(((Contractor)element).FullNameWithCode);
                if (element.GetType() == typeof(Disease))
                    converterToStrings.Add(((Disease)element).FullNameWithCode);
                if (element.GetType() == typeof(Relationship))
                    converterToStrings.Add(((Relationship)element).FullNameWithCode);
                if (element.GetType() == typeof(Service))
                    converterToStrings.Add(((Service)element).FullNameWithCode);
                if (element.GetType() == typeof(Activity))
                    converterToStrings.Add(((Activity)element).FullNameWithCode);
                if (element.GetType() == typeof(ActivityInput))
                    converterToStrings.Add(((ActivityInput)element).FullNameWithCode);
                if (element.GetType() == typeof(Role))
                    converterToStrings.Add(((Role)element).FullNameWithCode);
                if (element.GetType() == typeof(JobTitle))
                    converterToStrings.Add(((JobTitle)element).FullNameWithCode);
                if (element.GetType() == typeof(Patient))
                    converterToStrings.Add(((Patient)element).FullNameWithCode);
                if (element.GetType() == typeof(Employee))
                    converterToStrings.Add(((Employee)element).FullNameWithCode);
            }
            return GenerateDropDown(converterToStrings, id, multiChoice);
        }
        */

        public static string GenerateDropDown(List<string> list, string id, bool multiChoice = true)
        {
            string str = "<script>\n" +
                         "$(function() {\n" +
                         "var availableTags = [\n";


            for (var index = 0; index < list.Count; index++)
            {
                str += "\"" + list[index] + "\"";

                if (index < list.Count - 1)
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
                       "$(\"#" + id + "\").autocomplete({\n" +
                       "source: availableTags\n" +
                       "});" +
                       "} );" +
                       "</script>";
            }
            return str;
        }

        #endregion
    }
}