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
    public class VisualizationController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: Visualization
        public ActionResult Index(int id)
        {
            VisualizationViewModel vvm = new VisualizationViewModel();
            vvm.MainPatientId = id;

            return View("Index", vvm);
        }

        public ActionResult Show(VisualizationViewModel vvm)
        {
            if (vvm == null)
            {
                if ((Session["user"] as Models.User).Patient != null)
                    return RedirectToAction("Index", new {id = (Session["user"] as Models.User).Patient.PatientId});
                else
                    return RedirectToAction("Index", "Home");

            }
            else
            {
                List<ActivityInputData> datas =
                    DB.ActivityInputDatas.Where(x => x.Patient.PatientId == vvm.MainPatientId &&
                                                     x.Visit.DateConfirmed >= vvm.DateStart &&
                                                     x.Visit.DateConfirmed <= vvm.DateEnd &&
                                                     (String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.SystolicBloodPressureTitle, StringComparison.Ordinal) == 0 ||
                                                     String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.DiastolicBloodPressureTitle, StringComparison.Ordinal) == 0)
                                                     ).ToList();



                vvm.Dates = datas.Select(x => x.Visit.DateConfirmed).ToArray().Distinct().ToList();
                vvm.SystolicValues = datas.Where(x => String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.SystolicBloodPressureTitle, StringComparison.Ordinal) == 0).Select(y => double.Parse(y.Value)).ToList();
                vvm.DiastolicValues = datas.Where(x => String.Compare(x.ActivityActivityInput.ActivityInput.Title, Globals.DiastolicBloodPressureTitle, StringComparison.Ordinal) == 0).Select(y => double.Parse(y.Value)).ToList();
                /*
                foreach (var data in datas)
                {
                    VisualizationViewModel.Data newData = new VisualizationViewModel.Data();
                    newData.Date = data.Visit.DateConfirmed;
                    ActivityInputData systolicData = datas.FirstOrDefault(x =>
                                    String.Compare(x.ActivityActivityInput.ActivityInput.Title, "Sistolični (mm Hg)",
                                        StringComparison.Ordinal) == 0);
                    ActivityInputData diastolicData = datas.FirstOrDefault(x =>
                                    String.Compare(x.ActivityActivityInput.ActivityInput.Title, "Diastolični (mm Hg)",
                                        StringComparison.Ordinal) == 0);

                    newData.SystolicValue = systolicData != null ? double.Parse(systolicData.Value) : 0;
                    newData.DiastolicValue = diastolicData != null ? double.Parse(diastolicData.Value) : 0;

                    vvm.Datas.Add(newData);
                }
                */
            }


            return View("Index", vvm);
        }
    }
}