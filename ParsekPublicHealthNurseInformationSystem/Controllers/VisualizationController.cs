using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(JobTitle.Doctor, JobTitle.HealthNurse, Role.Patient)]
    public class VisualizationController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: Visualization
        public ActionResult Index(VisualizationViewModel vvm)
        {
            if (vvm == null)
            {
                vvm = new VisualizationViewModel();
            }

            if (vvm.PatientId != null)
            {
                int[] ids = Globals.GetIdsFromString(vvm.PatientId);
                if (ids.Length == 1)
                {
                    int id = ids.FirstOrDefault();
                    Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                    if (patient != null)
                    {
                        vvm.MainPatientId = id;
                        return RedirectToAction("Show", "Visualization", new { id = vvm.MainPatientId });
                    }
                }
            }

            User user = (Session["user"] as User);
            if (user?.Employee != null)
                vvm.Patients = DB.Patients.ToList();
            else if (user?.Patient != null)
            {
                User patient = DB.Users.FirstOrDefault(x => x.UserId == user.UserId);
                if (patient != null)
                    vvm.Patients = DB.Patients.Where(x => x.PatientId == patient.Patient.PatientId || x.ParentPatientId == patient.Patient.PatientId).ToList();
            }
            else
                vvm.Patients = new List<Patient>();

            return View("Index", vvm);
        }

        public ActionResult Show(VisualizationViewModel vvm, int? id)
        {
            if (!(vvm != null && vvm.MainPatientId != null && DB.Patients.Count(x => x.PatientId == vvm.MainPatientId) == 1 ||
                id != null && DB.Patients.Count(x => x.PatientId == id) == 1))
            {
                return RedirectToAction("Index", "Visualization");
            }

            if (vvm == null)
            {
                vvm = new VisualizationViewModel();
                vvm.MainPatientId = id;
            }
            if(vvm.MainPatientId == null)
            {
                vvm.MainPatientId = id;
            }
            

            List<ActivityInputData> datas =
                    DB.ActivityInputDatas.Where(x => x.Patient.PatientId == vvm.MainPatientId &&
                                                     x.Visit.DateConfirmed >= vvm.DateStart &&
                                                     x.Visit.DateConfirmed <= vvm.DateEnd &&
                                                     (String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.SystolicBloodPressureTitle, StringComparison.Ordinal) == 0 ||
                                                     String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.DiastolicBloodPressureTitle, StringComparison.Ordinal) == 0)
                                                     ).ToList();



            vvm.Dates = datas.OrderBy(z => z.Visit.DateConfirmed).Select(x => x.Visit.DateConfirmed).ToArray().Distinct().ToList();
            vvm.SystolicValues = datas.Where(x => String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.SystolicBloodPressureTitle, StringComparison.Ordinal) == 0).OrderBy(z => z.Visit.DateConfirmed).Select(y => double.Parse(y.Value)).ToList();
            vvm.DiastolicValues = datas.Where(x => String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.DiastolicBloodPressureTitle, StringComparison.Ordinal) == 0).OrderBy(z => z.Visit.DateConfirmed).Select(y => double.Parse(y.Value)).ToList();


            return View("Show", vvm);
        }
    }
}