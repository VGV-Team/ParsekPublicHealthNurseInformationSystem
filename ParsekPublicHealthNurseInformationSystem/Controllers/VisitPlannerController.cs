using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class VisitPlannerController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: VisitPlanner
        public ActionResult Index(VisitPlannerViewModel vm, DateTime? date)
        {
            if (vm == null)
            {
                vm = new VisitPlannerViewModel();
                vm.OptionalVisits = new List<Visit>();
                vm.MandatoryVisits = new List<Visit>();
                vm.OverdueVisits = new List<Visit>();
                if (date != null)
                {
                    vm.PlanDate = date;
                    if (vm.PlanDate < DateTime.Now.Date)
                    {
                        InvalidDate(vm);
                        return View("Index", vm);
                    }
                    FillViewModel(vm);
                }
            }
            else
            {
                if (vm.PlanDate != null)
                {
                    if (vm.PlanDate < DateTime.Now.Date)
                    {
                        InvalidDate(vm);
                        return View("Index", vm);
                    }
                    FillViewModel(vm);
                }
                else
                {
                    vm.OptionalVisits = new List<Visit>();
                    vm.MandatoryVisits = new List<Visit>();
                    vm.OverdueVisits = new List<Visit>();
                }
            }
               

            return View("Index", vm);
        }

        public void InvalidDate(VisitPlannerViewModel vm)
        {
            vm.OptionalVisits = new List<Visit>();
            vm.MandatoryVisits = new List<Visit>();
            vm.OverdueVisits = new List<Visit>();
            vm.ViewMessage = "Datum mora biti enak ali večji od današnjega.";
        }

        public void FillViewModel(VisitPlannerViewModel vm)
        {
            Employee CurrentNurse = (Session["user"] as Models.User).Employee;

            List<Visit> AllVisits = DB.Visits.Where(v => CurrentNurse.EmployeeId == v.WorkOrder.Nurse.EmployeeId || // Check if this nurse is assigned OR
                                            (v.WorkOrder.NurseReplacement != null && v.WorkOrder.NurseReplacement.EmployeeId == CurrentNurse.EmployeeId)) //Check if nurse is replacement
                                            .ToList();

            List<Visit> TodayVisits = AllVisits.Where(v => (v.Date.Day == vm.PlanDate.Value.Day && v.Date.Month == vm.PlanDate.Value.Month && v.Date.Year == vm.PlanDate.Value.Year) ||
                                                            v.DateConfirmed.Day == vm.PlanDate.Value.Day && v.DateConfirmed.Month == vm.PlanDate.Value.Month && v.DateConfirmed.Year == vm.PlanDate.Value.Year).ToList();

            //List<Visit> ApproximateVisits = AllVisits.Where(v => v.Date.Ticks > Date)

            //List<Visit> AllVisits = DB.Visits.Where(v => CurrentNurse.EmployeeId == v.WorkOrder.Nurse.EmployeeId).ToList();

            vm.MandatoryVisits = TodayVisits.Where(v => (v.Mandatory || (v.Confirmed && v.DateConfirmed.Date.Ticks == vm.PlanDate.Value.Ticks))).OrderBy(v => v.Date).ToList();
            vm.OptionalVisits = AllVisits.Where(v => !v.Confirmed && !v.Mandatory &&
                                                v.Date.Date >= DateTime.Now.Date &&
                                                v.Date.Date <= vm.PlanDate.Value.Date.AddDays(5) &&
                                                v.Date.Date >= vm.PlanDate.Value.Date.AddDays(-5))
                                                .OrderBy(v => v.Date)
                                                .ToList();
    
            //vm.OverdueVisits = AllVisits.Where(v => v.Date.Year <= DateTime.Now.Year && v.Date.Month <= DateTime.Now.Month && v.Date.Day < DateTime.Now.Day && v.Confirmed == false).ToList();
            vm.OverdueVisits = AllVisits.Where(v => v.Date.Date.Ticks < DateTime.Now.Date.Ticks && v.Confirmed == false)
                                        .OrderBy(v => v.Date).ToList();
        }

        public ActionResult ConfirmVisit(DateTime date, int? ConfirmedVisitId)
        {

            if (ConfirmedVisitId != null)
            {
                Models.Visit visit = DB.Visits.Find(ConfirmedVisitId);
                if (visit != null)
                {
                    visit.DateConfirmed = date;
                    visit.Confirmed = true;
                    DB.SaveChanges();
                }
            }


            VisitPlannerViewModel tmpvm = new VisitPlannerViewModel();
            tmpvm.PlanDate = date;
            return RedirectToAction("Index", "VisitPlanner", tmpvm);
        }

        public ActionResult DisconfirmVisit(DateTime date, int? DisconfirmedVisitId)
        {

            if (DisconfirmedVisitId != null)
            {
                Models.Visit visit = DB.Visits.Find(DisconfirmedVisitId);
                if (visit != null && visit.Mandatory == false)
                {
                    visit.Confirmed = false;
                    DB.SaveChanges();
                }
            }

            VisitPlannerViewModel tmpvm = new VisitPlannerViewModel();
            tmpvm.PlanDate = date;
            return RedirectToAction("Index", "VisitPlanner", tmpvm);
        }

    }
}