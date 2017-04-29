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
            }
            else
            {
                vm.Visit = DB.Visits.Find(visitId);
            }
           
            return View(vm);
        }
    }
}