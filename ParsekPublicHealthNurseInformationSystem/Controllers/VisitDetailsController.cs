using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.RoleEnum.Employee)]
    public class VisitDetailsController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(int? visitId)
        {
            VisitDetailsViewModel vm = new VisitDetailsViewModel();

            if (visitId == null)
            {
                vm.Visit = null;
                vm.ActivityInputs = null;
            }
            else
            {
                vm.Visit = DB.Visits.Find(visitId);
                /*vm.ActivityInputs = new List<ActivityInput>();
                for (int i = 0; i < vm.Visit.ActivityInputDatas.Count; i++)
                {
                    ActivityInputData AID = DB.ActivityInputDatas.Find(vm.Visit.ActivityInputDatas.ElementAt(i).ActivityInputDataId);
                    vm.ActivityInputs.Add(AID.ActivityInput);
                }*/
            }

            //ActivityInputData AI = DB.ActivityInputDatas.Find(1);
           
            return View(vm);
        }
    }
}