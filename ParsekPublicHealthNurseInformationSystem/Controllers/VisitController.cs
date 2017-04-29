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
            // TODO: return correct visit
            
            Visit visit = db.Visits.FirstOrDefault(x => x.VisitId == id);

            // todo: select auto fill values
            // select all activities
            // select all visit inputs



            VisitViewModel vvm = new VisitViewModel();
            vvm.VisitId = visit.VisitId;
            vvm.ActivityInputs = new List<VisitViewModel.Input>();
            vvm.ActivityInputIds = new List<int>();
            vvm.ActivityInputValues = new List<string>();


            List<Activity> activities = db.Activities.Where(x => x.Service.ServiceId == visit.WorkOrder.Service.ServiceId).ToList();
            for (int i = 0; i < activities.Count; i++)
            {
                VisitViewModel.Input inputs = new VisitViewModel.Input();
                inputs.ActivityTitle = activities[i].ActivityTitle;

                int activityId = activities[i].ActivityId;
                List<ActivityInput> activityInputs = db.ActivityInputs.Where(x => x.Activity.ActivityId == activityId).ToList();
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


            return View(vvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnterData(VisitViewModel vvm)
        {
            // TODO: check if we can save only once instead of in loop
            // TODO: do validation

            /*
            for (int i = 0; i < vvm.ActivityInputs.Count; i++)
            {
                for (int j = 0; j < vvm.ActivityInputs[i].ActivityInputDatas.Count; j++)
                {
                    ActivityInputData aiwo = new ActivityInputData();

                    aiwo.Value = vvm.ActivityInputs[i].ActivityInputDatas[j].ActivityInputValue;
                    aiwo.Visit = db.Visits.FirstOrDefault(x => x.VisitId == vvm.VisitId);

                    int activityInputId = vvm.ActivityInputs[i].ActivityInputDatas[j].ActivityInputId;
                    aiwo.ActivityInput = db.ActivityInputs.FirstOrDefault(x => x.ActivityInputId == activityInputId);

                    db.ActivityInputDatas.Add(aiwo);
                }
            }
            */

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
                    db.ActivityInputDatas.Add(aiwo);
                    db.SaveChanges();
                }
                else
                {
                    aiwo.Value = vvm.ActivityInputValues[i];
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Visit", new { id = vvm.VisitId } );
        }
    }   
}
