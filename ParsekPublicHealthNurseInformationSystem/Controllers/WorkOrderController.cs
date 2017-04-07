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
        // GET: WorkOrder
        public ActionResult Index()
        {
            WorkOrderViewModel wowm = new WorkOrderViewModel();
            wowm.CurrentEmployee = new Employee();
            wowm.CurrentEmployee.Title = Employee.JobTitle.Doctor;
            wowm.CurrentEmployee.Name = "QWE";

            wowm.CurativeVisit = new WorkOrderCurativeViewModel();
            wowm.CurativeVisit.Title = WorkOrderCurativeViewModel.VisitTitle.BloodSample;

            wowm.PreventiveVisit = new WorkOrderPreventiveViewModel();

            return View(wowm);
        }
    }
}