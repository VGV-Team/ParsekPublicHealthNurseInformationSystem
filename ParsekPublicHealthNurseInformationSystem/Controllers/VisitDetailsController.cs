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

            vm.Categories = new List<string>();
            vm.CategoryItemCount = new List<int>();
            vm.ParsedDetails = new List<string>();
            vm.ParsedDetailsTitles = new List<string>();

            if (visitId == null)
            {
                //vm.Visit = null;
                //vm.ActivityInputs = null;
            }
            else
            {
                vm.Visit = DB.Visits.Find(visitId);
                Visit visit = vm.Visit;

                visit.ActivityInputDatas.OrderBy(aid => aid.ActivityInput.Activity);

                int oldId = -1;
                int count = 0;
                bool first = true;

                for (int i = 0; i < visit.ActivityInputDatas.Count; i++)
                {
                    if (oldId != visit.ActivityInputDatas.ElementAt(i).ActivityInput.Activity.ActivityId)
                    {
                        oldId = visit.ActivityInputDatas.ElementAt(i).ActivityInput.Activity.ActivityId;
                        if (!first) vm.CategoryItemCount.Add(count);
                        first = false;
                        count = 0;
                        vm.Categories.Add(visit.ActivityInputDatas.ElementAt(i).ActivityInput.Activity.ActivityTitle);
                    }

                    vm.ParsedDetailsTitles.Add(visit.ActivityInputDatas.ElementAt(i).ActivityInput.Title);
                    vm.ParsedDetails.Add(visit.ActivityInputDatas.ElementAt(i).Value);
                    count += 1;
                }
                vm.CategoryItemCount.Add(count);
            }

            
           
            return View(vm);
        }
    }
}