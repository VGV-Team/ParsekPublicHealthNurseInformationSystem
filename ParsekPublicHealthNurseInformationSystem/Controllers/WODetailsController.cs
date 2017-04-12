using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{

    [AuthorizationFilter(Role.RoleEnum.Employee)]
    [AuthorizationFilter(Employee.JobTitle.Doctor, Employee.JobTitle.Head, Employee.JobTitle.HealthNurse)]
    public class WODetailsController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        
        public ActionResult Index(int? workOrderId)
        {
            //workOrderId = 2;

            if (workOrderId == null)
            {
                return Redirect("/");
            }

            WorkOrderDetailsViewModel vm = new WorkOrderDetailsViewModel();

            Models.WorkOrder wo = DB.WorkOrders.Find(workOrderId);

            if (wo != null)
            {

                vm.ActivityTitle = wo.Activity.ActivityTitle;
                vm.ContractorName = wo.Contractor.DisplayName;
                vm.Disease = "/"; // TODO LATER STORY
                vm.EnterBloodSample = wo.Activity.RequiresBloodSample;
                if (vm.EnterBloodSample)
                {
                    vm.BloodVialColor = wo.PatientWorkOrders.First().BloodSamples.First().BloodVialColor;
                    vm.BloodVialCount = wo.PatientWorkOrders.First().BloodSamples.First().BloodVialCount;
                }
                else
                {
                    vm.BloodVialColor = "";
                    vm.BloodVialCount = 0;
                }
                vm.EnterMedicine = wo.Activity.RequiresMedicine;
                if (vm.EnterMedicine)
                {
                    PatientWorkOrder pwo = wo.PatientWorkOrders.First();
                    vm.Medicine = new List<string>();
                    for (int i = 0; i < pwo.MedicineWorkOrders.Count; i++)
                    { 
                        vm.Medicine.Add(pwo.MedicineWorkOrders.ElementAt(i).Medicine.FullNameWithCode);
                    }
                }
                vm.Nurse = wo.Nurse.FullNameWithCode;
                if (wo.NurseReplacement != null) vm.NurseReplacement = wo.NurseReplacement.FullNameWithCode;
                else vm.NurseReplacement = "/";
                vm.Patients = new List<string>();
                for (int i = 0; i < wo.PatientWorkOrders.Count; i++)
                {
                    vm.Patients.Add(wo.PatientWorkOrders.ElementAt(i).Patient.FullNameWithCode);
                }
                vm.Supervisor = wo.Issuer.FullNameWithCode;
                vm.Visits = new List<string>();

                List<Visit> Visits = wo.Visits.OrderBy(visi => visi.DateConfirmed).ToList();

                vm.VisitIds = new List<int>();
                for (int i = 0; i < wo.Visits.Count; i++)
                {
                    Visit v = Visits.ElementAt(i);
                    string visitString = "";
                    if (v.Confirmed && v.DateConfirmed.Date < DateTime.Now.Date)// TODO ADD UNCOMPLETED VISITS LATER (when we have a variable for that)
                    {
                        visitString = v.DateConfirmed.ToString("dd. MM. yyyy") + "(opravljeno), ";
                    }
                    else if (!v.Confirmed && v.Date.Date < DateTime.Now.Date)
                    {
                        visitString = v.Date.ToString("dd. MM. yyyy") + " (neopravljeno), ";
                    }
                    else
                    {
                        visitString = v.DateConfirmed.ToString("dd. MM. yyyy") + " (predvideno), ";
                    }
                    if (v.Mandatory)
                    {
                        visitString += "obvezen, ";
                    }
                    else
                    {
                        visitString += "okviren, ";
                    }

                    if (wo.Activity.PreventiveVisit)
                    {
                        vm.PreventiveActivity = "Da";
                    }
                    else
                    {
                        vm.PreventiveActivity = "Ne";
                    }

                    vm.Visits.Add(visitString);
                    vm.VisitIds.Add(v.VisitId);
                }

            }
            else
            {
                return Redirect("/");
            }


            return View("Index", vm);
        }
    }
}