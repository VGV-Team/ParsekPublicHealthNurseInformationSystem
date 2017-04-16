using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels.ChangePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.RoleEnum.Employee, Role.RoleEnum.Admin, Role.RoleEnum.Patient)]
    public class ChangePasswordController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();
        // GET: ChangePassword
        public ActionResult Index()
        {
            return Form(null);
        }

        public ActionResult Form(ChangePasswordViewModel cpvm)
        {
            if (cpvm == null)
                cpvm = new ChangePasswordViewModel();
            //cpvm.ViewMessage = "";
            return View("Index", cpvm);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel cpvm)
        {
            try {
                if (cpvm.Password1.IsNullOrWhiteSpace() ||
                       cpvm.Password2.IsNullOrWhiteSpace() ||
                       cpvm.OldPassword.IsNullOrWhiteSpace())
                {
                    cpvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(cpvm);
                }

                if (!cpvm.Password1.Any(c => char.IsDigit(c)))
                {
                    cpvm.ViewMessage = "Geslo mora vsebovati vsaj eno številko!";
                    return Form(cpvm);
                }

                if (cpvm.Password1 != cpvm.Password2)
                {
                    cpvm.ViewMessage = "Gesli se ne ujemata!";
                    return Form(cpvm);
                }

                

                Models.User tmp = (Models.User)Session["user"];
                Models.User user = DB.Users.FirstOrDefault(u => u.UserId == tmp.UserId);

                if (cpvm.OldPassword != user.Password)
                {
                    cpvm.ViewMessage = "Staro geslo ni pravilno!";
                    return Form(cpvm);
                }

                TempData["email"] = user.Email;
                user.Password = cpvm.Password1;
                DB.SaveChanges();
                cpvm.ViewMessage = "qwe";
                Session["user"] = null;
                return RedirectToAction("Index", "Login");
                //return Form(cpvm);
            }
            catch (Exception e)
            {
                cpvm.ViewMessage = "Prišlo je do hujše napake!";
                return Form(cpvm);
            }
        }
    }
}