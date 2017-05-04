using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(ForgotPasswordViewModel vm)
        {
            if (vm == null)
            {
                vm = new ForgotPasswordViewModel();
            }

            ModelState.Clear();

            return View("Index", vm);
        }

        public ActionResult Submit(ForgotPasswordViewModel vm)
        {

            try
            {
                if (vm.Email.IsNullOrWhiteSpace() ||
                vm.Password.IsNullOrWhiteSpace() ||
                vm.PasswordRepeat.IsNullOrWhiteSpace())
                {
                    vm.ViewMessage = "Preverite vnešene podatke!";
                    return Index(vm);
                }

                if (vm.Password != vm.PasswordRepeat)
                {
                    vm.ViewMessage = "Gesli se ne ujemata!";
                    return Index(vm);
                }

                if (vm.Password.Length < 8 || vm.PasswordRepeat.Length < 8)
                {
                    vm.ViewMessage = "Eno izmed gesel je prekratko!";
                    return Index(vm);
                }

                if (!vm.Password.Any(c => char.IsDigit(c)))
                {
                    vm.ViewMessage = "Geslo mora vsebovati vsaj eno številko!";
                    return Index(vm);
                }

                Models.User user = DB.Users.Where(u => u.Email == vm.Email).FirstOrDefault();

                if (user == null)
                {
                    vm.ViewMessage = "Uporabnik s tem email naslovom ne obstaja!";
                    return Index(vm);
                }


                user.Password = vm.Password;
                DateTime emailExpire = DateTime.Now.AddHours(1);
                user.EmailExpire = emailExpire;
                user.LastLastLogin = DateTime.Now;
                user.LastLogin = DateTime.Now;
                user.Active = false;

                #region Email

                // Same as above just with gmail email.
                string username = "travianus.team@gmail.com";
                string password = "developer";
                string baseUrl = Request.Url.Authority;
                MailMessage mail = new MailMessage("registracija@parsek.si", user.Email);
                mail.From = new MailAddress("registracija@parsek.si", "Parsek");
                mail.Subject = "Pozabljeno geslo za Parsek IS";
                mail.Body = "Pozdravljeni,\nPred kratkim ste zaprosili za spremembo pozabljenega gesla. S klikom na spodnjo povezava aktivirate vaš račun z novim geslom: \n" +
                    "http://" + baseUrl + "/Register/EmailActivation?userEmail=" + user.Email + "&emailCode=" + user.EmailCode + "\n" +
                    "\n\nOb aktivaciji boste avtomatsko prijavljeni. Povezava velja do " + emailExpire.ToString("d.M.yyyy HH:mm") + ".";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential(username, password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Send(mail);

                #endregion

                DB.SaveChanges();

                vm.ViewMessage = "Sprememba uspešna! Na email smo vam poslali nadaljnja navodila.";

            }
            catch (Exception e)
            {
                vm.ViewMessage = "Prišlo je do napake!";
            }

            return Index(vm);

        }
    }
}