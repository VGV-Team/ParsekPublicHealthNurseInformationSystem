using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using ParsekPublicHealthNurseInformationSystem.Models;
using Microsoft.Ajax.Utilities;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.Admin)]
    public class AdminConsoleController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        // GET: AdminConsole
        public ActionResult Index()
        {
            /*AdminConsoleViewModel acvm = new AdminConsoleViewModel();

            acvm.Contractors = DB.Contractors.ToList();
            acvm.Districts = DB.Districts.ToList();
            acvm.JobTitle = Employee.JobTitle.Doctor;*/

            return Form(null);
        }

        

        public ActionResult Form(AdminConsoleViewModel acvm)
        {

            if (acvm == null)
            {
                acvm = new AdminConsoleViewModel();
            }

            
            acvm.Contractors = DB.Contractors.ToList();
            acvm.Districts = DB.Districts.ToList();
            acvm.JobTitleList = DB.JobTitles.ToList();

            ModelState.Clear();

            return View("Index", acvm);
        }

        [HttpPost]
        public ActionResult AddEmployee(AdminConsoleViewModel acvm)
        {
         
            try
            {

                if (acvm.Email.IsNullOrWhiteSpace() ||
                    acvm.SelectedJobTitleId <= 0 ||
                    acvm.Name.IsNullOrWhiteSpace() ||
                    acvm.Number.IsNullOrWhiteSpace() ||
                    acvm.Password.IsNullOrWhiteSpace() ||
                    acvm.PasswordRepeat.IsNullOrWhiteSpace() ||
                    acvm.PhoneNumber.IsNullOrWhiteSpace() ||
                    acvm.SelectedContractorId <= 0 ||
                    acvm.Surname.IsNullOrWhiteSpace())
                {
                    acvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return Form(acvm);
                }

                /*if (!ModelState.IsValid)
                {
                    acvm.ViewMessage = "Prišlo je do napake! Preglejte polja!";
                    return Form(acvm);
                }*/

                if (DB.Users.Where(u => u.Email == acvm.Email).FirstOrDefault() != null)
                {
                    acvm.ViewMessage = "Uporabnik s tem e-mail naslovom že obstaja!";
                    return Form(acvm);
                }

                if (acvm.Password != acvm.PasswordRepeat)
                {
                    //acvm.ViewMessage = "Gesli se ne ujemata!";
                    return Form(acvm);
                }

                if (!acvm.Password.Any(c => char.IsDigit(c)))
                {
                    //acvm.ViewMessage = "Geslo mora vsebovati vsaj eno številko!";
                    return Form(acvm);
                }
                    

                Models.Role role = DB.Roles.Where(r => r.Title == Role.Employee).FirstOrDefault();

                Models.User user = new Models.User();
                user.Email = acvm.Email;
                user.Role = role;
                user.Password = acvm.Password;
                user.Patient = null;
                user.Active = true;
                user.LastLastLogin = DateTime.Now;
                user.LastLogin = DateTime.Now;

                Models.Employee employee = new Models.Employee();
                employee.Contractor = DB.Contractors.Find(acvm.SelectedContractorId);
                if (DB.JobTitles.Find(acvm.SelectedJobTitleId).Title == JobTitle.HealthNurse)
                {
                    if (acvm.SelectedDistrictId <= 0)
                    {
                        acvm.ViewMessage = "Za patronažno sestro morate vnesti še okoliš!";
                        return Form(acvm);
                    }
                    employee.District = DB.Districts.Find(acvm.SelectedDistrictId);
                }
                employee.Name = acvm.Name;
                employee.Number = acvm.Number;
                employee.PhoneNumber = acvm.PhoneNumber;
                employee.Surname = acvm.Surname;
                employee.JobTitle = DB.JobTitles.Find(acvm.SelectedJobTitleId);
                employee.User = user;

                user.Employee = employee;

                DB.Users.Add(user);
                DB.Employees.Add(employee);
                DB.SaveChanges();

                acvm = new AdminConsoleViewModel();
                acvm.ViewMessage = "Uspešno dodano!";

                return Form(acvm);
            }
            catch (Exception e)
            {
                acvm.ViewMessage = "Prišlo je do hujše napake!";
                return Form(acvm);
            }


            

            //return RedirectToAction("Index");
        }

        public ActionResult ChangeProfile()
        {
            AdminConsoleViewModel acvm = new AdminConsoleViewModel();
            acvm.AllEmployees = DB.Employees.ToList();
            acvm.Contractors = DB.Contractors.ToList();
            acvm.Districts = DB.Districts.ToList();
            acvm.JobTitleList = DB.JobTitles.ToList();
            return View("ChangeProfile", acvm);
        }


        public ActionResult SelectEmployee(AdminConsoleViewModel acvm)
        {
            try
            {
                if (acvm.EmployeeId.IsNullOrWhiteSpace())
                {
                    acvm.AllEmployees = DB.Employees.ToList();
                    acvm.Contractors = DB.Contractors.ToList();
                    acvm.Districts = DB.Districts.ToList();
                    acvm.JobTitleList = DB.JobTitles.ToList();
                    acvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return View("ChangeProfile", acvm);
                }

                int[] EmployeeId = Globals.GetIdsFromString(acvm.EmployeeId);

                if (EmployeeId == null || EmployeeId.Length != 1)
                {
                    acvm.AllEmployees = DB.Employees.ToList();
                    acvm.Contractors = DB.Contractors.ToList();
                    acvm.Districts = DB.Districts.ToList();
                    acvm.JobTitleList = DB.JobTitles.ToList();
                    acvm.ViewMessage = "Ponovno preverite vnešenega zaposlenega";
                    return View("ChangeProfile", acvm);
                }

                Employee employee = DB.Employees.Find(EmployeeId[0]);
                acvm.SelectedJobTitleId = employee.JobTitle.JobTitleId;
                acvm.Name = employee.Name;
                acvm.Surname = employee.Surname;
                acvm.Number = employee.Number;
                acvm.Contractor = employee.Contractor.DisplayName;
                if (employee.JobTitle.Title == JobTitle.HealthNurse)
                {
                    acvm.District = "Okoliš " + employee.District.DistrictId;
                }
                acvm.PhoneNumber = employee.PhoneNumber;
                acvm.Email = employee.User.Email;
                ModelState.Clear();
                acvm.AllEmployees = DB.Employees.ToList();
                acvm.Contractors = DB.Contractors.ToList();
                acvm.Districts = DB.Districts.ToList();
                acvm.JobTitleList = DB.JobTitles.ToList();

                acvm.Id = EmployeeId[0];
                acvm.EmployeeId = employee.FullNameWithCode;
                return View("ChangeProfile", acvm);
            }
            catch (Exception e)
            {
                acvm.ViewMessage = "Prišlo je do hujše napake!";
                return View("ChangeProfile", acvm);
            }
        }

        public ActionResult Edit(AdminConsoleViewModel acvm)
        {
            try
            {
                if(acvm.Name.IsNullOrWhiteSpace()||
                    acvm.Surname.IsNullOrWhiteSpace() ||
                    acvm.Number.IsNullOrWhiteSpace() ||
                    acvm.PhoneNumber.IsNullOrWhiteSpace())
                {
                    acvm.AllEmployees = DB.Employees.ToList();
                    acvm.Contractors = DB.Contractors.ToList();
                    acvm.Districts = DB.Districts.ToList();
                    acvm.JobTitleList = DB.JobTitles.ToList();
                    acvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return View("ChangeProfile", acvm);
                }
                Employee employee = DB.Employees.Find(acvm.Id);
                employee.Name = acvm.Name;
                employee.Surname = acvm.Surname;
                employee.Number = acvm.Number;
                employee.PhoneNumber = acvm.PhoneNumber;
                employee.Contractor = employee.Contractor;
                employee.JobTitle = employee.JobTitle;
                DB.SaveChanges();
                acvm.AllEmployees = DB.Employees.ToList();
                acvm.Contractors = DB.Contractors.ToList();
                acvm.Districts = DB.Districts.ToList();
                acvm.JobTitleList = DB.JobTitles.ToList();
                acvm.EmployeeId = employee.FullNameWithCode;
                ModelState.Clear();
                acvm.ViewMessage = "Sprememba profila uspešna";
                return View("ChangeProfile", acvm);
            }
            catch (Exception e)
            {
                acvm.ViewMessage = "Prišlo je do hujše napake!";
                return View("ChangeProfile", acvm);
            }

        }

    }
    
}