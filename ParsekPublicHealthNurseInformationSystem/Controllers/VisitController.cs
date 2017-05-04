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
    [AuthorizationFilter(Role.RoleEnum.Employee, Role.RoleEnum.Patient)]
    public class VisitController : Controller
    {
        private EntityDataModel db = new EntityDataModel();

        // GET: Visits
        public ActionResult Index(int visitId)
        {
            return RedirectToAction("EnterData", "Visit", new { visitId = visitId });
        }

        public ActionResult EnterData(int visitId, int? patientId = null)
        {
            // Get correct visit
            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == visitId);
            if (visit == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // todo: select auto fill values
            // select all activities
            // select all visit inputs
            // select activities for required patient



            VisitViewModel vvm = new VisitViewModel();
            vvm.VisitId = visit.VisitId;
            vvm.ActivityInputs = new List<VisitViewModel.Input>();
            vvm.ActivityInputIds = new List<int>();
            vvm.ActivityInputValues = new List<string>();
            vvm.VisitDate = visit.DateConfirmed;

            Patient patient = null;
            if (patientId != null) // If patientId is not null then we are requesting data for specific patient.
            {
                // Get correct patient
                if (visit.WorkOrder.Patient.PatientId == patientId)
                {
                    patient = visit.WorkOrder.Patient;
                }
                else
                {
                    PatientWorkOrder pwo = db.PatientWorkOrders.FirstOrDefault(x => x.Patient.PatientId == patientId &&
                                                             x.WorkOrder.WorkOrderId == visit.WorkOrder.WorkOrderId);

                    if (pwo == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        patient = pwo.Patient;
                    }
                }
                vvm.PatientId = patient.PatientId;
            }
            else // If patientId is null then we are requesting general data.
            {
                // Select all patients related to visit
                vvm.MainPatient = db.Patients.FirstOrDefault(x => x.PatientId == visit.WorkOrder.Patient.PatientId);

                List<Patient> patients = new List<Patient>();
                foreach (var patientWorkOrders in visit.WorkOrder.PatientWorkOrders)
                {
                    patients.Add(patientWorkOrders.Patient);
                }
                vvm.ChildPatients = patients;
            }

            // Select all activities for selected service.
            List<Activity> activities = db.Activities.Where(x => x.Service.ServiceId == visit.WorkOrder.Service.ServiceId).ToList();

            List<Visit> visits = visit.WorkOrder.Visits.ToList();
            visits = visits.OrderBy(v => v.DateConfirmed).ToList();
            Visit firstVisit = visits.First();

            foreach (Activity activity in activities)
            {
                if(patientId == null && !activity.GeneralActivity || patientId != null && activity.GeneralActivity) // Skip if activity is/is not general.
                    continue;

                VisitViewModel.Input inputs = new VisitViewModel.Input();
                inputs.ActivityTitle = activity.ActivityTitle;

                // Select all inputs for selected activity.
                List<ActivityInput> activityInputs = db.ActivityInputs.Where(x => x.Activity.ActivityId == activity.ActivityId).ToList();
                inputs.ActivityInputDatas = new List<VisitViewModel.Input.InputData>();


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

                    ActivityInputData input;
                    if (patient == null)
                    {
                        input = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == inputData.ActivityInputId &&
                                                                                                      x.Visit.VisitId == correctVisitId &&
                                                                                                      x.Patient == null);

                    }
                    else
                    {
                        input = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == inputData.ActivityInputId &&
                                                                                                      x.Visit.VisitId == correctVisitId &&
                                                                                                      x.Patient.PatientId == patient.PatientId);

                    }

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


            Patient patient = null;
            if(vvm.PatientId != null)
            {
                patient = db.Patients.FirstOrDefault(x => x.PatientId == vvm.PatientId);
            }
            for (int i = 0; i < vvm.ActivityInputIds.Count; i++)
            {
                int activityInputId = vvm.ActivityInputIds[i];

                ActivityInputData aiwo;
                if (patient == null)
                {
                    aiwo = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == activityInputId &&
                                                                                                         x.Visit.VisitId == vvm.VisitId &&
                                                                                                         x.Patient == null);
                }
                else
                {
                    aiwo = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityInput.ActivityInputId == activityInputId &&
                                                                                                         x.Visit.VisitId == vvm.VisitId &&
                                                                                                         x.Patient.PatientId == patient.PatientId);
                }

                if(aiwo == null)
                {
                    aiwo = new ActivityInputData();
                    aiwo.Visit = db.Visits.FirstOrDefault(x => x.VisitId == vvm.VisitId);
                    aiwo.Visit.Confirmed = true;
                    aiwo.ActivityInput = db.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == activityInputId);
                    aiwo.Value = vvm.ActivityInputValues[i];
                    aiwo.Patient = patient;


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
