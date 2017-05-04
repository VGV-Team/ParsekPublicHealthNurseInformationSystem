using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Controllers
{
    [AuthorizationFilter(Role.RoleEnum.Employee)]
    public class VisitDetailsController : Controller
    {
        private EntityDataModel DB = new EntityDataModel();

        public ActionResult Index(int? visitId)
        {
            VisitDetailsViewModel vm = new VisitDetailsViewModel();

            vm.PatientData = new VisitDetailsViewModel.ParsedData();
            vm.ChildPatientData = new List<VisitDetailsViewModel.ParsedData>();

            vm.PatientData.Categories = new List<string>();
            vm.PatientData.CategoryItemCount = new List<int>();
            vm.PatientData.ParsedDetails = new List<string>();
            vm.PatientData.ParsedDetailsTitles = new List<string>();

            vm.GeneralData = new VisitDetailsViewModel.ParsedData();

            if (visitId == null)
            {
                //vm.Visit = null;
                //vm.ActivityInputs = null;
            }
            else
            {
                vm.Visit = DB.Visits.Find(visitId);

                vm.PatientData = FillData(vm.Visit, vm.Visit.WorkOrder.Patient.PatientId);
                vm.PatientData.PatientName = vm.Visit.WorkOrder.Patient.FullNameWithCode;

                for (int i = 0; i < vm.Visit.WorkOrder.PatientWorkOrders.Count; i++)
                {
                    VisitDetailsViewModel.ParsedData data = FillData(vm.Visit, vm.Visit.WorkOrder.PatientWorkOrders.ElementAt(i).Patient.PatientId);
                    data.PatientName = vm.Visit.WorkOrder.PatientWorkOrders.ElementAt(i).Patient.FullNameWithCode;
                    vm.ChildPatientData.Add(data);
                }

                vm.GeneralData = FillGeneralData(vm.Visit);

            }

            
           
            return View(vm);
        }

        private VisitDetailsViewModel.ParsedData FillData(Visit visit, int patientId)
        {
            VisitDetailsViewModel.ParsedData data = new VisitDetailsViewModel.ParsedData();

            List<ActivityInputData> inputData = visit.ActivityInputDatas.Where(aid => aid.Patient != null && aid.Patient.PatientId == patientId).ToList();

            int oldId = -1;
            int count = 0;
            bool first = true;

            for (int i = 0; i < inputData.Count; i++)
            {
                if (oldId != inputData.ElementAt(i).ActivityInput.Activity.ActivityId)
                {
                    oldId = inputData.ElementAt(i).ActivityInput.Activity.ActivityId;
                    if (!first) data.CategoryItemCount.Add(count);
                    first = false;
                    count = 0;
                    data.Categories.Add(inputData.ElementAt(i).ActivityInput.Activity.ActivityTitle);
                }

                data.ParsedDetailsTitles.Add(inputData.ElementAt(i).ActivityInput.Title);
                if (inputData.ElementAt(i).ActivityInput.InputType == ActivityInput.InputTypeEnum.Date)
                {
                    DateTime dt = DateTime.Parse(inputData.ElementAt(i).Value);
                    data.ParsedDetails.Add(dt.ToString("dd.MM.yyyy"));
                }
                else
                {
                    data.ParsedDetails.Add(inputData.ElementAt(i).Value);
                }
                count += 1;
            }
            data.CategoryItemCount.Add(count);


            return data;

        }


        private VisitDetailsViewModel.ParsedData FillGeneralData(Visit visit)
        {
            VisitDetailsViewModel.ParsedData data = new VisitDetailsViewModel.ParsedData();

            List<ActivityInputData> inputData = visit.ActivityInputDatas.Where(aid => aid.Patient == null).ToList();

            int oldId = -1;
            int count = 0;
            bool first = true;

            for (int i = 0; i < inputData.Count; i++)
            {
                if (oldId != inputData.ElementAt(i).ActivityInput.Activity.ActivityId)
                {
                    oldId = inputData.ElementAt(i).ActivityInput.Activity.ActivityId;
                    if (!first) data.CategoryItemCount.Add(count);
                    first = false;
                    count = 0;
                    data.Categories.Add(inputData.ElementAt(i).ActivityInput.Activity.ActivityTitle);
                }

                data.ParsedDetailsTitles.Add(inputData.ElementAt(i).ActivityInput.Title);
                if (inputData.ElementAt(i).ActivityInput.InputType == ActivityInput.InputTypeEnum.Date)
                {
                    DateTime dt = DateTime.Parse(inputData.ElementAt(i).Value);
                    data.ParsedDetails.Add(dt.ToString("dd.MM.yyyy"));
                }
                else
                {
                    data.ParsedDetails.Add(inputData.ElementAt(i).Value);
                }
                count += 1;
            }
            data.CategoryItemCount.Add(count);


            return data;

        }

    }
}