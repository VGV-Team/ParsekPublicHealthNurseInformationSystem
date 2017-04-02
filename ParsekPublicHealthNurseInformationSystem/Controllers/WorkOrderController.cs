using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            WorkOrderViewModel wowm = new WorkOrderViewModel();
            wowm.SupervisorName = "qwe";

            wowm.CurativeVisit = new WorkOrderCurativeViewModel();
            wowm.CurativeVisit.Title = WorkOrderCurativeViewModel.VisitTitle.BloodSample;

            return View(wowm);
        }
    }
}