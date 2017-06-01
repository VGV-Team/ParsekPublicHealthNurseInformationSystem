using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels.ServiceCost;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class ServiceCostController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();
        // GET: ServiceCost
        public ActionResult Index()
        {
            ServiceCostViewModel scvm = new ServiceCostViewModel();
            scvm.Print = false;
            return View("Index", scvm);
        }

        public ActionResult ServiceCost(ServiceCostViewModel scvm)
        {
            try
            {
                if (scvm.DateStart == null ||
                scvm.DateEnd == null
                )
                {
                    scvm.ViewMessage = "Ponovno preverite vnešene podatke!";
                    return View("Index", scvm);
                }

                if (scvm.DateStart < DateTime.Now.Date || scvm.DateEnd < DateTime.Now.Date)
                {
                    scvm.ViewMessage = "Vsaj eden izmed datumov je preteklost";
                    return View("Index", scvm);
                }

                if (scvm.DateEnd < scvm.DateStart)
                {
                    scvm.ViewMessage = "Datum konca je pred datumom začetka";
                    return View("Index", scvm);
                }

                List<Service> s = DB.Services.ToList();
                scvm.ServiceType = new string[s.Count+1];
                
                for (int i = 0; i < s.Count; i++)
                    scvm.ServiceType[i] = s.ElementAt(i).ServiceTitle;

                scvm.ServiceType[scvm.ServiceType.Length - 1] = "Skupno";
                List<Visit> visits = DB.Visits.Where(x => x.DateConfirmed >= scvm.DateStart && x.DateConfirmed <= scvm.DateEnd).ToList();
                scvm.Count = new int[s.Count+1];
                scvm.ServiceTotal = new double[s.Count+1];
                scvm.MedicineTotal = new double[s.Count+1];
                scvm.Total = new double[s.Count+1];

                foreach (var v in visits)
                {
                    scvm.Count[v.WorkOrder.Service.ServiceId-1]++;
                    scvm.ServiceTotal[v.WorkOrder.Service.ServiceId - 1] += v.WorkOrder.Service.Cost;
                    List<MedicineWorkOrder> a = v.WorkOrder.MedicineWorkOrders.ToList();
                    foreach(var m in a)
                        scvm.MedicineTotal[v.WorkOrder.Service.ServiceId - 1] += m.Medicine.Cost;
                }
                for (int i = 0; i < s.Count; i++)
                {
                    scvm.Count[scvm.ServiceType.Length - 1] += scvm.Count[i];
                    scvm.ServiceTotal[scvm.ServiceType.Length - 1] += scvm.ServiceTotal[i];
                    scvm.MedicineTotal[scvm.ServiceType.Length - 1] += scvm.MedicineTotal[i];
                }

                for (int i = 0; i < s.Count+1; i++)
                    scvm.Total[i] = scvm.ServiceTotal[i] + scvm.MedicineTotal[i];

                scvm.Print = true;
                return View("Index", scvm);

            }
            catch (Exception e)
            {
                scvm.ViewMessage = "Prišlo je do hujše napake!";
                return View("Index", scvm);
            }
        }
    }
}