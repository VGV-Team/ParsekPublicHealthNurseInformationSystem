using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class EditVisitInputController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(EditVisitInputViewModel vm, int? serviceId)
        {
            if (vm == null)
            {
                vm = new EditVisitInputViewModel();
                vm.SelectedVisitType = -1;
            }

            if (serviceId != null && vm.SelectedVisitType <= 0)
            {
                vm.SelectedVisitType = (int)serviceId;
                return Index(vm, null);
            }
            
            vm.ActivityInputList = new List<ActivityInput>();
            vm.InputActivityList = new List<Activity>();

            vm.VisitTypesList = DB.Services.ToList();
            
            
            if (vm.SelectedVisitType != null && vm.SelectedVisitType > 0)
            {
                vm.ActivityInputList = DB.ActivityInputs.Where(ai => ai.Activity.Service.ServiceId == vm.SelectedVisitType &&
                                                                     ai.InputType == ActivityInput.InputTypeEnum.Number)
                                                                     .ToList();

                vm.InputActivityList = DB.Services.Find(vm.SelectedVisitType).Activities.ToList();
            }


            return View(vm);
        }

        public ActionResult DeleteInput(int? visitInputId, int serviceId)
        {

            if (visitInputId != null)
            {
                try
                {
                    Models.ActivityInput AI = DB.ActivityInputs.Find(visitInputId);

                    // Do we need this?
                    AI.Activity = null;

                    for (int i = 0; i < AI.ActivityInputDatas.Count; i++)
                    {
                        DB.ActivityInputDatas.Remove(AI.ActivityInputDatas.ElementAt(i));
                    }
                    

                    DB.ActivityInputs.Remove(AI);
                    DB.SaveChanges();
                }
                catch (Exception e)
                {
                    int x = 10;
                }
            }

            return RedirectToAction("Index", new {  serviceId = serviceId });
        }

        public ActionResult AddInput(EditVisitInputViewModel vm)
        {
            try
            {
                if (vm.SelectedInputActivity > 0)
                {
                    Models.ActivityInput AI = new ActivityInput();
                    AI.Activity = DB.Activities.Find(vm.SelectedInputActivity);
                    AI.InputType = ActivityInput.InputTypeEnum.Number;
                    AI.OneTime = false;
                    AI.Required = vm.InputRequired;
                    AI.Title = vm.InputTitle;
                    string possibleValues = vm.InputMinValue + ";;" + vm.InputMaxValue;
                    AI.PossibleValues = possibleValues;
                    DB.ActivityInputs.Add(AI);
                    DB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //ERROR
                int x = 10;
            }

            vm.SelectedInputActivity = -1;
            vm.InputMaxValue = 10000;
            vm.InputMinValue = 0;
            vm.InputRequired = false;
            vm.InputTitle = "";


            return RedirectToAction("Index", new { serviceId = vm.SelectedVisitType });
        }
    }
}