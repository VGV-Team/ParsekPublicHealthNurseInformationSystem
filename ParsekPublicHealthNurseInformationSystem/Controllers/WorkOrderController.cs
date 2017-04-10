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

        public ActionResult CreateWorkOrder(WorkOrderVisitTypeViewModel wovtvm)
        {
            User currentUser = (User)Session["user"];
            bool isDoctor = currentUser.Employee.Title == Employee.JobTitle.Doctor;

            Activity activity = DB.Activities.FirstOrDefault(x => x.ActivityId == wovtvm.SelectedActivityId);
            if (activity == null || !activity.PreventiveVisit && !isDoctor)
            {
                // TODO: error
            }

            WorkOrderViewModel wovm = new WorkOrderViewModel();
            wovm.AllPatients = DB.Patients.ToList();
            wovm.SelectedActivityId = wovtvm.SelectedActivityId;

            // TODO: do this
            wovm.AllMedicines = DB.Medicines.ToList();
            wovm.AllColors = new List<string> { "Rdeča", "Modra", "Rumena", "Zelena" };
            return View("Create", wovm);
        }

        public ActionResult SubmitWorkOrder(WorkOrderViewModel wovm)
        {
            string patients = wovm.PatientIds;

            if (patients.IsNullOrWhiteSpace() ||
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
                    (wovm.TimeInterval > 30 || wovm.TimeInterval < 1))
            )
            {
                // TODO: wrong data
                wovm.AllPatients = DB.Patients.ToList(); // TODO: horrible fix!! Change this!
                return View("Create", wovm);
            }
            else
            {
                User currentUser = (User)Session["user"];
                Employee employee = DB.Employees.FirstOrDefault(x => x.EmployeeId == currentUser.Employee.EmployeeId);
                Contractor contractor = employee.Contractor;

                WorkOrder workOrder = new WorkOrder();
                workOrder.Contractor = contractor;
                workOrder.Issuer = employee;
                workOrder.Activity = DB.Activities.FirstOrDefault(x => x.ActivityId == wovm.SelectedActivityId);
                workOrder.Name = workOrder.Activity.ActivityTitle;

                Visit visit = new Visit();
                visit.Date = wovm.DateTimeOfFirstVisit;
                visit.Mandatory = wovm.MandatoryFirstVisit;
                visit.WorkOrder = workOrder;

                WorkOrderSummaryViewModel wosvm = new WorkOrderSummaryViewModel();
                wosvm.WorkOrderVM = wovm;
                wosvm.Patients = new List<string>();
                wosvm.Doctor = employee.DisplayName;
                wosvm.ActivityTitle = workOrder.Activity.ActivityTitle;
                wosvm.Medicine = new List<string>();




                    // Check for single or multiple visits.
                if (wovm.MultipleVisits && wovm.NumberOfVisits > 1)
                {
                    int timeFrame = 1;
                    bool mandatoryvisit = wovm.MandatoryFirstVisit;
                    if (wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame)
                    {
                        timeFrame = (wovm.TimeFrame - wovm.DateTimeOfFirstVisit).Days / (wovm.NumberOfVisits-1);
                        mandatoryvisit = false;
                    }
                    else if(wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval)
                    {
                        timeFrame = wovm.TimeInterval;
                    }

                    for (int i = 1; i < wovm.NumberOfVisits; i++)
                    {
                        Visit vis = new Visit();
                        vis.Date = wovm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                        vis.Mandatory = mandatoryvisit;
                        vis.WorkOrder = workOrder;
                        DB.Visits.Add(vis);
                    }
                }

                // Generate work order for all patients.
                int[] ids = GetIdsFromString(patients);
                List<District> districts = new List<District>();
                foreach (var id in ids)
                {
                    Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                    if (patient != null)
                    {
                        PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                        patientWorkOrder.WorkOrder = workOrder;
                        patientWorkOrder.Patient = patient;
                        DB.PatientWorkOrders.Add(patientWorkOrder);

                        wosvm.Patients.Add(patient.DisplayName);

                        districts.Add(patient.District);
                    }
                }

                

                // Check for possible nurses.
                List<Employee> possibleNurses = new List<Employee>();
                districts = districts.Distinct().ToList();
                for (int i = 0; i < districts.Count; i++)
                {
                    //possibleNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse && districts.Contains(x.District)).ToList();
                    possibleNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    possibleNurses = possibleNurses.Where(x => districts.Contains(x.District)).ToList();
                }

                if (possibleNurses.Count == 1)
                {
                    // If there is only 1 nurse then we assign her to work order.
                    workOrder.Nurse = possibleNurses.First();
                }

                // Save data to database.
                DB.WorkOrders.Add(workOrder);
                DB.Visits.Add(visit);

                
                


                Session["workorder"] = wosvm;
                Session["workorder_DB"] = workOrder; // DELETE
                //DB.SaveChanges();



                if (possibleNurses.Count != 1) // To many or too few nurses to select from.
                {
                    WorkOrderNurseSelectionViewModel wonsvm = new WorkOrderNurseSelectionViewModel();
                    wonsvm.WorkOrderId = workOrder.WorkOrderId;
                    wonsvm.Districts = districts;

                    if (possibleNurses.Count == 0) // There are no nurses for selected district so we need to choose some other nurse.
                    {
                        possibleNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    }
                    else // There are more than 1 nurse for one district so we need to choose the right one.
                    {
                    }
                    wonsvm.PossibleNurses = possibleNurses;
                    wonsvm.PossibleNursesReplacement = possibleNurses;

                    return View("NurseSelection", wonsvm);
                }
                
            }

            // TODO: redirect and confirm message
            return RedirectToAction("Index", "Home");
            // !!!ATTENTION!!!
            // For date validation to work you must do this upon failure!!
            //return View("Create");
        }

        public ActionResult SelectNurseWorkOrder(WorkOrderNurseSelectionViewModel wovm)
        {
            Employee selectedNurse = DB.Employees.FirstOrDefault(x => x.EmployeeId == wovm.SelectedNurseId);
            if (selectedNurse == null)
            {
                // TODO: error
            }

            Employee selectedNurseReplacement = null;
            if (wovm.SelectedNurseReplacementId != null && wovm.SelectedNurseReplacementId > 0)
            {
                selectedNurseReplacement = DB.Employees.FirstOrDefault(x => x.EmployeeId == wovm.SelectedNurseReplacementId);
            }

            //WorkOrder workOrder = DB.WorkOrders.FirstOrDefault(x => x.WorkOrderId == wovm.WorkOrderId);
            WorkOrder workOrder = (WorkOrder) Session["workorder_DB"]; // DELETE
            if (workOrder == null)
            {
                // TODO: error
            }

            workOrder.Nurse = selectedNurse;
            if (selectedNurseReplacement != null) workOrder.NurseReplacement = selectedNurseReplacement;

            // OLD
            //DB.SaveChanges();

            //return RedirectToAction("Index", "Home");

            WorkOrderSummaryViewModel wosvm = Session["workorder"] as WorkOrderSummaryViewModel;
            wosvm.Nurse = workOrder.Nurse.DisplayName;
            if (selectedNurseReplacement != null) wosvm.NurseReplacement = workOrder.NurseReplacement.DisplayName;
            else wosvm.NurseReplacement = "/";
            
            Session["workorder"] = wosvm;
            Session["workorder_DB"] = workOrder; //DELETE

            return View("Summary", wosvm);
        }

        public ActionResult Submit(WorkOrderSummaryViewModel workOrder)
        {
            //DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private static int[] GetIdsFromString(string input)
        {
            string[] splits = input.Split(',');
            int[] ids = new int[splits.Length];
            for (int i = 0; i < splits.Length; i++)
            {
                //string idString = splits[i].Split('(').Last().Replace(" ", "");
                string idString = splits[i].Split('(').Last().Split(')').First();
                int id;
                if (int.TryParse(idString, out id) && id != 0)
                {
                    ids[i] = id;
                }
            }
            ids = ids.Distinct().ToArray();

            return ids;
        }
    }
}