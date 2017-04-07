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
            return View("Index");
        }

        public ActionResult CreateWorkOrder()
        {
            WorkOrderViewModel wovm = new WorkOrderViewModel();
            wovm.CurativeVisit = new WorkOrderCurativeViewModel();
            wovm.PreventiveVisit = new WorkOrderPreventiveViewModel();


            List<int> patients = DB.Patients.Select(x => x.PatientId).ToList();
            wovm.AllPatients = patients;

            // wovm should be loaded from currently logged in user
            wovm.CurrentEmployee = new Employee
            {
                Title = Employee.JobTitle.Doctor,
                Name = "QWE"
            };

            return View("Create", wovm);
        }

        public ActionResult SubmitWorkOrder(WorkOrderViewModel wovm)
        {
            // TODO: check for fields
            if (DB.Patients.FirstOrDefault(x => x.PatientId == wovm.PatientId) != null &&
                wovm.DateTimeOfFirstVisit > DateTime.Now &&
                wovm.NumberOfVisits > 0 &&
                wovm.TimeType != WorkOrderViewModel.VisitTimeType.Default &&
                (
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame &&
                    wovm.TimeFrame > DateTime.Now
                    ||
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval &&
                    wovm.TimeInterval > 1
                ) &&
                wovm.Type != WorkOrderViewModel.VisitType.Default &&
                (
                    wovm.CurrentEmployee.Title == Employee.JobTitle.Doctor &&
                    wovm.Type == WorkOrderViewModel.VisitType.CurativeVisit &&
                    wovm.CurativeVisit.Title != WorkOrderCurativeViewModel.VisitTitle.Default
                    ||
                    wovm.Type == WorkOrderViewModel.VisitType.PreventiveVisit && 
                    wovm.PreventiveVisit.Title != WorkOrderPreventiveViewModel.VisitTitle.Default
                )
            )
            {
                Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == wovm.PatientId);
                Employee employee = DB.Employees.FirstOrDefault(x => x.EmployeeId == wovm.CurrentEmployee.EmployeeId);
                Contractor contractor = DB.Contractors.FirstOrDefault(x => x.ContractorId == wovm.CurrentEmployee.Contractor.ContractorId);

                WorkOrder workOrder = new WorkOrder();
                workOrder.Contractor = contractor;
                workOrder.Employee = employee;
                workOrder.Name = wovm.Type.ToString();

                PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                patientWorkOrder.Patient = patient;
                patientWorkOrder.WorkOrder = workOrder;

                Visit visit = new Visit();
                visit.Date = wovm.DateTimeOfFirstVisit;
                visit.Mandatory = wovm.MandatoryFirstVisit;
                visit.WorkOrder = workOrder;            }
                

            return View("Index");
        }
    }
}