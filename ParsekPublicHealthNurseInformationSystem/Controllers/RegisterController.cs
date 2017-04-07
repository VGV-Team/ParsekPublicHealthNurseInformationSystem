using Microsoft.Ajax.Utilities;
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

            //hack
            if (rvm.ViewMessage != "Neustrezen datum!")
                ModelState.Clear();

            return View("Index", rvm);
        }

        [HttpPost]
        public ActionResult AddPatient(RegisterViewModel rvm)
        {

            try
            {

                if (rvm.Email.IsNullOrWhiteSpace() ||
                    rvm.Address.ToString().IsNullOrWhiteSpace() ||
                    rvm.Name.IsNullOrWhiteSpace() ||
                    rvm.Number.IsNullOrWhiteSpace() ||
                    rvm.Password.IsNullOrWhiteSpace() ||
                    rvm.PasswordRepeat.IsNullOrWhiteSpace() ||
                    rvm.PhoneNumber.IsNullOrWhiteSpace() ||
                    rvm.Surname.IsNullOrWhiteSpace() ||
                    rvm.Gender.HasValue ||
                    rvm.SelectedDistrictId.ToString().IsNullOrWhiteSpace() ||
                    rvm.SelectedPostOfficeId.ToString().IsNullOrWhiteSpace()
                ) 
                {
                    rvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(rvm);
                }


                if (rvm.BirthDate > DateTime.UtcNow && rvm.BirthDate < DateTime.Parse("1/1/1900"))
                {
                    rvm.ViewMessage = "Neustrezen datum!";
                    return Form(rvm);
                }


                if (rvm.HasContactPerson)
                {
                    if (rvm.ContactAddress.IsNullOrWhiteSpace() ||
                        rvm.ContactName.IsNullOrWhiteSpace() ||
                        rvm.ContactPhone.IsNullOrWhiteSpace() ||
                        rvm.ContactRelationsip.IsNullOrWhiteSpace() ||
                        rvm.ContactSurname.IsNullOrWhiteSpace()
                    )
                    {
                        rvm.ViewMessage = "Vnesite vse podatke o kontaktni osebi!";
                        return Form(rvm);
                    }
                }

                if (DB.Users.Where(u => u.Email == rvm.Email).FirstOrDefault() != null)
                {
                    rvm.ViewMessage = "Pacient s tem e-mail naslovom že obstaja!";
                    return Form(rvm);
                }

                if (rvm.Password != rvm.PasswordRepeat)
                {
                    //acvm.ViewMessage = "Gesli se ne ujemata!";
                    return Form(rvm);
                }

                if (!rvm.Password.Any(c => char.IsDigit(c)))
                {
                    //acvm.ViewMessage = "Geslo mora vsebovati vsaj eno številko!";
                    return Form(rvm);
                }


                Models.Role role = DB.Roles.Where(r => r.Title == Role.RoleEnum.Patient).FirstOrDefault();

                Models.User user = new Models.User();
                user.Email = rvm.Email;
                user.Role = role;
                user.Password = rvm.Password;
                user.Employee = null;

                Models.Patient patient = new Models.Patient();
                /*if (rvm.JobTitle == Employee.JobTitle.HealthNurse)
                {
                    if (rvm.SelectedDistrictId <= 0)
                    {
                        rvm.ViewMessage = "Za patronažno sestro morate vnesti še okoliš!";
                        return Form(rvm);
                    }
                    patient.District = DB.Districts.Find(rvm.SelectedDistrictId);
                }*/
                patient.Name = rvm.Name;
                patient.Address = rvm.Address;
                patient.CardNumber = rvm.Number;
                patient.ContactAddress = rvm.ContactAddress;
                patient.ContactName = rvm.ContactName;
                patient.ContactPhone = rvm.ContactPhone;
                patient.ContactRelationship = rvm.ContactRelationsip;
                patient.ContactSurname = rvm.ContactSurname;
                patient.District = DB.Districts.Find(rvm.SelectedDistrictId);
                patient.Gender = (Patient.GenderEnum) rvm.Gender;
                patient.ParentPatient = null;
                patient.ParentPatientId = null;
                patient.ParentPatientRelationship = null; // or "" ?
                patient.PhoneNumber = patient.PhoneNumber;
                patient.PostOffice = DB.PostOffices.Find(rvm.SelectedPostOfficeId);
                patient.Surname = rvm.Surname;

                patient.User = user;

                user.Patient = patient;

                DB.Users.Add(user);
                DB.Patients.Add(patient);
                DB.SaveChanges();

                rvm = new RegisterViewModel();
                rvm.ViewMessage = "Registracija uspešna!";

                return Form(rvm);
            }
            catch (Exception e)
            {
                rvm.ViewMessage = "Prišlo je do hujše napake!";
                return Form(rvm);
            }



            //return RedirectToAction("Index");
        }
    
}
}