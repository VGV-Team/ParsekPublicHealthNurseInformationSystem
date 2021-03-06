﻿using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(JobTitle.Doctor, JobTitle.Head, JobTitle.HealthNurse)]
    public class VisitFilterController : Controller
    {
        
        private EntityDataModel DB = new EntityDataModel();

        // GET: WOFilter
        public ActionResult Index(VisitFilterViewModel vm)
        {


            /*if (vm == null)
            {
                vm = new VisitFilterViewModel();
            }

            vm.Issuers = DB.Employees.Where(e => e.Title == Employee.JobTitle.Doctor || e.Title == Employee.JobTitle.Head).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.Title == Employee.JobTitle.HealthNurse).ToList();

            vm.Visits = DB.Visits.ToList();


            CheckForRole(vm);*/


            return Filter(vm);
        }

        public void CheckForRole(VisitFilterViewModel vm)
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

        public ActionResult Filter(VisitFilterViewModel vm)
        {

            if (vm == null)
            {
                vm = new VisitFilterViewModel();
            }

            vm.Issuers = DB.Employees.Where(e => e.JobTitle.Title == JobTitle.Doctor || e.JobTitle.Title == JobTitle.Head).ToList();
            vm.Patients = DB.Patients.ToList();
            vm.Nurse = vm.NurseReplacement = DB.Employees.Where(e => e.JobTitle.Title == JobTitle.HealthNurse).ToList();
            vm.Services = DB.Services.ToList();

            vm.Visits = DB.Visits.ToList();

            CheckForRole(vm);

            #region Filters

            if (vm.DateStart != null)
            {
                vm.Visits = vm.Visits.Where(v => v.Date >= vm.DateStart).ToList();
            }
            if (vm.DateEnd != null)
            {
                vm.Visits = vm.Visits.Where(v => v.Date <= vm.DateEnd).ToList();
            }
            if (vm.DateStartConfirmed != null)
            {
                vm.Visits = vm.Visits.Where(v => v.DateConfirmed >= vm.DateStartConfirmed).ToList();
            }
            if (vm.DateEndConfirmed != null)
            {
                vm.Visits = vm.Visits.Where(v => v.DateConfirmed <= vm.DateEndConfirmed).ToList();
            }
            if (vm.ServiceId != null)
            {
                vm.Visits = vm.Visits.Where(v => v.WorkOrder.Service.ServiceId == vm.ServiceId).ToList();
                /*
                if (vm.VisitType == VisitFilterViewModel.VisitTypeEnum.Preventive)
                    vm.Visits = vm.Visits.Where(v => v.WorkOrder.Service.PreventiveVisit == true).ToList();
                else
                    vm.Visits = vm.Visits.Where(v => v.WorkOrder.Service.PreventiveVisit == false).ToList();
                */
            }
            if (vm.SelectedIssuerId > 0)
            {
                vm.Visits = vm.Visits.Where(v => v.WorkOrder.Issuer.EmployeeId == vm.SelectedIssuerId).ToList();
            }
            if (vm.SelectedPatientId > 0)
            {
                vm.Visits = vm.Visits.Where(v => v.WorkOrder.PatientWorkOrders.Any(pwo => pwo.Patient.PatientId == vm.SelectedPatientId) 
                || (v.WorkOrder.Patient != null && v.WorkOrder.Patient.PatientId == vm.SelectedPatientId)).ToList();
            }
            if (vm.SelectedNurseId > 0 && vm.SelectedNurseReplacementId > 0)
            {
                vm.Visits = vm.Visits.Where(v => v.WorkOrder.Nurse.EmployeeId == vm.SelectedNurseId || (v.NurseReplacement != null && v.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId)).ToList();
            }
            else if (vm.SelectedNurseReplacementId > 0)
            {
                vm.Visits = vm.Visits.Where(v => v.NurseReplacement != null && v.NurseReplacement.EmployeeId == vm.SelectedNurseReplacementId).ToList();
            }
            else if (vm.SelectedNurseId > 0)
            {
                vm.Visits = vm.Visits.Where(v => v.WorkOrder.Nurse.EmployeeId == vm.SelectedNurseId).ToList();
            }
            if (vm.VisitDone != 0)
            {
                // TODO !!!!
                // BOOL VISITDONE IN VISIT MODEL !! DONE!
                if (vm.VisitDone == VisitFilterViewModel.VisitDoneEnum.Yes)
                    vm.Visits = vm.Visits.Where(v => v.Done).ToList();
                else
                    vm.Visits = vm.Visits.Where(v => !v.Done).ToList();
            }



            #endregion

            vm.Visits = vm.Visits.OrderBy(v => v.DateConfirmed).ToList();

            return View("Index", vm);
        }

    }
    
}