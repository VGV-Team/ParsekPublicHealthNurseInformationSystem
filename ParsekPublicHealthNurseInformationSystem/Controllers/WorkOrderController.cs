using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using WebGrease.Css.Ast.Selectors;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.RoleEnum.Employee)]
    [AuthorizationFilter(Employee.JobTitle.Doctor, Employee.JobTitle.Head)]
    public class WorkOrderController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: WorkOrder
        public ActionResult Index()
        {
            Session["workorder"] = null; // Summaryviewmodel
            Session["workorder_DB"] = null; // workorder model

            User currentUser = (User) Session["user"];
            bool isDoctor = currentUser.Employee.Title == Employee.JobTitle.Doctor;

            WorkOrderVisitTypeViewModel wovtvm = new WorkOrderVisitTypeViewModel();
            wovtvm.CreateWorkOrderVisitTypeViewModel(isDoctor);

            return View("Index", wovtvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorkOrder(WorkOrderVisitTypeViewModel wovtvm)
        {
            User currentUser = (User)Session["user"];
            bool isDoctor = currentUser.Employee.Title == Employee.JobTitle.Doctor;

            Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == wovtvm.SelectedActivityId);
            if (activity == null || !activity.PreventiveVisit && !isDoctor)
            {
                wovtvm.CreateWorkOrderVisitTypeViewModel(isDoctor);
                return View("Index", wovtvm);
            }

            WorkOrderViewModel wovm = new WorkOrderViewModel();
            wovm.SelectedActivityId = wovtvm.SelectedActivityId;

            wovm.EnterMedicine = activity.RequiresMedicine;
            wovm.EnterBloodSample = activity.RequiresBloodSample;

            return View("Create", wovm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitWorkOrder(WorkOrderViewModel wovm)
        {
            if (wovm.PatientIds.IsNullOrWhiteSpace() ||
                wovm.DateTimeOfFirstVisit < DateTime.Now ||
                wovm.DateTimeOfFirstVisit > DateTime.Now.AddMonths(6) ||
                wovm.MultipleVisits && (
                    wovm.TimeType == 0 ||
                    wovm.NumberOfVisits < 1 || wovm.NumberOfVisits > 10 ||
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame &&
                        (wovm.TimeFrame > DateTime.Now.AddMonths(6) ||
                         wovm.TimeFrame < DateTime.Now ||
                         wovm.TimeFrame < wovm.DateTimeOfFirstVisit ||
                         (wovm.TimeFrame - wovm.DateTimeOfFirstVisit).Days < (wovm.NumberOfVisits-1) 
                         ) ||
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval &&
                    (wovm.TimeInterval > 30 || wovm.TimeInterval < 1)) ||
                wovm.EnterMedicine && wovm.MedicineIds.IsNullOrWhiteSpace() ||
                wovm.EnterBloodSample && 
                    (wovm.BloodVialColor.IsNullOrWhiteSpace() || wovm.BloodVialCount < 1)
            )
            {
                return View("Create", wovm);
            }
            else
            {
                

                Session["SavedWorkOrder"] = null;
                Session["SavedWorkOrderSummary"] = null;

                WorkOrderDataViewModel wodvm = new WorkOrderDataViewModel();
                wodvm.PatientIds = new List<int>();
                wodvm.SelectedActivityId = wovm.SelectedActivityId;
                wodvm.DateTimeOfFirstVisit = wovm.DateTimeOfFirstVisit;
                wodvm.MandatoryFirstVisit = wovm.MandatoryFirstVisit;
                wodvm.NumberOfVisits = wovm.NumberOfVisits;
                wodvm.MultipleVisits = wovm.MultipleVisits;
                wodvm.TimeFrame = wovm.TimeFrame;
                wodvm.TimeInterval = wovm.TimeInterval;
                wodvm.TimeType = wovm.TimeType;
                wodvm.EnterMedicine = wovm.EnterMedicine;
                wodvm.MedicineIds = wovm.EnterMedicine ? GetIdsFromString(wovm.MedicineIds).ToList() : null;
                wodvm.EnterBloodSample = wovm.EnterBloodSample;
                wodvm.BloodVialColor = wovm.EnterBloodSample ? wovm.BloodVialColor : null;
                wodvm.BloodVialCount = wovm.EnterBloodSample ? wovm.BloodVialCount : -1;
                
                wodvm.SupervisorId = ((User)Session["user"]).Employee.EmployeeId;
                Session["SavedWorkOrder"] = wodvm;


                WorkOrderSummaryViewModel wosvm = new WorkOrderSummaryViewModel();
                wosvm.Patients = new List<string>();
                wosvm.Supervisor = ((User)Session["user"]).Employee.FullName;
                wosvm.ActivityTitle = DB.Activities.FirstOrDefault(x => x.ActivityId == wovm.SelectedActivityId).ActivityTitle;
                wosvm.DateTimeOfFirstVisit = wovm.DateTimeOfFirstVisit;
                wosvm.MandatoryFirstVisit = wovm.MandatoryFirstVisit;
                wosvm.NumberOfVisits = wovm.NumberOfVisits;
                wosvm.MultipleVisits = wovm.MultipleVisits;
                wosvm.TimeFrame = wovm.TimeFrame;
                wosvm.TimeInterval = wovm.TimeInterval;
                wosvm.TimeType = wovm.TimeType;

                wosvm.EnterBloodSample = wovm.EnterBloodSample;
                wosvm.BloodVialColor = wovm.EnterBloodSample ? wovm.BloodVialColor : null;
                wosvm.BloodVialCount = wovm.EnterBloodSample ? wovm.BloodVialCount : -1;

                wosvm.EnterMedicine = wovm.EnterMedicine;
                if (wovm.EnterMedicine)
                {
                    wosvm.Medicine = new List<string>();
                    int[] medicineIds = GetIdsFromString(wovm.MedicineIds);
                    foreach (var medicine in DB.Medicines.Where(x => medicineIds.Contains(x.MedicineId)).ToList())
                    {
                        if (medicine != null)
                            wosvm.Medicine.Add(medicine.FullName);
                    }
                }

                int[] ids = GetIdsFromString(wovm.PatientIds);
                List<int> districts = new List<int>();
                foreach (var id in ids)
                {
                    Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                    if (patient != null)
                    {
                        districts.Add(patient.District.DistrictId);
                        wodvm.PatientIds.Add(patient.PatientId);
                        wosvm.Patients.Add(patient.FullName);
                    }
                }
                districts = districts.Distinct().ToList();
                if (wodvm.PatientIds.Count == 0)
                {
                    // TODO: message for no patients

                    Session["SavedWorkOrder"] = null;
                    Session["SavedWorkOrderSummary"] = null;
                    return View("Create", wovm);
                }

                Session["SavedWorkOrderSummary"] = wosvm;

                WorkOrderNurseSelectionViewModel wonsvm = new WorkOrderNurseSelectionViewModel();
                wonsvm.CreateWorkOrderNurseSelectionViewModel(districts);
                
                return View("NurseSelection", wonsvm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectNurseWorkOrder(WorkOrderNurseSelectionViewModel wonsvm)
        {
            Employee selectedNurse = DB.Employees.FirstOrDefault(x => x.EmployeeId == wonsvm.SelectedNurseId);
            Employee selectedNurseReplacement = DB.Employees.FirstOrDefault(x => x.EmployeeId == wonsvm.SelectedNurseReplacementId);

            if (selectedNurse == null)
            {
                wonsvm.CreateWorkOrderNurseSelectionViewModel();
                return View("NurseSelection", wonsvm);
            }

            WorkOrderDataViewModel wodvm = (WorkOrderDataViewModel)Session["SavedWorkOrder"];
            WorkOrderSummaryViewModel wosvm = (WorkOrderSummaryViewModel)Session["SavedWorkOrderSummary"];

            if (wodvm == null || wosvm == null)
            {
                return RedirectToAction("Index", "Home");
            }

            wodvm.SelectedNurseId = selectedNurse.EmployeeId;
            wodvm.SelectedNurseReplacementId = selectedNurseReplacement?.EmployeeId;

            wosvm.Nurse = selectedNurse.FullName;
            wosvm.NurseReplacement = selectedNurseReplacement != null ? selectedNurseReplacement.FullName : "/";
            Session["SavedWorkOrderSummary"] = wosvm;
            Session["SavedWorkOrder"] = wodvm;

            return View("Summary", wosvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit()
        {
            WorkOrderDataViewModel wodvm = (WorkOrderDataViewModel)Session["SavedWorkOrder"];

            Employee employee = DB.Employees.FirstOrDefault(x => x.EmployeeId == wodvm.SupervisorId);
            Contractor contractor = employee.Contractor;

            WorkOrder workOrder = new WorkOrder();
            workOrder.Contractor = contractor;
            workOrder.Issuer = employee;
            workOrder.Activity = DB.Activities.FirstOrDefault(x => x.ActivityId == wodvm.SelectedActivityId);
            workOrder.Name = workOrder.Activity.ActivityTitle;
            workOrder.Nurse = DB.Employees.FirstOrDefault(x => x.EmployeeId == wodvm.SelectedNurseId);
            workOrder.NurseReplacement = wodvm.SelectedNurseReplacementId == null ? DB.Employees.FirstOrDefault(x => x.EmployeeId == wodvm.SelectedNurseReplacementId) : null;

            Visit visit = new Visit();
            visit.Date = wodvm.DateTimeOfFirstVisit;
            visit.DateConfirmed = wodvm.DateTimeOfFirstVisit;
            visit.Mandatory = wodvm.MandatoryFirstVisit;
            visit.WorkOrder = workOrder;

            // Check for single or multiple visits.
            if (wodvm.MultipleVisits && wodvm.NumberOfVisits > 1)
            {
                int timeFrame = 1;
                bool mandatoryvisit = wodvm.MandatoryFirstVisit;
                if (wodvm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame)
                {
                    timeFrame = (wodvm.TimeFrame - wodvm.DateTimeOfFirstVisit).Days / (wodvm.NumberOfVisits - 1);
                    mandatoryvisit = false;
                }
                else if (wodvm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval)
                {
                    timeFrame = wodvm.TimeInterval;
                }

                for (int i = 1; i < wodvm.NumberOfVisits; i++)
                {
                    Visit vis = new Visit();
                    vis.Date = wodvm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                    vis.DateConfirmed = wodvm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                    vis.Mandatory = mandatoryvisit;
                    vis.WorkOrder = workOrder;
                    DB.Visits.Add(vis);
                }
            }

            // Get all used medicine
            List<Medicine> medicines = new List<Medicine>();
            if (wodvm.EnterMedicine)
            {
                medicines = DB.Medicines.Where(x => wodvm.MedicineIds.Contains(x.MedicineId)).ToList();
            }

            foreach (var id in wodvm.PatientIds)
            {
                Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                if (patient != null)
                {
                    PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                    patientWorkOrder.WorkOrder = workOrder;
                    patientWorkOrder.Patient = patient;

                    foreach (var medicine in medicines)
                    {
                        MedicineWorkOrder medicineWorkOrder = new MedicineWorkOrder();
                        medicineWorkOrder.Medicine = medicine;
                        medicineWorkOrder.PatientWorkOrder = patientWorkOrder;
                        DB.MedicineWorkOrders.Add(medicineWorkOrder);
                    }

                    if (wodvm.EnterBloodSample)
                    {
                        BloodSample bloodSample = new BloodSample();
                        bloodSample.BloodVialColor = wodvm.BloodVialColor;
                        bloodSample.BloodVialCount = wodvm.BloodVialCount;
                        bloodSample.PatientWorkOrder = patientWorkOrder;
                        DB.BloodSamples.Add(bloodSample);
                    }
                    DB.PatientWorkOrders.Add(patientWorkOrder);
                }
            }

            DB.WorkOrders.Add(workOrder);
            DB.Visits.Add(visit);

            DB.SaveChanges();

            Session["SavedWorkOrder"] = null;
            Session["SavedWorkOrderSummary"] = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Discard()
        {
            Session["SavedWorkOrder"] = null;
            Session["SavedWorkOrderSummary"] = null;

            return RedirectToAction("Index", "Home");
        }

        private static int[] GetIdsFromString(string input)
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
    }
}