using Microsoft.Ajax.Utilities;
using ParsekPublicHealthNurseInformationSystem.Controllers;
using ParsekPublicHealthNurseInformationSystem.Models;
using ParsekPublicHealthNurseInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsekPublicHealthNurseInformationSystem.Migrations
{
    public class WorkorderTestData
    {

        public void Fill(ParsekPublicHealthNurseInformationSystem.Models.EntityDataModel DB)
        {

            DB.SaveChanges();

            // FOR DEBUGGING

            /*if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();*/


            WorkOrderViewModel VM = new WorkOrderViewModel();

            bool res;


            /*
             * 1 nosčnica
             * 2 otročnica + otrok
             * 3 starostnik
             * 4 injekcije
             * 5 kri
             * 6 kontrola
             */

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "70").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 5;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "40").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 10;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "50").ServiceId;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 5;
            VM.TimeInterval = 7;
            VM.EnterMedicine = true;
            VM.MedicineIds = "(897), (456), (1025)";
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(13, 14)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "60").ServiceId;
            VM.MandatoryFirstVisit = true;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 2;
            VM.TimeInterval = 1;
            VM.EnterBloodSample = true;
            VM.BloodVialRedCount = 2;
            VM.BloodVialYellowCount = 3;
            VM.BloodVialGreenCount = 4;
            VM.BloodVialBlueCount = 0;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(13, 14)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "70").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 2;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-15");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(13, 14)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Anton").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "40").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-05-10");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Jana").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "20").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 2;
            VM.EnterPatients = true;
            VM.PatientIds = DB.Patients.FirstOrDefault(x => x.Name == "Janin").FullNameWithCode;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-12");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Jana").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "20").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.EnterPatients = true;
            VM.PatientIds = DB.Patients.FirstOrDefault(x => x.Name == "Janin").FullNameWithCode;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Jana").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "70").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-12");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Jana").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "60").ServiceId;
            VM.MandatoryFirstVisit = true;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.EnterBloodSample = true;
            VM.BloodVialRedCount = 2;
            VM.BloodVialYellowCount = 3;
            VM.BloodVialGreenCount = 4;
            VM.BloodVialBlueCount = 0;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-05-16");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Blaž").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "70").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 2;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-29");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(13, 14)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Blaž").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "70").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Blaž").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "40").ServiceId;
            VM.MandatoryFirstVisit = true;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 5;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Blaž").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "50").ServiceId;
            VM.MandatoryFirstVisit = true;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 5;
            VM.TimeInterval = 7;
            VM.EnterBloodSample = true;
            VM.BloodVialRedCount = 2;
            VM.BloodVialYellowCount = 1;
            VM.BloodVialGreenCount = 1;
            VM.BloodVialBlueCount = 4;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-08");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(13, 14)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Blaž").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "60").ServiceId;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 5;
            VM.TimeInterval = 7;
            VM.EnterMedicine = true;
            VM.MedicineIds = "(123), (321)";
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Zdravko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-01");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(6, 7)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Joža").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "10").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = false;
            VM.NumberOfVisits = 1;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);

            VM = new WorkOrderViewModel();
            VM.DateTimeOfFirstVisit = DateTime.Parse("2017-06-14");
            VM.DateCreated = VM.DateTimeOfFirstVisit.AddDays(-1 * (new Random().Next(7, 8)));
            VM.PatientId = DB.Patients.FirstOrDefault(x => x.Name == "Joža").PatientId.ToString();
            VM.SelectedServiceId = DB.Services.FirstOrDefault(x => x.ServiceCode == "10").ServiceId;
            VM.MandatoryFirstVisit = false;
            VM.MultipleVisits = true;
            VM.NumberOfVisits = 3;
            VM.TimeInterval = 7;
            VM.TimeType = WorkOrderViewModel.VisitTimeType.TimeInterval;
            res = SubmitWorkOrder(VM, DB.Employees.FirstOrDefault(x => x.Name == "Marko").EmployeeId, DB);




        }

        public bool SubmitWorkOrder(WorkOrderViewModel wovm, int employeeId, ParsekPublicHealthNurseInformationSystem.Models.EntityDataModel DB)
        {

            int[] temp = Globals.GetIdsFromString(wovm.PatientId);
            Patient selectedPatient = temp.Length == 1 ? DB.Patients.FirstOrDefault(x => x.PatientId == temp.FirstOrDefault()) : null;
            if (selectedPatient == null ||
                wovm.EnterPatients && wovm.PatientIds.IsNullOrWhiteSpace() ||
                wovm.MultipleVisits && (
                    wovm.TimeType == 0 ||
                    wovm.NumberOfVisits < 1 || wovm.NumberOfVisits > 10 ||
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame &&
                        (wovm.TimeFrame > DateTime.Now.AddMonths(6) ||
                         wovm.TimeFrame < DateTime.Now ||
                         wovm.TimeFrame < wovm.DateTimeOfFirstVisit ||
                         (wovm.TimeFrame - wovm.DateTimeOfFirstVisit).Days < (wovm.NumberOfVisits - 1)
                         ) ||
                    wovm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval &&
                    (wovm.TimeInterval > 30 || wovm.TimeInterval < 1)) ||
                wovm.EnterMedicine && wovm.MedicineIds.IsNullOrWhiteSpace() ||
                wovm.EnterBloodSample &&
                    (wovm.BloodVialBlueCount < 0 || wovm.BloodVialBlueCount > 30 ||
                    wovm.BloodVialGreenCount < 0 || wovm.BloodVialGreenCount > 30 ||
                    wovm.BloodVialRedCount < 0 || wovm.BloodVialRedCount > 30 ||
                    wovm.BloodVialYellowCount < 0 || wovm.BloodVialYellowCount > 30)
            )
            {
                return false;
            }
            else
            {
                
                WorkOrderDataViewModel wodvm = new WorkOrderDataViewModel();
                wodvm.SupervisorId = employeeId;
                wodvm.PatientId = selectedPatient.PatientId;
                wodvm.SelectedServiceId = wovm.SelectedServiceId;
                wodvm.DateTimeOfFirstVisit = wovm.DateTimeOfFirstVisit;
                wodvm.MandatoryFirstVisit = wovm.MandatoryFirstVisit;
                wodvm.NumberOfVisits = wovm.NumberOfVisits;
                wodvm.MultipleVisits = wovm.MultipleVisits;
                wodvm.TimeFrame = wovm.TimeFrame;
                wodvm.TimeInterval = wovm.TimeInterval;
                wodvm.TimeType = wovm.TimeType;
                wodvm.EnterMedicine = wovm.EnterMedicine;
                wodvm.EnterBloodSample = wovm.EnterBloodSample;
                wodvm.BloodVialBlueCount = wovm.EnterBloodSample ? wovm.BloodVialBlueCount : 0;
                wodvm.BloodVialGreenCount = wovm.EnterBloodSample ? wovm.BloodVialGreenCount : 0;
                wodvm.BloodVialRedCount = wovm.EnterBloodSample ? wovm.BloodVialRedCount : 0;
                wodvm.BloodVialYellowCount = wovm.EnterBloodSample ? wovm.BloodVialYellowCount : 0;
                wodvm.EnterPatients = wovm.EnterPatients;
                wodvm.DateCreated = wovm.DateCreated != DateTime.MinValue ? wovm.DateCreated : DateTime.Now;

                WorkOrderSummaryViewModel wosvm = new WorkOrderSummaryViewModel();
                wosvm.Patient = selectedPatient.FullName;
                wosvm.Supervisor = DB.Employees.Find(employeeId).FullName;
                wosvm.ServiceTitle = DB.Services.FirstOrDefault(x => x.ServiceId == wovm.SelectedServiceId).ServiceTitle;
                wosvm.DateTimeOfFirstVisit = wovm.DateTimeOfFirstVisit;
                wosvm.MandatoryFirstVisit = wovm.MandatoryFirstVisit;
                wosvm.NumberOfVisits = wovm.NumberOfVisits;
                wosvm.MultipleVisits = wovm.MultipleVisits;
                wosvm.TimeFrame = wovm.TimeFrame;
                wosvm.TimeInterval = wovm.TimeInterval;
                wosvm.TimeType = wovm.TimeType;
                wosvm.EnterBloodSample = wovm.EnterBloodSample;
                wosvm.EnterMedicine = wovm.EnterMedicine;
                wosvm.EnterPatients = wovm.EnterPatients;
                wosvm.DateCreated = wodvm.DateCreated;

                if (wovm.EnterMedicine)
                {
                    wodvm.MedicineIds = new List<int>();
                    wosvm.Medicine = new List<string>();

                    int[] medicineIds = Globals.GetIdsFromString(wovm.MedicineIds);
                    foreach (var medicine in DB.Medicines.Where(x => medicineIds.Contains(x.MedicineId)).ToList())
                    {
                        if (medicine != null)
                        {
                            wodvm.MedicineIds.Add(medicine.MedicineId);
                            wosvm.Medicine.Add(medicine.FullName);
                        }
                    }
                }

                if (wovm.EnterBloodSample)
                {
                    wosvm.BloodVialBlueCount = wovm.BloodVialBlueCount;
                    wosvm.BloodVialGreenCount = wovm.BloodVialGreenCount;
                    wosvm.BloodVialRedCount = wovm.BloodVialRedCount;
                    wosvm.BloodVialYellowCount = wovm.BloodVialYellowCount;
                }

                if (wovm.EnterPatients)
                {
                    wodvm.PatientIds = new List<int>();
                    wosvm.Patients = new List<string>();

                    int[] ids = Globals.GetIdsFromString(wovm.PatientIds);
                    foreach (var id in ids)
                    {
                        Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                        if (patient != null)
                        {
                            wodvm.PatientIds.Add(patient.PatientId);
                            wosvm.Patients.Add(patient.FullName);
                        }
                    }
                }

                Employee selectedNurse = DB.Employees.FirstOrDefault(x => x.JobTitle.Title == JobTitle.HealthNurse && x.District.DistrictId == selectedPatient.District.DistrictId);
                if (selectedNurse == null)
                {
                    wovm.ViewMessage = "Pacientov okoliš nima dodeljene patronažne sestre!";
                    return false;
                }
                wodvm.SelectedNurseId = selectedNurse.EmployeeId;
                wosvm.Nurse = selectedNurse.FullName;

                Employee employee = DB.Employees.FirstOrDefault(x => x.EmployeeId == wodvm.SupervisorId);
                Contractor contractor = employee.Contractor;

                WorkOrder workOrder = new WorkOrder();
                workOrder.Contractor = contractor;
                workOrder.Issuer = employee;
                workOrder.Service = DB.Services.FirstOrDefault(x => x.ServiceId == wodvm.SelectedServiceId);
                workOrder.Name = workOrder.Service.ServiceTitle;
                workOrder.Nurse = DB.Employees.FirstOrDefault(x => x.EmployeeId == wodvm.SelectedNurseId);
                //workOrder.NurseReplacement = null;
                workOrder.Patient = DB.Patients.FirstOrDefault(x => x.PatientId == wodvm.PatientId);
                workOrder.DateCreated = wodvm.DateCreated;

                Visit visit = new Visit();
                visit.Date = wodvm.DateTimeOfFirstVisit;
                visit.DateConfirmed = wodvm.DateTimeOfFirstVisit;
                visit.Mandatory = wodvm.MandatoryFirstVisit;
                visit.WorkOrder = workOrder;
                visit.Done = false;

                // Check for single or multiple visits.
                if (wodvm.MultipleVisits && wodvm.NumberOfVisits > 1)
                {
                    int timeFrame = 1;
                    bool mandatoryvisit = wodvm.MandatoryFirstVisit;
                    if (wodvm.TimeType == WorkOrderViewModel.VisitTimeType.TimeFrame)
                    {
                        timeFrame = (wodvm.TimeFrame - wodvm.DateTimeOfFirstVisit).Days / (wodvm.NumberOfVisits - 1);
                        mandatoryvisit = false;
                    }
                    else if (wodvm.TimeType == WorkOrderViewModel.VisitTimeType.TimeInterval)
                    {
                        timeFrame = wodvm.TimeInterval;
                    }

                    for (int i = 1; i < wodvm.NumberOfVisits; i++)
                    {
                        Visit vis = new Visit();
                        vis.Date = wodvm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                        vis.DateConfirmed = wodvm.DateTimeOfFirstVisit.AddDays(timeFrame * i);
                        vis.Mandatory = mandatoryvisit;
                        vis.WorkOrder = workOrder;
                        DB.Visits.Add(vis);
                    }
                }

                // Get all used medicine
                if (wodvm.EnterMedicine)
                {
                    List<Medicine> medicines = DB.Medicines.Where(x => wodvm.MedicineIds.Contains(x.MedicineId)).ToList();
                    foreach (var medicine in medicines)
                    {
                        MedicineWorkOrder medicineWorkOrder = new MedicineWorkOrder();
                        medicineWorkOrder.Medicine = medicine;
                        medicineWorkOrder.WorkOrder = workOrder;
                        DB.MedicineWorkOrders.Add(medicineWorkOrder);
                    }
                }

                if (wodvm.EnterBloodSample)
                {
                    BloodSample bloodSample = new BloodSample();
                    bloodSample.BloodVialBlueCount = wodvm.BloodVialBlueCount;
                    bloodSample.BloodVialGreenCount = wodvm.BloodVialGreenCount;
                    bloodSample.BloodVialRedCount = wodvm.BloodVialRedCount;
                    bloodSample.BloodVialYellowCount = wodvm.BloodVialYellowCount;

                    bloodSample.WorkOrder = workOrder;
                    DB.BloodSamples.Add(bloodSample);
                }

                if (wodvm.EnterPatients)
                {
                    foreach (var id in wodvm.PatientIds)
                    {
                        Patient patient = DB.Patients.FirstOrDefault(x => x.PatientId == id);
                        if (patient != null)
                        {
                            PatientWorkOrder patientWorkOrder = new PatientWorkOrder();
                            patientWorkOrder.WorkOrder = workOrder;
                            patientWorkOrder.Patient = patient;

                            DB.PatientWorkOrders.Add(patientWorkOrder);
                        }
                    }
                }

                DB.WorkOrders.Add(workOrder);
                DB.Visits.Add(visit);

                //DB.SaveChanges();

                return true;
            }
        }






    }
}