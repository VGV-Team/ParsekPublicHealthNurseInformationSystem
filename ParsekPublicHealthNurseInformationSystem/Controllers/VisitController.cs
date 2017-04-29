using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class VisitController : Controller
    {
        private EntityDataModel db = new EntityDataModel();

        // GET: Visits
        public ActionResult Index(int id)
        {
            // TODO: this should let user fill in general data, for patient specific data they should enter it on sperate page

            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == id);
            if(visit != null)
                return RedirectToAction("EnterData", "Visit", new { visitId = id, patientId = visit.WorkOrder.Patient.PatientId });
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult EnterData(int visitId, int patientId)
        {
            // TODO: return correct visit

            // Get correct visit
            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == visitId);
            if (visit == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Get correct patient
            Patient patient = null;
            if (visit.WorkOrder.Patient.PatientId == patientId)
            {
                patient = visit.WorkOrder.Patient;
            }
            else
            {


                // FIXIT: Problem with lazy loading...
                //PatientWorkOrder pwo = db.PatientWorkOrders.FirstOrDefault(x => x.Patient.PatientId == patientId &&
                //                                         x.WorkOrder.WorkOrderId == visit.WorkOrder.WorkOrderId);

                patient = db.Patients.FirstOrDefault(x => x.PatientId == patientId && 
                                                            x.PatientWorkOrders.FirstOrDefault(y => y.WorkOrder.WorkOrderId == visit.WorkOrder.WorkOrderId) != null);

                if (patient == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // todo: select auto fill values
            // select all activities
            // select all visit inputs
            // select activities for required patient



            VisitViewModel vvm = new VisitViewModel();
            vvm.VisitId = visit.VisitId;
            vvm.PatientId = patient.PatientId;
            vvm.ActivityInputs = new List<VisitViewModel.Input>();
            vvm.ActivityInputIds = new List<int>();
            vvm.ActivityInputValues = new List<string>();

            // Select all activities for selected service.
            List<Activity> activities = db.Activities.Where(x => x.Service.ServiceId == visit.WorkOrder.Service.ServiceId).ToList();
            foreach (Activity activity in activities)
            {
                VisitViewModel.Input inputs = new VisitViewModel.Input();
                inputs.ActivityTitle = activity.ActivityTitle;

                // Select all inputs for selected activity.
                List<ActivityInput> activityInputs = db.ActivityInputs.Where(x => x.Activity.ActivityId == activity.ActivityId).ToList();
                inputs.ActivityInputDatas = new List<VisitViewModel.Input.InputData>();

                List<Visit> visits = visit.WorkOrder.Visits.ToList();
                visits.Sort((x, y) => DateTime.Compare(y.DateConfirmed, x.DateConfirmed));
                Visit firstVisit = visits.First();

                foreach (var activityInput in activityInputs)
                {
                    VisitViewModel.Input.InputData inputData = new VisitViewModel.Input.InputData();
                    inputData.ActivityInputId = activityInput.ActivityInputId;
                    inputData.ActivityInputTitle = activityInput.Title;
                    //inputData.ActivityInputValue = "";

                    inputData.InputType = activityInput.InputType;
                    inputData.Required = activityInput.Required;
                    

                    List<string> possibleValues = activityInput.PossibleValues.Split(new string[] { ";;" }, StringSplitOptions.None).ToList();
                    inputData.PossibleValues = possibleValues;


                    int correctVisitId; //correct = first or current

                    inputData.ReadOnly = false;

                    if (activityInput.OneTime)
                    {
                        correctVisitId = firstVisit.VisitId;
                        if (visit.VisitId != correctVisitId)
                            inputData.ReadOnly = true;
                    }
                    else
                    {
                        correctVisitId = visit.VisitId;
                        
                    }
                    ActivityInputData input = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == inputData.ActivityInputId &&
                                                                                                      x.Visit.VisitId == correctVisitId);
                    vvm.ActivityInputValues.Add(input == null ? "" : input.Value);


                    inputs.ActivityInputDatas.Add(inputData);

                    vvm.ActivityInputIds.Add(activityInput.ActivityInputId);

                   
                }

                vvm.ActivityInputs.Add(inputs);
            }

            return View("Index", vvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveData(VisitViewModel vvm)
        {
            // TODO: do validation
            // TODO: multiple patients

            for (int i = 0; i < vvm.ActivityInputIds.Count; i++)
            {
                int activityInputId = vvm.ActivityInputIds[i];
                ActivityInputData aiwo = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == activityInputId && 
                                                                                                         x.Visit.VisitId == vvm.VisitId);
                if(aiwo == null)
                {
                    aiwo = new ActivityInputData();
                    aiwo.Visit = db.Visits.FirstOrDefault(x => x.VisitId == vvm.VisitId);
                    aiwo.ActivityInput = db.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == activityInputId);
                    aiwo.Value = vvm.ActivityInputValues[i];
                    aiwo.Patient = db.Patients.FirstOrDefault(x => x.PatientId == vvm.PatientId);
                    db.ActivityInputDatas.Add(aiwo);
                }
                else
                {
                    aiwo.Value = vvm.ActivityInputValues[i];
                }
            }

            db.SaveChanges();

            return RedirectToAction("EnterData", "Visit", new { visitId = vvm.VisitId, patientId = vvm.PatientId } );
        }
    }   
}
