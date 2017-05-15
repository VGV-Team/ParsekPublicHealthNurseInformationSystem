using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.RoleEnum.Patient)]
    public class VisitPatientController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: WOFilter
        public ActionResult Index(VisitPatientViewModel vm)
        {


            if (vm == null)
            {
                vm = new VisitPatientViewModel();
            }


            return Filter(vm);
        }

        public ActionResult Filter(VisitPatientViewModel vm)
        {

            if (vm == null)
            {
                vm = new VisitPatientViewModel();
            }

            vm.MyPatientVisits = new List<VisitPatientViewModel.MyPatientVisit>();

            Models.User user = Session["user"] as Models.User;

            int patientId = user.Patient.PatientId;

            vm.Visits = DB.Visits.Where(v => v.WorkOrder.Patient.PatientId == patientId && 
                (v.Done))
                .OrderBy(v => v.DateConfirmed).ToList();

            for (int i = 0; i < user.Patient.ChildPatients.Count; i++)
            {
                int thisPatientId = user.Patient.ChildPatients.ElementAt(i).PatientId;
                VisitPatientViewModel.MyPatientVisit pv = new VisitPatientViewModel.MyPatientVisit();
                pv.Patient = user.Patient.ChildPatients.ElementAt(i);
                pv.Visits = DB.Visits.Where(v => v.WorkOrder.PatientWorkOrders.Any(pwo => pwo.Patient.PatientId == thisPatientId) &&
                (v.Done))
                .OrderBy(v => v.DateConfirmed).ToList();
                vm.MyPatientVisits.Add(pv);
            }


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
                if (current.Title == Employee.JobTitle.Doctor || current.Title == Employee.JobTitle.Head)
                {

                    // If I created this workroder
                    if (WO.Issuer.EmployeeId == current.EmployeeId)
                    {
                        // If WO has any done vists
                        if (WO.Visits.Any(v => v.DateConfirmed < DateTime.Now || v.Done))
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