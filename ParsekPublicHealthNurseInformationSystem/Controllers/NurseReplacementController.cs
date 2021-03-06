﻿using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels.NurseReplacement;
using ParsekPublicHealthNurseInformationSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class NurseReplacementController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();
        // GET: NurseReplacement
        public ActionResult Index()
        {
            NurseReplacementViewModel nrvm = new NurseReplacementViewModel();
            nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse && x.User.Active == true).ToList();
            return View("Index", nrvm);
        }



        public string NurseReplacement(int id1)
        {
            try
            {
                Employee Nurse1 = DB.Employees.Find(id1);
                int tmpId = id1;
                List<WorkOrder> WO = DB.WorkOrders.Where(x => x.Nurse.EmployeeId == Nurse1.EmployeeId).ToList();
                //List<Visit> visits = new List<Visit>();
                foreach (var workorder in WO)
                {
                    foreach (var visit in workorder.Visits)
                    {
                        if (visit.Done == false)
                        {
                            Employee Nurse2 = DB.Employees.FirstOrDefault(x => x.EmployeeId != id1 && x.JobTitle.Title == JobTitle.HealthNurse && x.Absences.All(abs => abs.DateStart > visit.DateConfirmed || abs.DateEnd < visit.DateConfirmed));
                            if (Nurse2 == null) return "Neuspešno! Na dan " + visit.DateConfirmed.ToString("dd. MM. yyyy") + "ni ustrezne zamenjave!";
                            visit.NurseReplacement = Nurse2;
                        }
                        
                    }
                }
                List<Visit> visits = DB.Visits.Where(x => x.Done == false && x.NurseReplacement != null && x.NurseReplacement.EmployeeId == tmpId).ToList();
                foreach (var visit in visits)
                {
                    Employee Nurse2 = DB.Employees.FirstOrDefault(x => x.EmployeeId != id1 && x.JobTitle.Title == JobTitle.HealthNurse && x.Absences.All(abs => abs.DateStart > visit.DateConfirmed || abs.DateEnd < visit.DateConfirmed));
                    if (Nurse2 == null) return "Neuspešno! Na dan " + visit.DateConfirmed.ToString("dd. MM. yyyy") + "ni ustrezne zamenjave!";
                    if (Nurse2.EmployeeId == visit.WorkOrder.Nurse.EmployeeId)
                    {
                        var forceLoad = visit.NurseReplacement; //Aleluja
                        visit.NurseReplacement = null; // Now EF knows something has changed
                    }
                    else
                    {
                        visit.NurseReplacement = Nurse2;
                    }
                }


                DB.SaveChanges();

                return "";
            }
            catch (Exception e)
            {
                return "Hujša napaka";
            }
        }


        [HttpPost]
        public ActionResult NurseReplacement(NurseReplacementViewModel nrvm)
        {
            try
            {

                if (nrvm.NurseId.IsNullOrWhiteSpace() ||
                nrvm.ReplacementNurseId.IsNullOrWhiteSpace() ||
                nrvm.DateStart == null ||
                nrvm.DateEnd == null
                )
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return View("Index", nrvm);
                }

                int[] NurseId1 = Globals.GetIdsFromString(nrvm.NurseId);
                int[] NurseId2 = Globals.GetIdsFromString(nrvm.ReplacementNurseId);

                if (NurseId1 == null || NurseId2 == null || NurseId1.Length != 1 || NurseId2.Length != 1 || NurseId1[0] == NurseId2[0])
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Preverite sestri";
                    return View("Index", nrvm);
                }

                if (nrvm.DateStart < DateTime.Now.Date || nrvm.DateEnd < DateTime.Now.Date)
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Vsaj eden izmed datumov je preteklost";
                    return View("Index", nrvm);
                }

                if(nrvm.DateEnd < nrvm.DateStart)
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Datum konca je pred datumom začetka";
                    return View("Index", nrvm);
                }

                Employee Nurse1 = DB.Employees.Find(NurseId1[0]);
                Employee Nurse2 = DB.Employees.Find(NurseId2[0]);
                int tmpId = NurseId1[0];
                List<WorkOrder> WO = DB.WorkOrders.Where(x => x.Nurse.EmployeeId == Nurse1.EmployeeId).ToList();
                //List<Visit> visits = new List<Visit>();
                foreach (var workorder in WO)
                {
                    foreach (var visit in workorder.Visits)
                    {
                        if (visit.Done == false && visit.DateConfirmed <= nrvm.DateEnd && visit.DateConfirmed >= nrvm.DateStart)
                            //visits.Add(visit);
                            visit.NurseReplacement = Nurse2;
                    }
                }
                List<Visit> visits = DB.Visits.Where(x => x.DateConfirmed >= nrvm.DateStart && x.DateConfirmed <= nrvm.DateEnd && x.NurseReplacement != null && x.NurseReplacement.EmployeeId == tmpId).ToList();
                foreach(var visit in visits)
                {
                    visit.NurseReplacement = Nurse2;
                }
                Absence a = new Absence();
                a.AbsenceNurse = Nurse1;
                a.DateStart = nrvm.DateStart;
                a.DateEnd = nrvm.DateEnd;
                DB.Absences.Add(a);


                DB.SaveChanges();
                nrvm.ViewMessage = "Nadomestitev uspešna";
                nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse && x.User.Active == true).ToList();
                return View("Index", nrvm);
            }
            catch (Exception e)
            {
                nrvm.ViewMessage = "Prišlo je do hujše napake!";
                nrvm.AllNurses = DB.Employees.Where(x => x.JobTitle.Title == JobTitle.HealthNurse && x.User.Active == true).ToList();
                return View("Index", nrvm);
            }
        }
        }
}