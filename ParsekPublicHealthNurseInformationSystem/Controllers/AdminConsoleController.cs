using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using ParsekPublicHealthNurseInformationSystem.Models;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class AdminConsoleController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: AdminConsole
        public ActionResult Index()
        {
            AdminConsoleViewModel acvm = new AdminConsoleViewModel();

            acvm.Contractors = DB.Contractors.ToList();
            acvm.Districts = DB.Districts.ToList();
            acvm.JobTitle = Employee.JobTitle.Doctor;

            return View(acvm);
        }

        [HttpPost]
        public ActionResult AddEmployee(AdminConsoleViewModel acvm)
        {

            int x;

            return View(acvm);
        }
    }
}