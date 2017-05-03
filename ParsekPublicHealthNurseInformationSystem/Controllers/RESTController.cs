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

        public JsonResult GetChildPatientsByPatientFullNameWithCode(string FullNameWithCode)
        {
            int[] ID = Globals.GetIdsFromString(FullNameWithCode);
            if (ID.Length != 1)
            {
                var data = new
                {
                    count = 0,
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int parentId = ID[0];
                List<Patient> Patients = DB.Patients.Where(d => d.ParentPatientId == parentId).ToList();
                List<string> Names = new List<string>();

                for (int i = 0; i < Patients.Count; i++)
                {
                    Names.Add(Patients[i].FullNameWithCode);
                }

                var data = new
                {
                    count = Patients.Count,
                    names = Names
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}