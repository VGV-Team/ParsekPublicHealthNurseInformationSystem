namespace ParsekPublicHealthNurseInformationSystem.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParsekPublicHealthNurseInformationSystem.Models.EntityDataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ParsekPublicHealthNurseInformationSystem.Models.EntityDataModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Role AdminRole = new Role { Title = Role.RoleEnum.Admin };
            Role EmployeeRole = new Role { Title = Role.RoleEnum.Employee };
            Role PatientRole = new Role { Title = Role.RoleEnum.Patient };

            context.Roles.AddOrUpdate(
                r => r.Title,
                AdminRole,
                EmployeeRole,
                PatientRole
            );


            // Relationships
            Relationship rel1, rel2, rel3, rel4;
            rel1 = new Relationship();
            rel1.Name = "Starš - otrok";
            rel2 = new Relationship();
            rel2.Name = "Ožji družinski krog";
            rel3 = new Relationship();
            rel3.Name = "Širši družinski krog";
            rel4 = new Relationship();
            rel4.Name = "Ni v sorodu";
            context.Relationships.AddOrUpdate(rel => rel.Name, rel1, rel2, rel3, rel4);

            // Diseases
            Disease d1, d2, d3, d4;
            d1 = new Disease();
            d2 = new Disease();
            d3 = new Disease();
            d4 = new Disease();
            d1.Code = "Z34.0";
            d1.Description = "Nadzor nad normalno prvo noseènostjo";
            d2.Code = "Z34.8";
            d2.Description = "Nadzor nad drugimi normalnimi noseènostmi";
            d3.Code = "Z34.9";
            d3.Description = "Nadzor nad normalno noseènostjo, neopredeljen";
            d4.Code = "Z35.0";
            d4.Description = "Nadzor nad noseènostjo z anamnezo infertilnosti";
            context.Diseases.AddOrUpdate(d => d.Code, d1, d2, d3, d4);
            // TODO: ...

            // Medicine
            Medicine m1, m2, m3, m4;
            m1 = new Medicine();
            m2 = new Medicine();
            m3 = new Medicine();
            m4 = new Medicine();
            m1.Code = "133000";
            m1.Title = "Abseamed 8.000 i.e./0,8 ml raztopina za inj";
            m2.Code = "136092";
            m2.Title = "Acidum nitricum C30 kroglice";
            m3.Code = "025704";
            m3.Title = "Acipan 40 mg prašek za raztopino za injicir";
            m4.Code = "121550";
            m4.Title = "Aconitum napellus C200 kroglice";
            context.Medicines.AddOrUpdate(m => m.Code, m1, m2, m3, m4);
            // TODO: ...

            // Post Office
            PostOffice p1, p2, p3, p4;
            p1 = new PostOffice();
            p1.Title = "Ajdovšèina";
            p1.Number = "5270";
            p2 = new PostOffice();
            p2.Title = "Bled"; // kremšnite
            p2.Number = "4260";
            p3 = new PostOffice();
            p3.Title = "Litija";
            p3.Number = "1270";
            p4 = new PostOffice();
            p4.Title = "Ljubljana";
            p4.Number = "1000";
            context.PostOffices.AddOrUpdate(p => p.Number, p1, p2, p3, p4);
            // TODO: ...

            // Contractors
            Contractor c1, c2, c3, c4;
            c1 = new Contractor();
            c1.Title = "ZDRAVSTVENI DOM AJDOVŠÈINA";
            c1.Number = "00130";
            c1.Address = "TOVARNIŠKA CESTA 3";
            c1.PostOffice = p1;
            c2 = new Contractor();
            c2.Title = "COR MEDICO ZAVOD";
            c2.Number = "55022";
            c2.Address = "KOMENSKEGA ULICA 32";
            c2.PostOffice = p4;
            c3 = new Contractor();
            c3.Title = "FIZIO CENTER PLUS D.O.O.";
            c3.Number = "55021";
            c3.Address = "ULICA MIRE PREGLJEVE 1";
            c3.PostOffice = p3;
            c4 = new Contractor();
            c4.Title = "DIAGNOSTIÈNI CENTER BLED D.O.O.";
            c4.Number = "04970";
            c4.Address = "POD SKALO 4";
            c4.PostOffice = p2;
            context.Contractors.AddOrUpdate(c => c.Number, c1, c2, c3, c4);
            // TODO: ...

            // Districts
            District di1, di2, di3, di4;
            di1 = new District();
            di1.Name = "Okolis 1";
            di1.Lat = (decimal)100.0;
            di1.Lon = (decimal)100.0;
            di2 = new District();
            di2.Name = "Okolis 2";
            di2.Lat = (decimal)200.0;
            di2.Lon = (decimal)200.0;
            di3 = new District();
            di3.Name = "Okolis 3";
            di3.Lat = (decimal)300.0;
            di3.Lon = (decimal)300.0;
            di4 = new District();
            di4.Name = "Okolis 4";
            di4.Lat = (decimal)400.0;
            di4.Lon = (decimal)999.0;
            context.Districts.AddOrUpdate(d => d.Name, di1, di2, di3, di4);
            // TODO: ...

            Material mat1, mat2, mat3, mat4;
            mat1 = new Material();
            mat1.Title = "Epruveta";
            mat1.Description = "Splošno uporabna epruveta";
            mat2 = new Material();
            mat2.Title = "Injekcija";
            mat2.Description = "Splošno uporabna injekcija";
            mat3 = new Material();
            mat3.Title = "Radijeva sol";
            mat3.Description = "Za boljše poèutje";
            mat4 = new Material();
            mat4.Title = "Svinènik";
            mat4.Description = "Za zapisovanje";
            context.Materials.AddOrUpdate(m => m.Title, mat1, mat2, mat3, mat4);
            // TODO: ...

            Patient patient1 = new Patient();
            patient1.CardNumber = "qweqwe";
            patient1.Name = "Frampt";
            patient1.Surname = "Kingseeker";
            patient1.Address = "A hole";
            patient1.PostOffice = p1;
            patient1.District = di1;
            patient1.PhoneNumber = "4545";
            patient1.Gender = Models.Patient.GenderEnum.Male;
            patient1.BirthDate = DateTime.Now.AddMonths(-10);
            Patient patient2 = new Patient();
            patient2.CardNumber = "wuuut";
            patient2.Name = "Undead";
            patient2.Surname = "The Chosen";
            patient2.Address = "Asylum";
            patient2.PostOffice = p2;
            patient2.District = di2;
            patient2.PhoneNumber = "9000";
            patient2.Gender = Models.Patient.GenderEnum.Male;
            patient2.BirthDate = DateTime.Now.AddMonths(-5);
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1, patient2);

            User Admin = new User();
            Admin.Employee = null;
            Admin.Patient = null;
            Admin.Role = AdminRole;
            Admin.Email = "admin@parsek.si";
            Admin.Password = "admin";
            Admin.Active = true;
            Admin.LastLastLogin = DateTime.Now;
            Admin.LastLogin = DateTime.Now;
            User Doctor = new User();
            Doctor.Employee = null;
            Doctor.Patient = null;
            Doctor.Role = EmployeeRole;
            Doctor.Email = "doctor@parsek.si";
            Doctor.Password = "doctor";
            Doctor.Active = true;
            Doctor.LastLastLogin = DateTime.Now;
            Doctor.LastLogin = DateTime.Now;
            User Nurse1 = new User();
            Nurse1.Employee = null;
            Nurse1.Patient = null;
            Nurse1.Role = EmployeeRole;
            Nurse1.Email = "nurse1@parsek.si";
            Nurse1.Password = "nurse1";
            Nurse1.Active = true;
            Nurse1.LastLastLogin = DateTime.Now;
            Nurse1.LastLogin = DateTime.Now;
            User Nurse2 = new User();
            Nurse2.Employee = null;
            Nurse2.Patient = null;
            Nurse2.Role = EmployeeRole;
            Nurse2.Email = "nurse2@parsek.si";
            Nurse2.Password = "nurse2";
            Nurse2.Active = true;
            Nurse2.LastLastLogin = DateTime.Now;
            Nurse2.LastLogin = DateTime.Now;
            User Patient1 = new User();
            Patient1.Employee = null;
            Patient1.Patient = null;
            Patient1.Role = PatientRole;
            Patient1.Email = "injured@work.com";
            Patient1.Password = "death";
            Patient1.Active = true;
            Patient1.Patient = patient1;
            Patient1.LastLastLogin = DateTime.Now;
            Patient1.LastLogin = DateTime.Now;
            User Patient2 = new User();
            Patient2.Employee = null;
            Patient2.Patient = null;
            Patient2.Role = PatientRole;
            Patient2.Email = "chosen@undead.com";
            Patient2.Password = "Humanity";
            Patient2.Active = true;
            Patient2.Patient = patient2;
            Patient2.LastLastLogin = DateTime.Now;
            Patient2.LastLogin = DateTime.Now;
            context.Users.AddOrUpdate(a => a.Email, Admin, Doctor, Nurse1, Nurse2, Patient1, Patient2);


            Employee DoctorEmployee = new Employee();
            DoctorEmployee.User = Doctor;
            DoctorEmployee.Name = "Doctory";
            DoctorEmployee.Surname = "Doktorsky";
            DoctorEmployee.Contractor = c1;
            //AdminEmployee.District = di1;
            DoctorEmployee.Number = "jmmfgh";
            DoctorEmployee.PhoneNumber = "867685";
            DoctorEmployee.Title = Employee.JobTitle.Doctor;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee);

            Employee NurseEmployee1 = new Employee();
            NurseEmployee1.User = Nurse1;
            NurseEmployee1.Name = "Nurse";
            NurseEmployee1.Surname = "Nursy";
            NurseEmployee1.Contractor = c1;
            NurseEmployee1.District = di1;
            NurseEmployee1.Number = "234234";
            NurseEmployee1.PhoneNumber = "77777";
            NurseEmployee1.Title = Employee.JobTitle.HealthNurse;
            Employee NurseEmployee2 = new Employee();
            NurseEmployee2.User = Nurse2;
            NurseEmployee2.Name = "Lt.";
            NurseEmployee2.Surname = "Morales";
            NurseEmployee2.Contractor = c1;
            NurseEmployee2.District = di1;
            NurseEmployee2.Number = "1111";
            NurseEmployee2.PhoneNumber = "4444";
            NurseEmployee2.Title = Employee.JobTitle.HealthNurse;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee, NurseEmployee1, NurseEmployee2);

            Activity ac1 = new Activity();
            ac1.ServiceCode = "10";
            ac1.ServiceTitle = "Obisk noseènice";
            ac1.ActivityCode = "10";
            ac1.ActivityTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu.";
            ac1.Report = "Prosti vnos";
            ac1.PreventiveVisit = true;
            Activity ac2 = new Activity();
            ac2.ServiceCode = "70";
            ac2.ServiceTitle = "Kontrola zdravstvenega stanja";
            ac2.ActivityCode = "20";
            ac2.ActivityTitle = "Krvni pritisk: sistolièni, diastolièni";
            ac2.Report = "Sistolièni (mm Hg) * Diastolièni(mm Hg) *";
            ac2.PreventiveVisit = false;

            Activity ac3 = new Activity();
            ac3.ServiceCode = "50";
            ac3.ServiceTitle = "Aplikacija injekcij";
            ac3.ActivityCode = "10";
            ac3.ActivityTitle = "Aplikacija injekcije";
            ac3.Report = "";
            ac3.PreventiveVisit = false;
            Activity ac4 = new Activity();
            ac4.ServiceCode = "60";
            ac4.ServiceTitle = "Odvzem krvi";
            ac4.ActivityCode = "10";
            ac4.ActivityTitle = "Odvzem krvi";
            ac4.Report = "";
            ac4.PreventiveVisit = false;
            context.Activities.AddOrUpdate(y => y.ActivityId, ac1, ac2, ac3, ac4);





            WorkOrder wo = new WorkOrder();
            wo.Activity = ac1;
            wo.Contractor = c1;
            wo.Disease = d1;
            wo.Issuer = DoctorEmployee;
            wo.Name = "The Chosen One";
            wo.Nurse = NurseEmployee1;
            wo.NurseReplacement = NurseEmployee1;


            Visit v = new Visit();
            v.Date = DateTime.Now;
            v.Mandatory = true;
            v.WorkOrder = wo;
            v.Confirmed = true;
            context.Visits.AddOrUpdate(vis => vis.VisitId, v);
            context.WorkOrders.AddOrUpdate(wordr => wordr.WorkOrderId, wo);

            /*if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

            System.Diagnostics.Debug.WriteLine("Mejl: "+context.Employees.Where(e => e.Number == "qeasdasd").FirstOrDefault().User.Email);*/


        }
    }
}
