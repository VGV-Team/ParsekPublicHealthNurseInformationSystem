using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(JobTitle.HealthNurse)]
    public class VisitPlannerController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: VisitPlanner
        public ActionResult Index(VisitPlannerViewModel vm, DateTime? date)
        {
            vm = new VisitPlannerViewModel();
            vm.OptionalVisits = new List<Visit>();
            vm.MandatoryVisits = new List<Visit>();
            vm.OverdueVisits = new List<Visit>();
            vm.Visits = new List<List<Visit>>();
            vm.Materials = new List<List<VisitPlannerViewModel.MaterialList>>();
            vm.VisitsDays = 7;

            if (vm == null)
            {
                vm = new VisitPlannerViewModel();
                vm.OptionalVisits = new List<Visit>();
                vm.MandatoryVisits = new List<Visit>();
                vm.OverdueVisits = new List<Visit>();
                vm.Visits = new List<List<Visit>>();
                vm.Materials = new List<List<VisitPlannerViewModel.MaterialList>>();
                vm.VisitsDays = 7;
                FillViewModel(vm);
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
                    vm.Visits = new List<List<Visit>>();
                    vm.Materials = new List<List<VisitPlannerViewModel.MaterialList>>();
                    vm.VisitsDays = 7;
                }
                FillViewModel(vm);
            }
               

            return View("Index", vm);
        }

        public void InvalidDate(VisitPlannerViewModel vm)
        {
            vm.OptionalVisits = new List<Visit>();
            vm.MandatoryVisits = new List<Visit>();
            vm.OverdueVisits = new List<Visit>();
            vm.Visits = new List<List<Visit>>();
            vm.Materials = new List<List<VisitPlannerViewModel.MaterialList>>();
            vm.VisitsDays = 7;
            vm.ViewMessage = "Datum mora biti enak ali večji od današnjega.";
        }

        public void FillViewModel(VisitPlannerViewModel vm)
        {
            Employee CurrentNurse = (Session["user"] as Models.User).Employee;

            List<Visit> AllVisits = DB.Visits.Where(v => (CurrentNurse.EmployeeId == v.WorkOrder.Nurse.EmployeeId && v.NurseReplacement == null) || // Check if this nurse is assigned OR
                                            (v.NurseReplacement != null && v.NurseReplacement.EmployeeId == CurrentNurse.EmployeeId)) //Check if nurse is replacement
                                            .ToList();

            DateTime dt = DateTime.Now.Date;

            for (int i = 0; i < vm.VisitsDays; i++)
            {
                List<Visit> tmp = new List<Visit>();
                tmp = AllVisits.Where(v => v.DateConfirmed.Day == dt.Day && v.DateConfirmed.Month == dt.Month && v.DateConfirmed.Year == dt.Year && (v.Mandatory || v.Confirmed)).ToList();
                vm.Visits.Add(tmp);
                dt = dt.AddDays(1);

                // Add materials
                int numRedVials = 0;
                int numBlueVials = 0;
                int numGreenVials = 0;
                int numYellowVials = 0;
                List<VisitPlannerViewModel.MaterialList> materialList = new List<VisitPlannerViewModel.MaterialList>();
                //List<Medicine> medicineList = DB.Medicines.OrderBy(m => m.MedicineId).ToList();
                int[] medicineCounter = new int[DB.Medicines.Count() + 1];
                for (int j = 0; j < tmp.Count; j++)
                {
                    WorkOrder wo = tmp[j].WorkOrder;

                    // Blood vials
                    if (wo.BloodSamples.Count > 0)
                    {
                        numRedVials += wo.BloodSamples.ElementAt(0).BloodVialRedCount;
                        numBlueVials += wo.BloodSamples.ElementAt(0).BloodVialBlueCount;
                        numGreenVials += wo.BloodSamples.ElementAt(0).BloodVialGreenCount;
                        numYellowVials += wo.BloodSamples.ElementAt(0).BloodVialYellowCount;
                    }

                    // Medicine
                    foreach (var med in wo.MedicineWorkOrders)
                    {
                        medicineCounter[med.Medicine.MedicineId]++;
                    }
                }

                #region Add to meterials list
                if (numRedVials > 0)
                {
                    VisitPlannerViewModel.MaterialList ml = new VisitPlannerViewModel.MaterialList();
                    ml.MaterialName = "Odvzem krvi: rdeče epruvete";
                    ml.Count = numRedVials;
                    materialList.Add(ml);
                }
                if (numBlueVials > 0)
                {
                    VisitPlannerViewModel.MaterialList ml = new VisitPlannerViewModel.MaterialList();
                    ml.MaterialName = "Odvzem krvi: modre epruvete";
                    ml.Count = numBlueVials;
                    materialList.Add(ml);
                }
                if (numGreenVials > 0)
                {
                    VisitPlannerViewModel.MaterialList ml = new VisitPlannerViewModel.MaterialList();
                    ml.MaterialName = "Odvzem krvi: zelene epruvete";
                    ml.Count = numGreenVials;
                    materialList.Add(ml);
                }
                if (numYellowVials > 0)
                {
                    VisitPlannerViewModel.MaterialList ml = new VisitPlannerViewModel.MaterialList();
                    ml.MaterialName = "Odvzem krvi: rumene epruvete";
                    ml.Count = numYellowVials;
                    materialList.Add(ml);
                }
                
                for (int j = 1; j < medicineCounter.Length; j++)
                {
                    if (medicineCounter[j] > 0)
                    {
                        VisitPlannerViewModel.MaterialList ml = new VisitPlannerViewModel.MaterialList();
                        ml.MaterialName = "Aplikacija injekcije: " + DB.Medicines.Find(j).FullName;
                        ml.Count = medicineCounter[j];
                        materialList.Add(ml);
                    }
                }
                #endregion

                vm.Materials.Add(materialList);
            }

            vm.OptionalVisits = AllVisits.Where(v => !v.Confirmed && !v.Mandatory &&
                                                v.Date.Date >= DateTime.Now.Date &&
                                                v.Date.Date <= DateTime.Now.Date.Date.AddDays(7))
                                                .OrderBy(v => v.Date)
                                                .ToList();

            vm.OverdueVisits = AllVisits.Where(v => v.DateConfirmed.Date.Ticks < DateTime.Now.Date.Ticks && (v.Confirmed == false || v.Done == false))
                                        .OrderBy(v => v.DateConfirmed).ToList();
            //OLD
            //
            /*List<Visit> TodayVisits = AllVisits.Where(v => (v.Date.Day == vm.PlanDate.Value.Day && v.Date.Month == vm.PlanDate.Value.Month && v.Date.Year == vm.PlanDate.Value.Year) ||
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
                                        .OrderBy(v => v.Date).ToList();*/
        }

        public ActionResult ConfirmVisit(VisitPlannerViewModel vm)
        {

            if (vm.PlanDate.Value.Date >= DateTime.Now.Date && vm.HiddenVisitId != null)
            {
                Models.Visit visit = DB.Visits.Find(vm.HiddenVisitId);

                if (visit != null)
                {
                    visit.DateConfirmed = vm.PlanDate.Value;
                    visit.Confirmed = true;
                    DB.SaveChanges();
                }
            }

            return RedirectToAction("Index", "VisitPlanner", null);
        }

        public ActionResult Conf222irmVisit(DateTime date, int? ConfirmedVisitId)
        {

            if (ConfirmedVisitId != null && date.Date > DateTime.Now.Date)
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
                    visit.DateConfirmed = visit.Date;
                    DB.SaveChanges();
                }
            }

            VisitPlannerViewModel tmpvm = new VisitPlannerViewModel();
            tmpvm.PlanDate = date;
            return RedirectToAction("Index", "VisitPlanner", tmpvm);
        }

    }
}