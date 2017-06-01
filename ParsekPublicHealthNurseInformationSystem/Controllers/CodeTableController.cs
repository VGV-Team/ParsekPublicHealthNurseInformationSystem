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
            CodeTableViewModel.CodeCategory? category = ctvm?.Category;
            ctvm = new CodeTableViewModel();
            if(category != null)
                ctvm.Category = category.Value;
            ctvm.Deleted = new List<bool>();

            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    ctvm.Medicines = DB.Medicines.ToList();
                    for (int i = 0; i < ctvm.Medicines.Count; i++)
                    {
                        if (ctvm.Medicines[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    ctvm.Contractors = DB.Contractors.ToList();
                    for (int i = 0; i < ctvm.Contractors.Count; i++)
                    {
                        if (ctvm.Contractors[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    ctvm.Diseases = DB.Diseases.ToList();
                    for (int i = 0; i < ctvm.Diseases.Count; i++)
                    {
                        if (ctvm.Diseases[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    ctvm.Relationships = DB.Relationships.ToList();
                    for (int i = 0; i < ctvm.Relationships.Count; i++)
                    {
                        if (ctvm.Relationships[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    ctvm.Services = DB.Services.ToList();
                    for (int i = 0; i < ctvm.Services.Count; i++)
                    {
                        if (ctvm.Services[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Activity:
                    ctvm.Activities = DB.Activities.ToList();
                    for (int i = 0; i < ctvm.Activities.Count; i++)
                    {
                        if (ctvm.Activities[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ctvm.ActivityInputs = DB.ActivityInputs.ToList();
                    for (int i = 0; i < ctvm.ActivityInputs.Count; i++)
                    {
                        if (ctvm.ActivityInputs[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    ctvm.Roles = DB.Roles.ToList();
                    for (int i = 0; i < ctvm.Roles.Count; i++)
                    {
                        if (ctvm.Roles[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    ctvm.JobTitles = DB.JobTitles.ToList();
                    for (int i = 0; i < ctvm.JobTitles.Count; i++)
                    {
                        if (ctvm.JobTitles[i].Active) ctvm.Deleted.Add(false);
                        else ctvm.Deleted.Add(true);
                    }
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
            if(id == null)
                ctvm.IsNew = true;

            switch (category)
            {
                case CodeTableViewModel.CodeCategory.Medicine:
                    if (id == null)
                    {
                        ctvm.Medicine = new Medicine();
                        ctvm.Medicine.MedicineId = -1;
                    }
                    else
                        ctvm.Medicine = DB.Medicines.FirstOrDefault(x => x.MedicineId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    if (id == null)
                    {
                        ctvm.Contractor = new Contractor();
                        ctvm.Contractor.ContractorId = -1;
                    }
                    else
                        ctvm.Contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    ctvm.PostOffices = DB.PostOffices.ToList();
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    if (id == null)
                    {
                        ctvm.Disease = new Disease();
                        ctvm.Disease.DiseaseId = -1;
                    }
                    else
                        ctvm.Disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    if (id == null)
                    {
                        ctvm.Relationship = new Relationship();
                        ctvm.Relationship.RelationshipId = -1;
                    }
                    else
                        ctvm.Relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    if (id == null)
                    {
                        ctvm.Service = new Service();
                        ctvm.Service.ServiceId = -1;
                    }
                    else
                        ctvm.Service = DB.Services.FirstOrDefault(x => x.ServiceId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Activity:
                    if (id == null)
                    {
                        ctvm.Activity = new Activity();
                        ctvm.Activity.ActivityId = -1;
                    }
                    else
                        ctvm.Activity = DB.Activities.FirstOrDefault(x => x.ActivityId == id);
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    if (id == null)
                    {
                        ctvm.ActivityInput = new ActivityInput();
                        ctvm.ActivityInput.ActivityInputId = -1;
                    }
                    else
                        ctvm.ActivityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == id);
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    if (id == null)
                    {
                        ctvm.Role = new Role();
                        ctvm.Role.RoleId = -1;
                    }
                    else
                        ctvm.Role = DB.Roles.FirstOrDefault(x => x.RoleId == id);
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    if (id == null)
                    {
                        ctvm.JobTitle = new JobTitle();
                        ctvm.JobTitle.JobTitleId = -1;
                    }
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
                        medicine.Active = !medicine.Active;
                        //DB.Medicines.Remove(medicine);
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == id);
                    if (contractor != null)
                        contractor.Active = !contractor.Active;
                        //DB.Contractors.Remove(contractor);
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    Disease disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == id);
                    if (disease != null)
                        disease.Active = !disease.Active;
                        //DB.Diseases.Remove(disease);
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    Relationship relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == id);
                    if (relationship != null)
                        relationship.Active = !relationship.Active;
                        //DB.Relationships.Remove(relationship);
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    Service service = DB.Services.FirstOrDefault(x => x.ServiceId == id);
                    if (service != null)
                        service.Active = !service.Active;
                        //DB.Services.Remove(service);
                    break;
                case CodeTableViewModel.CodeCategory.Activity:
                    Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == id);
                    if (activity != null)
                        activity.Active = !activity.Active;
                        //DB.Activities.Remove(activity);
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ActivityInput activityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == id);
                    if (activityInput != null)
                        activityInput.Active = !activityInput.Active;
                        //DB.ActivityInputs.Remove(activityInput);
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    Role role = DB.Roles.FirstOrDefault(x => x.RoleId == id);
                    if (role != null)
                        role.Active = !role.Active;
                        //DB.Roles.Remove(role);
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    JobTitle jobTitle = DB.JobTitles.FirstOrDefault(x => x.JobTitleId == id);
                    if (jobTitle != null)
                        jobTitle.Active = !jobTitle.Active;
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
                            if(DB.Medicines.Count(x => x.Code == ctvm.Medicine.Code)>0)
                                return View("Edit", ctvm);
                            medicine = new Medicine();
                            DB.Medicines.Add(medicine);
                        }
                        medicine.Active = true;
                        medicine.Title = ctvm.Medicine.Title;
                        medicine.Code = ctvm.Medicine.Code;
                        medicine.Cost = ctvm.Medicine.Cost;
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Contractor:
                    if (ctvm.Contractor != null)
                    {
                        Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == ctvm.Contractor.ContractorId);
                        if (contractor == null)
                        {
                            if (DB.Contractors.Count(x => x.Number == ctvm.Contractor.Number) > 0)
                            {
                                ctvm.PostOffices = DB.PostOffices.ToList();
                                return View("Edit", ctvm);
                            }
                            contractor = new Contractor();
                            DB.Contractors.Add(contractor);
                        }
                        contractor.Active = true;
                        contractor.Number = ctvm.Contractor.Number;
                        contractor.Title = ctvm.Contractor.Title;
                        contractor.Address = ctvm.Contractor.Address;
                        contractor.PostOffice = DB.PostOffices.FirstOrDefault(x => x.PostOfficeId == ctvm.Contractor.PostOffice.PostOfficeId);
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Disease:
                    if (ctvm.Disease != null)
                    {
                        Disease disease = DB.Diseases.FirstOrDefault(x => x.DiseaseId == ctvm.Disease.DiseaseId);
                        if (disease == null)
                        {
                            if (DB.Diseases.Count(x => x.Code == ctvm.Disease.Code) > 0)
                                return View("Edit", ctvm);
                            disease = new Disease();
                            DB.Diseases.Add(disease);
                        }
                        disease.Active = true;
                        disease.Code = ctvm.Disease.Code;
                        disease.Description = ctvm.Disease.Description;
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Relationship:
                    if (ctvm.Relationship != null)
                    {
                        Relationship relationship = DB.Relationships.FirstOrDefault(x => x.RelationshipId == ctvm.Relationship.RelationshipId);
                        if (relationship == null)
                        {
                            relationship = new Relationship();
                            DB.Relationships.Add(relationship);
                        }
                        relationship.Name = ctvm.Relationship.Name;
                        relationship.Active = true;
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Service:
                    if (ctvm.Service != null)
                    {
                        Service service = DB.Services.FirstOrDefault(x => x.ServiceId == ctvm.Service.ServiceId);
                        if (service == null)
                        {
                            if (DB.Services.Count(x => x.ServiceCode == ctvm.Service.ServiceCode) > 0)
                                return View("Edit", ctvm);
                            service = new Service();
                            DB.Services.Add(service);
                        }
                        service.Active = true;
                        service.ServiceCode = ctvm.Service.ServiceCode;
                        service.ServiceTitle = ctvm.Service.ServiceTitle;
                        service.PreventiveVisit = ctvm.Service.PreventiveVisit;
                        service.RequiresMedicine = ctvm.Service.RequiresMedicine;
                        service.RequiresBloodSample = ctvm.Service.RequiresBloodSample;
                        service.RequiresPatients = ctvm.Service.RequiresPatients;
                        service.Cost = ctvm.Service.Cost;
                        DB.SaveChanges();
                    }
                    break;
                case CodeTableViewModel.CodeCategory.Activity:
                    Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == ctvm.Activity.ActivityId);
                    if (activity == null)
                    {
                        if (DB.Activities.Count(x => x.ActivityCode == ctvm.Activity.ActivityCode) > 0)
                            return View("Edit", ctvm);
                        activity = new Activity();
                        DB.Activities.Add(activity);
                    }
                    activity.Active = true;
                    activity.ActivityCode = ctvm.Activity.ActivityCode;
                    activity.ActivityTitle = ctvm.Activity.ActivityTitle;
                    //activity.ActivityInputFor = ctvm.Activity.ActivityInputFor;
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.ActivityInput:
                    ActivityInput activityInput = DB.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == ctvm.ActivityInput.ActivityInputId);
                    if (activityInput == null)
                    {
                        activityInput = new ActivityInput();
                        DB.ActivityInputs.Add(activityInput);
                    }
                    activityInput.Active = true;
                    activityInput.Title = ctvm.ActivityInput.Title;
                    activityInput.InputType = ctvm.ActivityInput.InputType;
                    activityInput.PossibleValues = ctvm.ActivityInput.PossibleValues;
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.Role:
                    Role role = DB.Roles.FirstOrDefault(x => x.RoleId == ctvm.Role.RoleId);
                    if (role == null)
                    {
                        role = new Role();
                        DB.Roles.Add(role);
                    }
                    role.Title = ctvm.Role.Title;
                    DB.SaveChanges();
                    break;
                case CodeTableViewModel.CodeCategory.JobTitle:
                    JobTitle jobTitle = DB.JobTitles.FirstOrDefault(x => x.JobTitleId == ctvm.JobTitle.JobTitleId);
                    if (jobTitle == null)
                    {
                        jobTitle = new JobTitle();
                        DB.JobTitles.Add(jobTitle);
                    }
                    jobTitle.Active = true;
                    jobTitle.Title = ctvm.JobTitle.Title;
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