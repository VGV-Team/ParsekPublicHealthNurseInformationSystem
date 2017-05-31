using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class VisualizationController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: Visualization
        public ActionResult Index(VisualizationViewModel vvm)
        {
            if (vvm == null)
            {
                vvm = new VisualizationViewModel();
                vvm.MainPatientId = (Session["user"] as Models.User).Patient.PatientId;
            }
            else
            {
                DateTime startDate = vvm.DateStart;
                DateTime endDate = vvm.DateEnd;

                vvm.Datas =
                    DB.ActivityInputDatas.Where(
                        x =>
                            x.Patient.PatientId == vvm.MainPatientId &&
                            (x.ActivityActivityInput.ActivityInput.Title == "Sistolični (mm Hg)" ||
                             x.ActivityActivityInput.ActivityInput.Title == "Diastolični (mm Hg)")).ToList();
                //List<int> Values = ActivityInputDatas.Select(y => y.Value).ToList().ConvertAll(int.Parse);
                //List<DateTime> Dates = 
            }


            return View("Index", vvm);
        }
    }
}