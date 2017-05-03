using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public static class Globals
    {
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

        public static string GenerateDropDown(List<Medicine> list, string id, bool multiChoice = true)
        {
            List<string> converterToStrings = new List<string>();
            foreach (var medicine in list)
            {
                converterToStrings.Add(medicine.FullNameWithCode);
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
    }
}