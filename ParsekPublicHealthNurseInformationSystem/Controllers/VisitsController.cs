using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class VisitsController : Controller
    {
        private EntityDataModel db = new EntityDataModel();

        // GET: Visits
        public ActionResult Index(int id)
        {
            // TODO: return correct visit
            
            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == id);

            VisitViewModel vvm = new VisitViewModel();
            vvm.VisitId = visit.VisitId;
            vvm.Date = visit.Date;
            vvm.InputData = visit.InputData;

            return View(vvm);
        }

        public ActionResult EnterData(VisitViewModel vvm)
        {
            // TODO: validation

            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == vvm.VisitId);
            visit.InputData = vvm.InputData;
            visit.Date = vvm.Date;

            db.SaveChanges();

            return null;
        }
    }   
}
