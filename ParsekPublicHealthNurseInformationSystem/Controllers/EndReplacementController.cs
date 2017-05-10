using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class EndReplacementController : Controller
    {
        // GET: EndReplacement
        private EntityDataModel DB = new EntityDataModel();
        public ActionResult Index()
        {
            EndReplacementViewModel ervm = new EndReplacementViewModel();
            ervm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
            return View("Index", ervm);
        }

        [HttpPost]
        public ActionResult EndReplacement(EndReplacementViewModel ervm)
        {
            if (ervm.NurseId.IsNullOrWhiteSpace())
            {
                ervm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                ervm.ViewMessage = "Ponovno preverite vnešene podatke!";
                return View("Index", ervm);
            }

            int[] NurseId = Globals.GetIdsFromString(ervm.NurseId);

            if (NurseId == null || NurseId.Length != 1)
            {
                ervm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                ervm.ViewMessage = "Preverite vnešeno sestro";
                return View("Index", ervm);
            }

            Employee Nurse = DB.Employees.Find(NurseId[0]);
            Absence a = DB.Absences.Where(x => x.AbsenceNurse.EmployeeId == Nurse.EmployeeId).FirstOrDefault();
            if (a == null)
            {
                ervm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                ervm.ViewMessage = "Izbrana sestra ni nikdar odsotna";
                return View("Index", ervm);
            }

            List<WorkOrder> WO = DB.WorkOrders.Where(x => x.Nurse.EmployeeId == Nurse.EmployeeId).ToList();
            for(int i = 0; i < WO.Count; i++)
            {
                int tmp = WO.ElementAt(i).WorkOrderId;
                WorkOrder w = DB.WorkOrders.FirstOrDefault(x => x.WorkOrderId == tmp);
                for(int j = 0; j < w.Visits.Count; j++)
                {
                    Visit vi = DB.Visits.Find(w.Visits.ElementAt(j).VisitId);
                    if (vi.DateConfirmed >= DateTime.Now && !vi.Confirmed)
                    {
                        var forceLoad = vi.NurseReplacement; //Aleluja
                        vi.NurseReplacement = null; // Now EF knows something has changed
                        DB.SaveChanges();
                    }
                }
            }
            DB.Absences.Remove(a);
            DB.SaveChanges();
            ervm.ViewMessage = "Konec nadomeščanja uspešna";
            ervm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
            return View("Index", ervm);
        }
    }
}