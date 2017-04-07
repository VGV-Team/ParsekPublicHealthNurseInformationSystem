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


            List<int> patients = new List<int>(); //DB.Patients.Select(p => p.PatientId).ToList();
            patients.Add(123123);
            patients.Add(221);
            patients.Add(25112);
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
            return View("Index");
        }
    }
}