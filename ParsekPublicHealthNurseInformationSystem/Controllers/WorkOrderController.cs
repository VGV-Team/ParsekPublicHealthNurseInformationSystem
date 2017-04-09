using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class WorkOrderController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: WorkOrder
        public ActionResult Index()
        {
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

            return View("Create", wovm);
        }

        public ActionResult SubmitWorkOrder(WorkOrderViewModel wovm)
        {
            Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == wovm.PatientId);

            if (patient == null ||
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
            }
            else
            {
                User currentUser = (User)Session["user"];
                Employee employee = DB.Employees.FirstOrDefault(x => x.EmployeeId == currentUser.Employee.EmployeeId);
                Contractor contractor = employee.Contractor;

                WorkOrder workOrder = new WorkOrder();
                workOrder.Contractor = contractor;
                workOrder.Employee = employee;
                workOrder.Name = "Name of activity";

                PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                patientWorkOrder.Patient = patient;
                patientWorkOrder.WorkOrder = workOrder;

                Visit visit = new Visit();
                visit.Date = wovm.DateTimeOfFirstVisit;
                visit.Mandatory = wovm.MandatoryFirstVisit;
                visit.WorkOrder = workOrder;

                if (wovm.MultipleVisits && wovm.NumberOfVisits > 1)
                {
                    int timeFrame = 1;
                    if (wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame)
                    {
                        timeFrame = (wovm.TimeFrame - wovm.DateTimeOfFirstVisit).Days / (wovm.NumberOfVisits-1);
                    }
                    else if(wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval)
                    {
                        timeFrame = wovm.TimeInterval;
                    }

                    for (int i = 1; i < wovm.NumberOfVisits; i++)
                    {
                        Visit vis = new Visit();
                        vis.Date = wovm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                        vis.Mandatory = wovm.MandatoryFirstVisit; // TODO: what is this based on?
                        vis.WorkOrder = workOrder;
                        DB.Visits.Add(vis);
                    }
                }

                DB.WorkOrders.Add(workOrder);
                DB.PatientWorkOrders.Add(patientWorkOrder);
                DB.Visits.Add(visit);
                DB.SaveChanges();
            }

            // TODO: redirect and confirm message
            return RedirectToAction("Index", "Home");
        }
    }
}