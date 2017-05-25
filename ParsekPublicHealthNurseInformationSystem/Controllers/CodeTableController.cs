using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
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

        public ActionResult Edit(CodeTableViewModel.CodeCategory category, int? id)
        {
            CodeTableViewModel ctvm = new CodeTableViewModel();
            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    if (id == null)
                        ctvm.Medicine = new Medicine();
                    else
                        ctvm.Medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    if (id == null)
                        ctvm.Contractor = new Contractor();
                    else
                        ctvm.Contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id); // TODO: add possible post offices!!
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    if (id == null)
                        ctvm.Disease = new Disease();
                    else
                        ctvm.Disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    if (id == null)
                        ctvm.Relationship = new Relationship();
                    else
                        ctvm.Relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    if (id == null)
                        ctvm.Service = new Service();
                    else
                        ctvm.Service = DB.Services.FirstOrDefault(x => x.ServiceId == id);
                    break;
            }
            return View("Index", ctvm);
        }

        public ActionResult Delete(CodeTableViewModel.CodeCategory category, int id)
        {
            CodeTableViewModel ctvm = new CodeTableViewModel();
            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    ctvm.SelectedCodeCategory = CodeTableViewModel.CodeCategory.Medicine;
                    Medicine medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == id);
                    if(medicine != null)
                        DB.Medicines.Remove(medicine);
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    ctvm.SelectedCodeCategory = CodeTableViewModel.CodeCategory.Contractor;
                    Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    if (contractor != null)
                        DB.Contractors.Remove(contractor);
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    ctvm.SelectedCodeCategory = CodeTableViewModel.CodeCategory.Disease;
                    Disease disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    if (disease != null)
                        DB.Diseases.Remove(disease);
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    ctvm.SelectedCodeCategory = CodeTableViewModel.CodeCategory.Relationship;
                    Relationship relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    if (relationship != null)
                        DB.Relationships.Remove(relationship);
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    ctvm.SelectedCodeCategory = CodeTableViewModel.CodeCategory.Service;
                    Service service = DB.Services.FirstOrDefault(x => x.ServiceId == id);
                    if (service != null)
                        DB.Services.Remove(service);
                    break;
            }
            DB.SaveChanges();
            return RedirectToAction("Index", ctvm);
        }

        public ActionResult Save(CodeTableViewModel.CodeCategory category, CodeTableViewModel ctvm)
        {
            if (ctvm == null)
                return RedirectToAction("Index");

            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    if (ctvm.Medicine != null)
                    {
                        Medicine medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == ctvm.Medicine.MedicineId);
                        if (medicine == null)
                        {
                            DB.Medicines.Add(ctvm.Medicine);
                        }
                        else
                        {
                            medicine.Title = ctvm.Medicine.Title;
                            medicine.Code = ctvm.Medicine.Code;
                        }
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    if (ctvm.Contractor != null)
                    {
                        Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == ctvm.Contractor.ContractorId);
                        if (contractor == null)
                        {
                            DB.Contractors.Add(ctvm.Contractor);
                        }
                        else
                        {
                            contractor.Number = ctvm.Contractor.Number;
                            contractor.Title = ctvm.Contractor.Title;
                            contractor.Address = ctvm.Contractor.Address;
                            contractor.PostOffice = DB.PostOffices.FirstOrDefault(x => x.PostOfficeId == ctvm.Contractor.PostOffice.PostOfficeId);
                        }
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    if (ctvm.Disease != null)
                    {
                        Disease disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == ctvm.Disease.DiseaseId);
                        if (disease == null)
                        {
                            DB.Diseases.Add(ctvm.Disease);
                        }
                        else
                        {
                            disease.Code = ctvm.Disease.Code;
                            disease.Description = ctvm.Disease.Description;
                        }
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    if (ctvm.Relationship != null)
                    {
                        Relationship relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == ctvm.Relationship.RelationshipId);
                        if (relationship == null)
                        {
                            DB.Relationships.Add(ctvm.Relationship);
                        }
                        else
                        {
                            relationship.Name = ctvm.Relationship.Name;
                        }
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    if (ctvm.Service != null)
                    {
                        Service service = DB.Services.FirstOrDefault(x => x.ServiceId == ctvm.Service.ServiceId);
                        if (service == null)
                        {
                            DB.Services.Add(ctvm.Service);
                        }
                        else
                        {
                            service.ServiceCode = ctvm.Service.ServiceCode;
                            service.ServiceTitle = ctvm.Service.ServiceTitle;
                            service.PreventiveVisit = ctvm.Service.PreventiveVisit;
                            service.RequiresMedicine = ctvm.Service.RequiresMedicine;
                            service.RequiresBloodSample = ctvm.Service.RequiresBloodSample;
                            service.RequiresPatients = ctvm.Service.RequiresPatients;
                        }
                        DB.SaveChanges();
                    }
                    break;
            }
            DB.SaveChanges();
            return RedirectToAction("Index", ctvm);
        }
    }
}