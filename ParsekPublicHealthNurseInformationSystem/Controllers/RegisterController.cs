using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class RegisterController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        // GET: Register
        public ActionResult Index()
        {

            return Form(null);
        }

        public ActionResult Form(RegisterViewModel rvm)
        {

            if (rvm == null)
            {
                rvm = new RegisterViewModel();
            }

            
            rvm.Districts = DB.Districts.ToList();
            rvm.PostOffices = DB.PostOffices.ToList();

            //ModelState.Clear();

            return View("Index", rvm);
        }

        [HttpPost]
        public ActionResult AddPatient(AdminConsoleViewModel acvm)
        {

            // REGISTER

            return RedirectToAction("Index");
        }
    
}
}