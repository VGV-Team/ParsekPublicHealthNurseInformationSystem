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
    public class AddPatientController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();
        
        // GET: Login
        public ActionResult Index()
        {
            return Form(null);
        }

        public ActionResult Form(AddCarePatientViewModel acpvm)
        {
            if (acpvm == null)
            {
                acpvm = new AddCarePatientViewModel();
            }

            ModelState.Remove("ViewMessage");
            ModelState.Remove("Relationships");
            ModelState.Remove("PostOffices");
            ModelState.Remove("Districts");

            acpvm.Districts = DB.Districts.ToList();
            acpvm.PostOffices = DB.PostOffices.ToList();
            acpvm.Relationships = DB.Relationships.ToList();

            if (Session["user"] != null)
            {
                acpvm.CarePatients = DB.Patients.Find((Session["user"] as Models.User).Patient.PatientId).ChildPatients.ToList();
            }

            return View("Index", acpvm);
        }

        [HttpPost]
        public ActionResult AddCarePatient(AddCarePatientViewModel acpvm)
        {

            try
            {
                ModelState.Remove("ViewMessage");
                ModelState.Remove("Relationships");
                ModelState.Remove("PostOffices");
                ModelState.Remove("Districts");

                if (ModelState.IsValid)
                {
                    int x;
                }

                if (acpvm.Address.IsNullOrWhiteSpace() ||
                    acpvm.Name.IsNullOrWhiteSpace() ||
                    acpvm.Number.IsNullOrWhiteSpace() ||
                    acpvm.PhoneNumber.IsNullOrWhiteSpace() ||
                    acpvm.Surname.IsNullOrWhiteSpace() ||
                    !acpvm.Gender.HasValue ||
                    acpvm.SelectedDistrictId.ToString().IsNullOrWhiteSpace() ||
                    acpvm.SelectedPostOfficeId.ToString().IsNullOrWhiteSpace() ||
                    acpvm.SelectedRelationshipId.ToString().IsNullOrWhiteSpace()
                )
                {
                    acpvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(acpvm);
                }


                if (acpvm.BirthDate > DateTime.UtcNow || acpvm.BirthDate < DateTime.Parse("1/1/1900"))
                {
                    acpvm.ViewMessage = "Neustrezen datum!";
                    return Form(acpvm);
                }

                Models.Patient patient = new Models.Patient();
                patient.Name = acpvm.Name;
                patient.Address = acpvm.Address;
                patient.CardNumber = acpvm.Number;
                patient.District = DB.Districts.Find(acpvm.SelectedDistrictId);
                patient.Gender = (Patient.GenderEnum)acpvm.Gender;

                int tempParentPatientId = (Session["user"] as Models.User).Patient.PatientId;
                Models.Patient parentPatient = DB.Patients.Find(tempParentPatientId);

                patient.ParentPatientId = parentPatient.PatientId;
                patient.ParentPatient = parentPatient;
                Models.Relationship ParentRelationship = DB.Relationships.Find(acpvm.SelectedRelationshipId);
                patient.ParentPatientRelationship = ParentRelationship;
                patient.PhoneNumber = acpvm.PhoneNumber;
                patient.PostOffice = DB.PostOffices.Find(acpvm.SelectedPostOfficeId);
                patient.Surname = acpvm.Surname;
                patient.BirthDate = acpvm.BirthDate;

                DB.Patients.Add(patient);
                DB.SaveChanges();

                acpvm = new AddCarePatientViewModel();
                acpvm.ViewMessage = "Dodajanje uspešno.";

                return Form(acpvm);
            }
            catch (Exception e)
            {
                acpvm.ViewMessage = "Prišlo je do hujše napake!";
                return Form(acpvm);
            }
        }
    }
}