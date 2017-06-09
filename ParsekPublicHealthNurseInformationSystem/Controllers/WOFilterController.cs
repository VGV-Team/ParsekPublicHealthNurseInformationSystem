using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(JobTitle.Doctor, JobTitle.Head, JobTitle.HealthNurse)]
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

            vm.Issuers = DB.Employees.Where(e => (e.JobTitle.Title == JobTitle.Doctor || e.JobTitle.Title == JobTitle.Head)).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.JobTitle.Title == JobTitle.HealthNurse).ToList();

            vm.Services = DB.Services.ToList();
            vm.WorkOrders = DB.WorkOrders.ToList();
            vm.CanDelete = new List<bool>();

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
                    if (sessionUser.Employee.JobTitle.Title == JobTitle.HealthNurse)
                    {
                        vm.SelectedNurseId = vm.SelectedNurseReplacementId = sessionUser.Employee.EmployeeId;
                        vm.SelectedNurseReplacementId = vm.SelectedNurseId;
                        vm.Nurse = vm.Nurse.Where(n => n.EmployeeId == vm.SelectedNurseId).ToList();
                        vm.NurseReplacement = vm.NurseReplacement.Where(n => n.EmployeeId == vm.SelectedNurseReplacementId).ToList();
                    }
                    else if (sessionUser.Employee.JobTitle.Title == JobTitle.Doctor)
                    {
                        vm.SelectedIssuerId = sessionUser.Employee.EmployeeId;
                        vm.Issuers = vm.Issuers.Where(i => i.EmployeeId == vm.SelectedIssuerId).ToList();
                    }
                }
            }
        }

        private void CheckForDelete(WorkOrderFilterViewModel vm)
        {

            Employee current = (Session["user"] as Models.User).Employee;

            // IF doctor or head
            if (current.JobTitle.Title == JobTitle.Doctor || current.JobTitle.Title == JobTitle.Head)
            {
                for (int i = 0; i < vm.WorkOrders.Count; i++)
                {
                    WorkOrder wo = vm.WorkOrders.ElementAt(i);
                    // If I created this workroder
                    if (wo.Issuer.EmployeeId == current.EmployeeId)
                    {
                        // If WO has any done vists
                        if (wo.Visits.Any(v => v.Done))
                        {
                            // Can't delete
                            vm.CanDelete.Add(false);
                        }
                        else
                        {
                            // Can delete
                            vm.CanDelete.Add(true);
                        }
                    }
                    else
                    {
                        vm.CanDelete.Add(false);
                    }
                }
            }
            else
            {
                for (int i = 0; i < vm.WorkOrders.Count; i++)
                {
                    vm.CanDelete.Add(false);
                }
            }
            
        } 

        public ActionResult Filter(WorkOrderFilterViewModel vm)
        {

            if (vm == null)
            {
                vm = new WorkOrderFilterViewModel();
            }

            vm.Issuers = DB.Employees.Where(e => (e.JobTitle.Title == JobTitle.Doctor || e.JobTitle.Title == JobTitle.Head)).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.JobTitle.Title == JobTitle.HealthNurse).ToList();

            vm.Services = DB.Services.ToList();

            vm.WorkOrders = DB.WorkOrders.ToList();
            vm.CanDelete = new List<bool>();

            CheckForRole(vm);

            #region Filters

            if (vm.DateStart != null)
            {
                //vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Visits.Any(v => v.Date > vm.DateStart)).ToList();
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.DateCreated >= vm.DateStart).ToList();
            }
            if (vm.DateEnd != null)
            {
                //vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Visits.Any(v => v.Date < vm.DateEnd)).ToList();
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.DateCreated <= vm.DateEnd).ToList();
            }
            /*if (vm.VisitType != 0)
            {
                if (vm.VisitType == WorkOrderFilterViewModel.VisitTypeEnum.Preventive)
                    vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Service.PreventiveVisit == true).ToList();
                else
                    vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Service.PreventiveVisit == false).ToList();
            }*/
            if (vm.ServiceId != null && vm.ServiceId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Service.ServiceId == vm.ServiceId).ToList();
            }
            if (vm.SelectedIssuerId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Issuer.EmployeeId == vm.SelectedIssuerId).ToList();
            }
            if (vm.SelectedPatientId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.PatientWorkOrders.Any(pwo => pwo.Patient.PatientId == vm.SelectedPatientId) || wo.Patient.PatientId == vm.SelectedPatientId).ToList();
            }
            if (vm.SelectedNurseId > 0 && vm.SelectedNurseReplacementId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Nurse.EmployeeId == vm.SelectedNurseId || wo.Visits.Any(v => v.NurseReplacement != null && v.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId)).ToList();
            }
            else if (vm.SelectedNurseReplacementId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Visits.Any(v => v.NurseReplacement != null && v.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId)).ToList();
            }
            else if (vm.SelectedNurseId > 0)
            {
                vm.WorkOrders = vm.WorkOrders.Where(wo => wo.Nurse.EmployeeId == vm.SelectedNurseId).ToList();
            }

            #endregion

            vm.WorkOrders = vm.WorkOrders.OrderBy(x => x.DateCreated).ToList();
            CheckForDelete(vm);

            return View("Index", vm);
        }

        public ActionResult Delete(int workorderId)
        {

            bool CanDelete = true;
            Models.WorkOrder WO = DB.WorkOrders.Find(workorderId);

            if (WO != null)
            {
                #region Check

                Employee current = (Session["user"] as Models.User).Employee;

                // IF doctor or head
                if (current.JobTitle.Title == JobTitle.Doctor || current.JobTitle.Title == JobTitle.Head)
                {

                    // If I created this workroder
                    if (WO.Issuer.EmployeeId == current.EmployeeId)
                    {
                        // If WO has any done vists
                        if (WO.Visits.Any(v => v.Done))
                        {
                            // Can't delete
                            CanDelete = false;
                        }
                        else
                        {
                            // Can delete
                            CanDelete = true;
                        }
                    }
                    else
                    {
                        CanDelete = false;
                    }

                }
                else
                {
                    CanDelete = false;
                }

                #endregion

                if (CanDelete)
                {
                    DB.Visits.RemoveRange(WO.Visits);
                    DB.PatientWorkOrders.RemoveRange(WO.PatientWorkOrders);
                    DB.BloodSamples.RemoveRange(WO.BloodSamples);
                    DB.MaterialWorkOrders.RemoveRange(WO.MaterialWorkOrders);
                    DB.MedicineWorkOrders.RemoveRange(WO.MedicineWorkOrders);
                    DB.WorkOrders.Remove(WO);
                    DB.SaveChanges();
                }
            }

            return Index(null);
        }

    }

    
}