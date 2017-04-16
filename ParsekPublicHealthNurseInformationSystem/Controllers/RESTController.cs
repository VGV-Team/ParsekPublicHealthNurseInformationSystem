using ParsekPublicHealthNurseInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    public class RESTController : Controller
    {

        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDistrictsByContractorId(int ID)
        {

            List<District> Districts = DB.Districts.Where(d => d.Contractor.ContractorId == ID).ToList();

            List<int> IDs = new List<int>();
            List<string> Names = new List<string>();

            for (int i = 0; i < Districts.Count; i++)
            {
                IDs.Add(Districts[i].DistrictId);
                Names.Add(Districts[i].Name);
            }

            var data = new
            {
                count = Districts.Count,
                ids = IDs,
                names = Names
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}