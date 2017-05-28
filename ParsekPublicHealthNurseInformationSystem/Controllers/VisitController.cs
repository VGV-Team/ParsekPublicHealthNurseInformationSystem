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
    [AuthorizationFilter(Role.Employee)]
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
            vvm.ActivityIds = new List<int>();
            vvm.ActivityInputValues = new List<string>();
            vvm.VisitDate = visit.DateConfirmed;

            Patient patient = null;
            bool isMainPatientSelected = false;
            if (patientId != null) // If patientId is not null then we are requesting data for specific patient.
            {
                // Get correct patient
                if (visit.WorkOrder.Patient.PatientId == patientId)
                {
                    patient = visit.WorkOrder.Patient;
                    isMainPatientSelected = true;
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
                        isMainPatientSelected = false;
                    }
                }
                vvm.PatientId = patient.PatientId;

                // Select all activities for selected service.

                //List<ServiceActivity> allact = db.Activities.Select(x => x.ServiceActivities).ToList();

                List<Activity> activities = db.Activities.Where(x => x.ServiceActivities.Any(
                    sa => sa.Service.ServiceId == visit.WorkOrder.Service.ServiceId && 
                        (sa.Active == true || db.ActivityInputDatas.Any(
                            aid => aid.Visit.VisitId == visit.VisitId && 
                                    aid.Value != null && aid.Value != "" && 
                                    aid.ActivityActivityInput.Activity.ActivityId == sa.Activity.ActivityId)
                    ))
                    && ( x.ActivityActivityInputs.Any(y => y.ActivityInputFor == ActivityActivityInput.InputForType.All ||
                            y.ActivityInputFor == ActivityActivityInput.InputForType.ParentOnly && isMainPatientSelected ||
                            y.ActivityInputFor == ActivityActivityInput.InputForType.PatientOnly && !isMainPatientSelected
                    ))).ToList();
                


                activities = activities.OrderByDescending(a => a.ActivityActivityInputs.Any(ai => ai.ActivityInput.InputType == ActivityInput.InputTypeEnum.Number)).ToList();

                

                List<Visit> visits = visit.WorkOrder.Visits.ToList();
                visits = visits.OrderBy(v => v.DateConfirmed).ToList();
                Visit firstVisit = visits.First();
                vvm.MeasurmentsCount = 0;

                foreach (Activity activity in activities)
                {
                    //if(patientId == null && !activity.ActivityInputFor || patientId != null && activity.ActivityInputFor) // Skip if activity is/is not general.
                    //    continue;

                    if (activity.ActivityActivityInputs.Any(ai => ai.ActivityInput.InputType == ActivityInput.InputTypeEnum.Number) == true)
                    {
                        vvm.MeasurmentsCount += 1;
                    }

                    VisitViewModel.Input inputs = new VisitViewModel.Input();
                    inputs.ActivityTitle = activity.ActivityTitle;

                    // Select all inputs for selected activity.
                    List<ActivityInput> activityInputs = db.ActivityInputs.Where(x => x.ActivityActivityInputs.Any(y => y.Activity.ActivityId == activity.ActivityId && (y.Active == true || db.ActivityInputDatas.Any(
                                                                                                                                                                                            aid => aid.Visit.VisitId == visit.VisitId &&
                                                                                                                                                                                                    aid.Value != null && aid.Value != "" &&
                                                                                                                                                                                                    aid.ActivityActivityInput.Activity.ActivityId == y.Activity.ActivityId &&
                                                                                                                                                                                                    aid.ActivityActivityInput.ActivityInput.ActivityInputId == y.ActivityInput.ActivityInputId)))).ToList();
                    inputs.ActivityInputDatas = new List<VisitViewModel.Input.InputData>();


                    foreach (var activityInput in activityInputs)
                    {
                        VisitViewModel.Input.InputData inputData = new VisitViewModel.Input.InputData();
                        inputData.ActivityInputId = activityInput.ActivityInputId;
                        inputData.ActivityInputTitle = activityInput.Title;
                        //inputData.ActivityInputValue = "";

                        inputData.InputType = activityInput.InputType;
                        inputData.Required = activityInput.ActivityActivityInputs.FirstOrDefault(x => x.Activity.ActivityId == activity.ActivityId && 
                                                                                                    x.ActivityInput.ActivityInputId == activityInput.ActivityInputId).Required;
                    

                        List<string> possibleValues = activityInput.PossibleValues.Split(new string[] { ";;" }, StringSplitOptions.None).ToList();
                        inputData.PossibleValues = possibleValues;


                        int correctVisitId; //correct = first or current

                        inputData.ReadOnly = false;

                        if (activityInput.ActivityActivityInputs.FirstOrDefault(x => x.Activity.ActivityId == activity.ActivityId &&
                                                                                x.ActivityInput.ActivityInputId == activityInput.ActivityInputId).OneTime)
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
                            input = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityActivityInput.ActivityInput.ActivityInputId == inputData.ActivityInputId &&
                                                                                                          x.ActivityActivityInput.Activity.ActivityId == activity.ActivityId &&
                                                                                                          x.Visit.VisitId == correctVisitId &&
                                                                                                          x.Patient == null);

                        }
                        else
                        {
                            input = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityActivityInput.ActivityInput.ActivityInputId == inputData.ActivityInputId &&
                                                                                                          x.ActivityActivityInput.Activity.ActivityId == activity.ActivityId &&
                                                                                                          x.Visit.VisitId == correctVisitId &&
                                                                                                          x.Patient.PatientId == patient.PatientId);

                        }

                        vvm.ActivityInputValues.Add(input == null ? "" : input.Value);


                        inputs.ActivityInputDatas.Add(inputData);

                        vvm.ActivityInputIds.Add(activityInput.ActivityInputId);
                        vvm.ActivityIds.Add(activity.ActivityId);


                    }

                    vvm.ActivityInputs.Add(inputs);
                }

            }
            else // If patientId is null then we are requesting general data.
            {
                // Select all patients related to visit
                vvm.MainPatient = db.Patients.FirstOrDefault(x => x.PatientId == visit.WorkOrder.Patient.PatientId);

                //vvm.PatientId = vvm.MainPatient.PatientId;
                //patientId = vvm.PatientId;

                List<Patient> patients = new List<Patient>();
                foreach (var patientWorkOrders in visit.WorkOrder.PatientWorkOrders)
                {
                    patients.Add(patientWorkOrders.Patient);
                }
                vvm.ChildPatients = patients;
                
                if (patients.Count == 0)
                {
                //    return RedirectToAction("EnterData", "Visit", new { visitId = visitId, patientId = vvm.MainPatient } );
                }
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
                int activityId = vvm.ActivityIds[i];

                ActivityInputData aiwo;
                if (patient == null)
                {
                    // TODO: ALSO CHECK ACTIVITY!
                    aiwo = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityActivityInput.ActivityInput.ActivityInputId == activityInputId &&
                                                                                                         x.ActivityActivityInput.Activity.ActivityId == activityId &&
                                                                                                         x.Visit.VisitId == vvm.VisitId &&
                                                                                                         x.Patient == null);
                }
                else
                {
                    // TODO: ALSO CHECK ACTIVITY!
                    aiwo = db.ActivityInputDatas.FirstOrDefault(x => x.ActivityActivityInput.ActivityInput.ActivityInputId == activityInputId &&
                                                                                                         x.ActivityActivityInput.Activity.ActivityId == activityId &&
                                                                                                         x.Visit.VisitId == vvm.VisitId &&
                                                                                                         x.Patient.PatientId == patient.PatientId);
                }

                if(aiwo == null)
                {
                    aiwo = new ActivityInputData();
                    aiwo.Visit = db.Visits.FirstOrDefault(x => x.VisitId == vvm.VisitId);

                    //HORRIBLE!
                    //List<Activity> currentActivities = aiwo.Visit.WorkOrder.Service.ServiceActivities.Select(x => x.Activity).ToList();
                    //List<ActivityActivityInput> aais = db.ActivityActivityInputs.Where(x => x.ActivityInput.ActivityInputId == activityInputId).ToList();
                    //aiwo.ActivityActivityInput = aais.FirstOrDefault(x => currentActivities.Any(ca => ca.ActivityId == x.Activity.ActivityId));
                    aiwo.ActivityActivityInput = db.ActivityActivityInputs.FirstOrDefault(x => x.ActivityInput.ActivityInputId == activityInputId && x.Activity.ActivityId == activityId);
                    //aiwo.ActivityActivityInput.ActivityInput = db.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == activityInputId);


                    aiwo.Visit.Done = true;
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
