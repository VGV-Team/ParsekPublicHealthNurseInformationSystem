using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        

        private EntityDataModel DB = new EntityDataModel();
        // GET: Login
        public ActionResult Index()
        {
            return Form(null);
        }

        public ActionResult Form(LoginViewModel lvm)
        {
            if (lvm == null)
            {
                lvm = new LoginViewModel();
            }
            if (TempData["email"] != null)
            {
                lvm.Email = TempData["email"].ToString();
                TempData["Email"] = null;
            }
            if (lvm.ViewMessage == "qwe")
                return RedirectToAction("Index", "Home");
            else
                return View("Index", lvm);
        }

        public ActionResult Login()
        {
            return Index();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            
            try
            {
                string visitorIPAddress = Request.UserHostAddress;
                if (lvm.Email.IsNullOrWhiteSpace()||
                    lvm.Password.IsNullOrWhiteSpace())
                {
                    lvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(lvm);
                }

                Models.IpLog ip = new Models.IpLog();
                if (DB.IpLogs.Where(i => i.Ips == visitorIPAddress).FirstOrDefault() == null)
                {
                    ip.counter = 0;
                    ip.Ips = visitorIPAddress;
                    ip.LastTry = DateTime.Now;
                    DB.IpLogs.Add(ip);
                }
                else
                {
                    ip = DB.IpLogs.Where(i => i.Ips == visitorIPAddress).FirstOrDefault();
                }

                if (ip.counter >= 2)
                {
                    if (ip.LastTry.AddMinutes(5) < DateTime.Now)
                    {
                        ip.counter = 0;
                    }
                    else
                    {
                        ip.LastTry = DateTime.Now;
                        lvm.ViewMessage = "IP locked. Poskusite znova ob " + ip.LastTry.AddMinutes(5).ToString("HH:mm");
                        DB.SaveChanges();
                        return Form(lvm);
                    }
                }


                if (DB.Users.FirstOrDefault(u => u.Email == lvm.Email) == null)
                {
                    if (ip.LastTry.AddMinutes(1) < DateTime.Now)
                    {
                        ip.counter = 1;
                    }
                    else
                    {
                        ip.counter++;
                    }
                    ip.LastTry = DateTime.Now;

                    DB.SaveChanges();
                    lvm.ViewMessage = "E-mail ali geslo je napačno";
                    return Form(lvm);
                }
              

                Models.User user = DB.Users.FirstOrDefault(u => u.Email == lvm.Email);
                if(user.Password != lvm.Password)
                {
                    if (ip.LastTry.AddMinutes(1) < DateTime.Now)
                    {
                        ip.counter = 1;
                    }
                    else
                    {
                        ip.counter++;
                    }
                    ip.LastTry = DateTime.Now;
                    
                    DB.SaveChanges();
                    lvm.ViewMessage = "E-mail ali geslo je napačno";
                    return Form(lvm);
                }
                
                if(user.Active == false)
                {
                    lvm.ViewMessage = "E-mail ni aktiviran";
                    return Form(lvm);
                }
                user.LastLastLogin = user.LastLogin;
                user.LastLogin = DateTime.Now;
                Session["user"] = user;
                lvm.ViewMessage = "qwe";
                //return Redirect(Request.Url.Authority);
                ip.counter = 1;
                DB.SaveChanges();

                return Form(lvm);
            }
            catch (Exception e)
            {
                lvm.ViewMessage = "Prišlo je do hujše napake!";
                return Form(lvm);
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}