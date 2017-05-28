using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using ParsekPublicHealthNurseInformationSystem.ViewModels.EditActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class EditActivityController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(EditActivityViewModel vm, int? activityId)
        {
            if (vm == null)
            {
                vm = new EditActivityViewModel();
                vm.SelectedActivity = -1;
            }

            if (activityId != null && vm.SelectedActivity <= 0)
            {
                vm.SelectedActivity = (int)activityId;
                return Index(vm, null);
            }

            vm.ActivityInputList = new List<ActivityInput>();
            vm.ActivityActivityInputList = new List<ActivityActivityInput>();

            vm.ActivityList = DB.Activities.ToList();


            if (vm.SelectedActivity != null && vm.SelectedActivity > 0)
            {
                //vm.ActivityInputList = DB.ActivityInputs.Where(ai => ai.Activity.ServiceActivities.Any(sa => sa.Service.ServiceId == vm.SelectedVisitType) &&
                //                                                     ai.InputType == ActivityInput.InputTypeEnum.Number)
                //                                                     .ToList();

                vm.ActivityInputList = DB.ActivityInputs.ToList();

                //vm.InputActivityList = DB.Services.Find(vm.SelectedVisitType).Activities.ToList();

                Activity tmpActivity = DB.Activities.Find(vm.SelectedActivity);

                vm.ActivityActivityInputList = tmpActivity.ActivityActivityInputs.Where(aai => aai.Active == true).ToList();

                List<int> Ids = vm.ActivityActivityInputList.Select(x => x.ActivityInput.ActivityInputId).ToList();

                vm.ActivityInputList = vm.ActivityInputList.Where(ai => Ids.Contains(ai.ActivityInputId) == false).ToList();

                //vm.ActivityInputList = DB.ActivityInputs.Where(ai => vm.ActivityInputList.Select(x => x.ActivityInputId).Contains(ai.ActivityInputId)).ToList();
               

            }


            return View(vm);
        }

        public ActionResult DeleteInput(int? activityInputId, int activityId)
        {

            if (activityInputId != null)
            {
                try
                {
                    //Models.ActivityInput AI = DB.ActivityInputs.Find(visitInputId);


                    // Do we need this?
                    //AI.Activity = null;

                    //for (int i = 0; i < AI.ActivityInputDatas.Count; i++)
                    //{
                    //    DB.ActivityInputDatas.Remove(AI.ActivityInputDatas.ElementAt(i));
                    //}


                    //DB.ActivityInputs.Remove(AI);

                    Models.ActivityActivityInput AAI = DB.ActivityActivityInputs.FirstOrDefault(x => x.Activity.ActivityId == activityId && x.ActivityInput.ActivityInputId == activityInputId);

                    AAI.Active = false;

                    DB.SaveChanges();
                }
                catch (Exception e)
                {
                    int x = 10;
                }
            }

            return RedirectToAction("Index", new { activityId = activityId });
        }

        public ActionResult AddInput(EditActivityViewModel vm)
        {
            try
            {
                if (vm.SelectedActivityInput > 0)
                {
                    /*Models.ActivityInput AI = new ActivityInput();
                    AI.Activity = DB.Activities.Find(vm.SelectedInputActivity);
                    AI.InputType = ActivityInput.InputTypeEnum.Number;
                    AI.OneTime = false;
                    AI.Required = vm.InputRequired;
                    AI.Title = vm.InputTitle;
                    string possibleValues = vm.InputMinValue + ";;" + vm.InputMaxValue;
                    AI.PossibleValues = possibleValues;
                    DB.ActivityInputs.Add(AI);
                    DB.SaveChanges();*/

                    Models.ActivityActivityInput AAI = DB.ActivityActivityInputs.FirstOrDefault(x => x.Activity.ActivityId == vm.SelectedActivity && x.ActivityInput.ActivityInputId == vm.SelectedActivityInput);

                    
                    
                    if (AAI == null)
                    {
                        Models.ActivityActivityInput newAAI = new ActivityActivityInput();

                        Models.Activity Act = DB.Activities.Find(vm.SelectedActivity);
                        Models.ActivityInput AI = DB.ActivityInputs.Find(vm.SelectedActivityInput);

                        newAAI.Activity = Act;
                        newAAI.ActivityInput = AI;
                        newAAI.Active = true;
                        newAAI.ActivityInputFor = vm.ActivityInputFor;
                        newAAI.OneTime = vm.OneTime;
                        newAAI.Required = vm.Required;

                        DB.ActivityActivityInputs.Add(newAAI);

                    }
                    else
                    {
                        AAI.Active = true;
                        AAI.ActivityInputFor = vm.ActivityInputFor;
                        AAI.OneTime = vm.OneTime;
                        AAI.Required = vm.Required;
                    }

                    DB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //ERROR
                int x = 10;
            }

            vm.SelectedActivityInput = -1;
            /*vm.InputMaxValue = 10000;
            vm.InputMinValue = 0;
            vm.InputRequired = false;
            vm.InputTitle = "";*/


            return RedirectToAction("Index", new { activityId = vm.SelectedActivity });
        }
    }
}