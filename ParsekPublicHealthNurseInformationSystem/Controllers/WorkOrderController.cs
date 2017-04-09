using System;
using System.Collections.Generic;
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
            // TODO: get this from session
            bool isDoctor = true;

            WorkOrderVisitTypeViewModel wovtvm = new WorkOrderVisitTypeViewModel();
            wovtvm.CreateWorkOrderVisitTypeViewModel(isDoctor);

            return View("Index", wovtvm);
        }

        public ActionResult CreateWorkOrder(WorkOrderVisitTypeViewModel wovtvm)
        {
            // TODO: get this from session
            bool isDoctor = true;

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
                wovm.DateTimeOfFirstVisit.AddMonths(-6) > DateTime.Now ||
                wovm.NumberOfVisits < 1 || wovm.NumberOfVisits > 10 ||
                wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame &&
                (wovm.TimeFrame.AddMonths(-6) > DateTime.Now ||
                 wovm.TimeFrame < DateTime.Now) &&
                 wovm.TimeFrame < wovm.DateTimeOfFirstVisit ||
                wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval &&
                (wovm.TimeInterval > 30 || wovm.TimeInterval < 1)
            )
            {
                // TODO: wrong data
                ;
            }
            else
            {
                // TODO: get this from session
                Employee employee = DB.Employees.FirstOrDefault(x => x.Name == "Doctory");
                Contractor contractor = employee.Contractor;
                //DB.Contractors.FirstOrDefault(x => x.ContractorId == wovm.CurrentEmployee.Contractor.ContractorId);

                WorkOrder workOrder = new WorkOrder();
                workOrder.Contractor = contractor;
                workOrder.Issuer = employee;
                workOrder.Name = "Name of activity";

                PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                patientWorkOrder.Patient = patient;
                patientWorkOrder.WorkOrder = workOrder;

                Visit visit = new Visit();
                visit.Date = wovm.DateTimeOfFirstVisit;
                visit.Mandatory = wovm.MandatoryFirstVisit;
                visit.WorkOrder = workOrder;

                DB.WorkOrders.Add(workOrder);
                DB.PatientWorkOrders.Add(patientWorkOrder);
                DB.Visits.Add(visit);
                DB.SaveChanges();
            }

            // TODO: redirect and confirm message
            return RedirectToAction("Index", "Home");
            
            // !!!ATTENTION!!!
            // For date validation to work you must do this upon failure!!
            //return View("Create");
        }
    }
}