using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using Microsoft.Ajax.Utilities;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.Patient)]
    public class ProfileController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(ProfileViewModel vm)
        {

            if (vm == null)
            {
                vm = new ProfileViewModel();
                vm.CarePatientDatas = new List<ProfileViewModel.CarePatientData>();
            }

            vm.CarePatientDatas = new List<ProfileViewModel.CarePatientData>();
            FillData(vm);

            return View("Index", vm);
        }

        private void FillData(ProfileViewModel vm)
        {
            Patient patient = (Session["user"] as Models.User).Patient;

            vm.PatientId = patient.PatientId;
            vm.Address = patient.Address;
            vm.BirthDate = patient.BirthDate;
            vm.ContactAddress = patient.ContactAddress;
            vm.ContactName = patient.ContactName;
            vm.ContactPhone = patient.ContactPhone;
            vm.ContactSurname = patient.ContactSurname;
            vm.Gender = patient.Gender;
            vm.SelectedDistrictId = patient.District.DistrictId;
            vm.Name = patient.Name;
            vm.Number = patient.CardNumber;
            vm.PhoneNumber = patient.PhoneNumber;
            vm.SelectedPostOfficeId = patient.PostOffice.PostOfficeId;
            vm.Email = (Session["user"] as Models.User).Email;
            if (patient.ContactRelationship != null)
            {
                vm.SelectedRelationshipId = patient.ContactRelationship.RelationshipId;
                vm.HasContactPerson = true;
            }
            else
            {
                vm.HasContactPerson = false;
                vm.SelectedRelationshipId = 0;
            }
            vm.Surname = patient.Surname;

            vm.Districts = DB.Districts.ToList();
            vm.Relationships = DB.Relationships.ToList();
            vm.PostOffices = DB.PostOffices.ToList();


            for (int i = 0; i < patient.ChildPatients.Count; i++)
            {
                ProfileViewModel.CarePatientData cpd = new ProfileViewModel.CarePatientData();
                cpd.PatientId = patient.ChildPatients.ElementAt(i).PatientId;
                cpd.Address = patient.ChildPatients.ElementAt(i).Address;
                cpd.BirthDate = patient.ChildPatients.ElementAt(i).BirthDate;
                cpd.Districts = DB.Districts.ToList();
                cpd.Gender = patient.ChildPatients.ElementAt(i).Gender;
                cpd.Name = patient.ChildPatients.ElementAt(i).Name;
                cpd.Number = patient.ChildPatients.ElementAt(i).CardNumber;
                cpd.PhoneNumber = patient.ChildPatients.ElementAt(i).PhoneNumber;
                cpd.PostOffices = DB.PostOffices.ToList();
                cpd.Relationships = DB.Relationships.ToList();
                //var Rel = patient.ChildPatients.ElementAt(i).ParentPatientRelationship;
                cpd.SelectedRelationshipId = patient.ChildPatients.ElementAt(i).ParentPatientRelationship.RelationshipId;
                cpd.Surname = patient.ChildPatients.ElementAt(i).Surname;
                cpd.SelectedDistrictId = patient.ChildPatients.ElementAt(i).District.DistrictId;
                cpd.SelectedPostOfficeId = patient.ChildPatients.ElementAt(i).PostOffice.PostOfficeId;
                cpd.ViewMessage = "";
                vm.CarePatientDatas.Add(cpd);
            }

            ModelState.Clear();

        }


        public ActionResult Edit(ProfileViewModel vm)
        {

            if (vm.Email.IsNullOrWhiteSpace() ||
                    vm.Address.IsNullOrWhiteSpace() ||
                    vm.Name.IsNullOrWhiteSpace() ||
                    vm.Number.IsNullOrWhiteSpace() ||
                    vm.PhoneNumber.IsNullOrWhiteSpace() ||
                    vm.Surname.IsNullOrWhiteSpace() ||
                    !vm.Gender.HasValue ||
                    vm.SelectedDistrictId.ToString().IsNullOrWhiteSpace() ||
                    vm.SelectedPostOfficeId.ToString().IsNullOrWhiteSpace()
                )
            {
                vm.ViewMessage = "Ponovno preverite vnešene podatke!";
                return Index(vm);
            }

            if (vm.BirthDate >= DateTime.UtcNow.Date)
            {
                vm.ViewMessage = "Neustrezen datum rojstva!";
                return Index(vm);
            }

            try
            {

                Patient p = DB.Patients.Find(vm.PatientId);
                p.Name = vm.Name;
                p.Address = vm.Address;
                p.BirthDate = vm.BirthDate;
                if (vm.HasContactPerson)
                {
                    p.ContactAddress = vm.ContactAddress;
                    p.ContactName = vm.ContactName;
                    p.ContactPhone = vm.ContactPhone;
                    p.ContactRelationship = DB.Relationships.Find(vm.SelectedRelationshipId);
                    p.ContactSurname = vm.ContactSurname;
                }
                else
                {
                    p.ContactAddress = null;
                    p.ContactName = null;
                    p.ContactPhone = null;
                    var forceLoad = p.ContactRelationship;
                    p.ContactRelationship = null; 
                    p.ContactSurname = null;
                }
                p.District = DB.Districts.Find(vm.SelectedDistrictId);
                p.Gender = (Patient.GenderEnum)vm.Gender;
                p.Name = vm.Name;
                p.PhoneNumber = vm.PhoneNumber;
                p.PostOffice = DB.PostOffices.Find(vm.SelectedPostOfficeId);
                p.Surname = vm.Surname;
                

                if (vm.CarePatientDatas != null)
                for (int i = 0; i < vm.CarePatientDatas.Count; i++)
                {

                    if (vm.CarePatientDatas[i].Address.IsNullOrWhiteSpace() ||
                        vm.CarePatientDatas[i].Name.IsNullOrWhiteSpace() ||
                        vm.CarePatientDatas[i].Number.IsNullOrWhiteSpace() ||
                        vm.CarePatientDatas[i].PhoneNumber.IsNullOrWhiteSpace() ||
                        vm.CarePatientDatas[i].Surname.IsNullOrWhiteSpace() ||
                        !vm.CarePatientDatas[i].Gender.HasValue ||
                        vm.CarePatientDatas[i].SelectedDistrictId.ToString().IsNullOrWhiteSpace() ||
                        vm.CarePatientDatas[i].SelectedPostOfficeId.ToString().IsNullOrWhiteSpace()
                    )
                    {
                        vm.ViewMessage = "Ponovno preverite vnešene podatke!";
                        return Index(vm);
                    }

                    if (vm.CarePatientDatas[i].BirthDate >= DateTime.UtcNow.Date)
                    {
                        vm.ViewMessage = "Neustrezen datum rojstva!";
                        return Index(vm);
                    }



                    p.ChildPatients.ElementAt(i).Address = vm.CarePatientDatas[i].Address;
                    p.ChildPatients.ElementAt(i).BirthDate = vm.CarePatientDatas[i].BirthDate;
                    p.ChildPatients.ElementAt(i).CardNumber = vm.CarePatientDatas[i].Number;
                    p.ChildPatients.ElementAt(i).District = DB.Districts.Find(vm.CarePatientDatas[i].SelectedDistrictId);
                    p.ChildPatients.ElementAt(i).Gender = (Patient.GenderEnum)vm.CarePatientDatas[i].Gender;
                    p.ChildPatients.ElementAt(i).Name = vm.CarePatientDatas[i].Name;
                    p.ChildPatients.ElementAt(i).ParentPatientRelationship = DB.Relationships.Find(vm.CarePatientDatas[i].SelectedRelationshipId);
                    p.ChildPatients.ElementAt(i).PhoneNumber = vm.CarePatientDatas[i].PhoneNumber;
                    p.ChildPatients.ElementAt(i).PostOffice = DB.PostOffices.Find(vm.CarePatientDatas[i].SelectedPostOfficeId);
                    p.ChildPatients.ElementAt(i).Surname = vm.CarePatientDatas[i].Surname;
                }

                DB.SaveChanges();

                vm.ViewMessage = "Spremeba uspešna.";

                int userId = (Session["user"] as Models.User).UserId;
                Session["user"] = DB.Users.Find(userId);

            }
            catch (Exception e)
            {
                vm.ViewMessage = "Prišlo je do napake.";
            }


            
            return Index(vm);
        }

        

    }
}