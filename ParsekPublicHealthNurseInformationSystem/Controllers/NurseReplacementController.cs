using Microsoft.Ajax.Utilities;
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
            nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
            return View("Index", nrvm);
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
                    nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return View("Index", nrvm);
                }

                int[] NurseId1 = WorkOrderController.GetIdsFromString(nrvm.NurseId);
                int[] NurseId2 = WorkOrderController.GetIdsFromString(nrvm.ReplacementNurseId);

                if (NurseId1 == null || NurseId2 == null || NurseId1.Length != 1 || NurseId2.Length != 1 || NurseId1[0] == NurseId2[0])
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Preverite sestri";
                    return View("Index", nrvm);
                }

                if (nrvm.DateStart < DateTime.Now || nrvm.DateEnd < DateTime.Now)
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Vsaj eden izmed datumov je preteklost";
                    return View("Index", nrvm);
                }

                if(nrvm.DateEnd < nrvm.DateStart)
                {
                    nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                    nrvm.ViewMessage = "Datum konca je pred datumom začetka";
                    return View("Index", nrvm);
                }

                nrvm.ViewMessage = "qwe";
                nrvm.AllNurses = DB.Employees.Where(x => x.Title == Employee.JobTitle.HealthNurse).ToList();
                return View("Index", nrvm);
            }
            catch (Exception e)
            {
                nrvm.ViewMessage = "Prišlo je do hujše napake!";
                return View("Index", nrvm);
            }
        }
        }
}