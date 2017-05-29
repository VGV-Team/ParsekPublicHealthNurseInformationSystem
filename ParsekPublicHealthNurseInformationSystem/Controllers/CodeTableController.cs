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
            CodeTableViewModel.CodeCategory? category = ctvm.Category;
            ctvm = new CodeTableViewModel();

            switch (category)
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
                case CodeTableViewModel.CodeCategory.Activity:
                    ctvm.Activities = DB.Activities.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ctvm.ActivityInputs = DB.ActivityInputs.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    ctvm.Roles = DB.Roles.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    ctvm.JobTitles = DB.JobTitles.ToList();
                    break;
            }
            return View("Index", ctvm);
        }

        public ActionResult SelectById(CodeTableViewModel.CodeCategory category, string SelectedId)
        {
            int[] ids = Globals.GetIdsFromString(SelectedId);
            if (ids == null || ids.Length != 1)
            {
                CodeTableViewModel ctvm = new CodeTableViewModel();
                ctvm.Category = category;
                return RedirectToAction("Index", new { ctvm = ctvm});
            }
            
            return RedirectToAction("Edit", new { category = category, id = ids.FirstOrDefault() });
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
                        ctvm.Contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    ctvm.PostOffices = DB.PostOffices.ToList();
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
                case CodeTableViewModel.CodeCategory.Activity:
                    if (id == null)
                        ctvm.Activity = new Activity();
                    else
                        ctvm.Activity = DB.Activities.FirstOrDefault(x => x.ActivityId == id);
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    if (id == null)
                        ctvm.ActivityInput = new ActivityInput();
                    else
                        ctvm.ActivityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    if (id == null)
                        ctvm.Role = new Role();
                    else
                        ctvm.Role = DB.Roles.FirstOrDefault(x => x.RoleId == id);
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    if (id == null)
                        ctvm.JobTitle = new JobTitle();
                    else
                        ctvm.JobTitle = DB.JobTitles.FirstOrDefault(x => x.JobTitleId == id);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
            return View("Edit", ctvm);
        }

        public ActionResult Delete(CodeTableViewModel.CodeCategory category, int id)
        {
            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    Medicine medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == id);
                    if (medicine != null)
                        medicine.Active = false;
                        //DB.Medicines.Remove(medicine);
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    if (contractor != null)
                        contractor.Active = false;
                        //DB.Contractors.Remove(contractor);
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    Disease disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    if (disease != null)
                        disease.Active = false;
                        //DB.Diseases.Remove(disease);
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    Relationship relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    if (relationship != null)
                        relationship.Active = false;
                        //DB.Relationships.Remove(relationship);
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    Service service = DB.Services.FirstOrDefault(x => x.ServiceId == id);
                    if (service != null)
                        service.Active = false;
                        //DB.Services.Remove(service);
                    break;
                case CodeTableViewModel.CodeCategory.Activity:
                    Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == id);
                    if (activity != null)
                        activity.Active = false;
                        //DB.Activities.Remove(activity);
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ActivityInput activityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == id);
                    if (activityInput != null)
                        activityInput.Active = false;
                        //DB.ActivityInputs.Remove(activityInput);
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    Role role = DB.Roles.FirstOrDefault(x => x.RoleId == id);
                    if (role != null)
                        role.Active = false;
                        //DB.Roles.Remove(role);
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    JobTitle jobTitle = DB.JobTitles.FirstOrDefault(x => x.JobTitleId == id);
                    if (jobTitle != null)
                        jobTitle.Active = false;
                        //DB.JobTitles.Remove(jobTitle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
            DB.SaveChanges();
            CodeTableViewModel ctvm = new CodeTableViewModel();
            ctvm.Category = category;
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
                            ctvm.Contractor.PostOffice = DB.PostOffices.FirstOrDefault(x => x.PostOfficeId == ctvm.Contractor.PostOffice.PostOfficeId);
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
                case CodeTableViewModel.CodeCategory.Activity:
                    Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == ctvm.Activity.ActivityId);
                    if (activity == null)
                    {
                        DB.Activities.Add(ctvm.Activity);
                    }
                    else
                    {
                        activity.ActivityCode = ctvm.Activity.ActivityCode;
                        activity.ActivityTitle = ctvm.Activity.ActivityTitle;
                        //activity.ActivityInputFor = ctvm.Activity.ActivityInputFor;
                    }
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ActivityInput activityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == ctvm.ActivityInput.ActivityInputId);
                    if (activityInput == null)
                    {
                        DB.ActivityInputs.Add(ctvm.ActivityInput);
                    }
                    else
                    {
                        activityInput.Title = ctvm.ActivityInput.Title;
                        activityInput.InputType = ctvm.ActivityInput.InputType;
                        activityInput.PossibleValues = ctvm.ActivityInput.PossibleValues;
                    }
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    Role role = DB.Roles.FirstOrDefault(x => x.RoleId == ctvm.Role.RoleId);
                    if (role == null)
                    {
                        DB.Roles.Add(ctvm.Role);
                    }
                    else
                    {
                        role.Title = ctvm.Role.Title;
                    }
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    JobTitle jobTitle = DB.JobTitles.FirstOrDefault(x => x.JobTitleId == ctvm.JobTitle.JobTitleId);
                    if (jobTitle == null)
                    {
                        DB.JobTitles.Add(ctvm.JobTitle);
                    }
                    else
                    {
                        jobTitle.Title = ctvm.JobTitle.Title;
                    }
                    DB.SaveChanges();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
            DB.SaveChanges();
            ctvm = new CodeTableViewModel();
            ctvm.Category = category;
            return RedirectToAction("Index", ctvm);
        }
    }
}