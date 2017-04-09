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
            if (lvm.ViewMessage == "qwe")
                return View("~/Views/Home/Index.cshtml");
            else
                return View("Index", lvm);
        }

        public static string GetExternalClientIP()
        {
            char[] separator1 = { '<' };
            char[] separator2 = { '>' };
            using (var _webClient = new System.Net.WebClient())
                return _webClient.DownloadString("http://whatismyip.org").Split(separator1)[27].Split(separator2)[1];
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            
            try
            {
                string visitorIPAddress = GetExternalClientIP();

                if (lvm.Email.IsNullOrWhiteSpace()||
                    lvm.Password.IsNullOrWhiteSpace())
                {
                    lvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(lvm);
                }
                if(DB.Users.Where(u => u.Email == lvm.Email).FirstOrDefault() == null)
                {
                    lvm.ViewMessage = "Preverite vnešeni e-mail";
                    return Form(lvm);
                }

                Models.User user = DB.Users.Where(u => u.Email == lvm.Email).FirstOrDefault();
                if(user.Password != lvm.Password)
                {
                    lvm.ViewMessage = "Vnešeno geslo je napačno ";
                    return Form(lvm);
                }
                
                if(user.Active == false)
                {
                    lvm.ViewMessage = "E-mail ni aktiviran";
                    return Form(lvm);
                }

                Session["user"] = user;
                lvm.ViewMessage = "qwe";
                //return Redirect(Request.Url.Authority);
                

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
            return Redirect("/");
        }
    }
}