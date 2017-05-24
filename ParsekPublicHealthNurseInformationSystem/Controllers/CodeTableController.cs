using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels.NurseReplacement;
using ParsekPublicHealthNurseInformationSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class CodeTableController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: CodeTable
        public ActionResult Index(CodeTableViewModel ctvm)
        {
            if (ctvm == null)
            {
                ctvm = new CodeTableViewModel();
                return View("Index", ctvm);
            }

            switch (ctvm.SelectedCodeCategory)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    ctvm.Medicines = DB.Medicines.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    ctvm.Contractors = DB.Contractors.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    ctvm.Diseases = DB.Diseases.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    ctvm.Relationships = DB.Relationships.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    ctvm.Services = DB.Services.ToList();
                    break;
                default:
                    return View("Index", ctvm);
            }

            return View("Index", ctvm);
        }

        public ActionResult Edit(CodeTableViewModel.CodeCategory category, int id)
        {
            CodeTableViewModel ctvm = new CodeTableViewModel();
            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    ctvm.Medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == id);
                    if(ctvm.Medicine == null)
                        return RedirectToAction("Index");
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    ctvm.Contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    if (ctvm.Contractor == null)
                        return RedirectToAction("Index");
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    ctvm.Disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    if (ctvm.Disease == null)
                        return RedirectToAction("Index");
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    ctvm.Relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    if (ctvm.Relationship == null)
                        return RedirectToAction("Index");
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    return RedirectToAction("Index");
            }

            return View("Edit", ctvm);
        }

        public ActionResult Delete(CodeTableViewModel.CodeCategory category, int id)
        {
            return null;
        }

        public ActionResult New(CodeTableViewModel.CodeCategory category)
        {
            return null;
        }
    }
}