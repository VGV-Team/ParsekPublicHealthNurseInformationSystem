using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Employee.JobTitle.Doctor, Employee.JobTitle.Head, Employee.JobTitle.HealthNurse)]
    public class WOFilterController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: WOFilter
        public ActionResult Index(WorkOrderFilterViewModel vm)
        {


            if (vm == null)
            {
                vm = new WorkOrderFilterViewModel();
            }

            vm.Issuers = DB.Employees.Where(e => e.Title == Employee.JobTitle.Doctor || e.Title == Employee.JobTitle.Head).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.Title == Employee.JobTitle.HealthNurse).ToList();

            vm.WorkOrders = DB.WorkOrders.ToList();


            CheckForRole(vm);

            


            return Filter(vm);
        }

        public void CheckForRole(WorkOrderFilterViewModel vm)
        {
            if (Session["user"] != null)
            {

                Models.User sessionUser = Session["user"] as Models.User;

                if (sessionUser.Employee != null)
                {
                    if (sessionUser.Employee.Title == Employee.JobTitle.HealthNurse)
                    {
                        vm.SelectedNurseId = vm.SelectedNurseReplacementId = sessionUser.Employee.EmployeeId;
                        vm.SelectedNurseReplacementId = vm.SelectedNurseId;
                        vm.Nurse = vm.Nurse.Where(n => n.EmployeeId == vm.SelectedNurseId).ToList();
                        vm.NurseReplacement = vm.NurseReplacement.Where(n => n.EmployeeId == vm.SelectedNurseReplacementId).ToList();
                    }
                    else if (sessionUser.Employee.Title == Employee.JobTitle.Doctor)
                    {
                        vm.SelectedIssuerId = sessionUser.Employee.EmployeeId;
                        vm.Issuers = vm.Issuers.Where(i => i.EmployeeId == vm.SelectedIssuerId).ToList();
                    }
                }
            }
        }

        public ActionResult Filter(WorkOrderFilterViewModel vm)
        {

            if (vm == null)
            {
                vm = new WorkOrderFilterViewModel();
            }

            vm.Issuers = DB.Employees.Where(e => e.Title == Employee.JobTitle.Doctor || e.Title == Employee.JobTitle.Head).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.Title == Employee.JobTitle.HealthNurse).ToList();

            vm.WorkOrders = DB.WorkOrders.ToList();

            CheckForRole(vm);

            #region Filters

            if (vm.DateStart != null)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Visits.Any(v => v.Date > vm.DateStart)).ToList();
            }
            if (vm.DateEnd != null)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Visits.Any(v => v.Date < vm.DateEnd)).ToList();
            }
            if (vm.VisitType != 0)
            {
                if (vm.VisitType == WorkOrderFilterViewModel.VisitTypeEnum.Preventive)
                    vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Activity.PreventiveVisit == true).ToList();
                else
                    vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Activity.PreventiveVisit == false).ToList();
            }
            if (vm.SelectedIssuerId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Issuer.EmployeeId == vm.SelectedIssuerId).ToList();
            }
            if (vm.SelectedPatientId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.PatientWorkOrders.Any(pwo => pwo.Patient.PatientId == vm.SelectedPatientId)).ToList();
            }
            if (vm.SelectedNurseId > 0 && vm.SelectedNurseReplacementId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Nurse.EmployeeId == vm.SelectedNurseId ||  (wo.NurseReplacement != null && wo.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId)).ToList();
            }
            else if (vm.SelectedNurseReplacementId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.NurseReplacement != null && wo.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId).ToList();
            }
            else if (vm.SelectedNurseId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Nurse.EmployeeId == vm.SelectedNurseId).ToList();
            }



            #endregion

            return View("Index", vm);
        }

    }
}