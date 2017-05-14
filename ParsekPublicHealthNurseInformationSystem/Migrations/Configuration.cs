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
            m1.Code = "13300";
            m1.Title = "Abseamed 8.000 i.e./0,8 ml raztopina za inj";
            m2.Code = "13692";
            m2.Title = "Acidum nitricum C30 kroglice";
            m3.Code = "02504";
            m3.Title = "Acipan 40 mg prašek za raztopino za injicir";
            m4.Code = "21550";
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
            
            // TODO: ...

            // Districts
            District di1, di2, di3, di4, di5, di6, di7, di8;
            di1 = new District();
            di1.Name = "Okoliš 1";
            di1.Lat = (decimal)100.0;
            di1.Lon = (decimal)100.0;
            di2 = new District();
            di2.Name = "Okoliš 2";
            di2.Lat = (decimal)200.0;
            di2.Lon = (decimal)200.0;
            di3 = new District();
            di3.Name = "Okoliš 3";
            di3.Lat = (decimal)300.0;
            di3.Lon = (decimal)300.0;
            di4 = new District();
            di4.Name = "Okoliš 4";
            di4.Lat = (decimal)400.0;
            di4.Lon = (decimal)999.0;
            di5 = new District();
            di5.Name = "Okoliš 5";
            di5.Lat = (decimal)400.0;
            di5.Lon = (decimal)999.0;
            di6 = new District();
            di6.Name = "Okoliš 6";
            di6.Lat = (decimal)400.0;
            di6.Lon = (decimal)999.0;
            di7 = new District();
            di7.Name = "Okoliš 7";
            di7.Lat = (decimal)400.0;
            di7.Lon = (decimal)999.0;
            di8 = new District();
            di8.Name = "Okoliš 8";
            di8.Lat = (decimal)400.0;
            di8.Lon = (decimal)999.0;

            di1.Contractor = c1;
            di2.Contractor = c1;

            di3.Contractor = c1;
            di4.Contractor = c1;

            /*di5.Contractor = c3;
            di6.Contractor = c3;

            di7.Contractor = c4;
            di8.Contractor = c4;*/

            //context.Districts.AddOrUpdate(d => d.Name, di1, di2, di3, di4, di5, di6, di7, di8);
            context.Districts.AddOrUpdate(d => d.Name, di1, di2, di3, di4);
            context.Contractors.AddOrUpdate(c => c.Number, c1, c2, c3, c4);
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
            patient1.CardNumber = "65456";
            patient1.Name = "Janežina";
            patient1.Surname = "Novak";
            patient1.Address = "Žememlje 8";
            patient1.PostOffice = p1;
            patient1.District = di1;
            patient1.PhoneNumber = "1234566666";
            patient1.Gender = Models.Patient.GenderEnum.Female;
            patient1.BirthDate = DateTime.Now.AddYears(-30);
            Patient patient2 = new Patient();
            patient2.CardNumber = "99878";
            patient2.Name = "Francelj";
            patient2.Surname = "Horvat";
            patient2.Address = "Partizanska 99";
            patient2.PostOffice = p2;
            patient2.District = di2;
            patient2.PhoneNumber = "090999999";
            patient2.Gender = Models.Patient.GenderEnum.Male;
            patient2.BirthDate = DateTime.Now.AddYears(-50);
            Patient patient3 = new Patient();
            patient3.CardNumber = "78879";
            patient3.Name = "Joža";
            patient3.Surname = "Boža";
            patient3.Address = "Domobranska 11";
            patient3.PostOffice = p3;
            patient3.District = di1;
            patient3.PhoneNumber = "090888880";
            patient3.Gender = Models.Patient.GenderEnum.Female;
            patient3.BirthDate = DateTime.Now.AddYears(-40);
            Patient patient1_1 = new Patient();
            patient1_1.CardNumber = "88888";
            patient1_1.Name = "Sif";
            patient1_1.Surname = "Novak";
            patient1_1.Address = "Žememlje 8";
            patient1_1.PostOffice = p1;
            patient1_1.District = di1;
            patient1_1.PhoneNumber = "090888880";
            patient1_1.Gender = Models.Patient.GenderEnum.Male;
            patient1_1.BirthDate = DateTime.Now.AddYears(-50);
            patient1_1.ParentPatient = patient1;
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1, patient2, patient3, patient1_1);

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
            User Nurse3 = new User();
            Nurse3.Employee = null;
            Nurse3.Patient = null;
            Nurse3.Role = EmployeeRole;
            Nurse3.Email = "nurse3@parsek.si";
            Nurse3.Password = "nurse3";
            Nurse3.Active = true;
            Nurse3.LastLastLogin = DateTime.Now;
            Nurse3.LastLogin = DateTime.Now;
            User Nurse4 = new User();
            Nurse4.Employee = null;
            Nurse4.Patient = null;
            Nurse4.Role = EmployeeRole;
            Nurse4.Email = "nurse4@parsek.si";
            Nurse4.Password = "nurse4";
            Nurse4.Active = true;
            Nurse4.LastLastLogin = DateTime.Now;
            Nurse4.LastLogin = DateTime.Now;
            User Patient1 = new User();
            Patient1.Employee = null;
            Patient1.Patient = null;
            Patient1.Role = PatientRole;
            Patient1.Email = "patient1@parsek.si";
            Patient1.Password = "patient1";
            Patient1.Active = true;
            Patient1.Patient = patient1;
            Patient1.LastLastLogin = DateTime.Now;
            Patient1.LastLogin = DateTime.Now;
            User Patient2 = new User();
            Patient2.Employee = null;
            Patient2.Patient = null;
            Patient2.Role = PatientRole;
            Patient2.Email = "patient2@parsek.si";
            Patient2.Password = "patient2";
            Patient2.Active = true;
            Patient2.Patient = patient2;
            Patient2.LastLastLogin = DateTime.Now;
            Patient2.LastLogin = DateTime.Now;
            User Patient3 = new User();
            Patient3.Employee = null;
            Patient3.Patient = null;
            Patient3.Role = PatientRole;
            Patient3.Email = "patient3@parsek.si";
            Patient3.Password = "patient3";
            Patient3.Active = true;
            Patient3.Patient = patient3;
            Patient3.LastLastLogin = DateTime.Now;
            Patient3.LastLogin = DateTime.Now;
            User Head = new User();
            Head.Employee = null;
            Head.Patient = null;
            Head.Role = EmployeeRole;
            Head.Email = "head@parsek.si";
            Head.Password = "head";
            Head.Active = true;
            Head.LastLastLogin = DateTime.Now;
            Head.LastLogin = DateTime.Now;
            context.Users.AddOrUpdate(a => a.Email, Admin, Doctor, Nurse1, Nurse2, Nurse3, Nurse4, Patient1, Patient2, Patient3, Head);


            Employee DoctorEmployee = new Employee();
            DoctorEmployee.User = Doctor;
            DoctorEmployee.Name = "Doctory";
            DoctorEmployee.Surname = "Doktorsky";
            DoctorEmployee.Contractor = c1;
            DoctorEmployee.Number = "78989";
            DoctorEmployee.PhoneNumber = "081579856";
            DoctorEmployee.Title = Employee.JobTitle.Doctor;
            Employee HeadEmployee = new Employee();
            HeadEmployee.User = Head;
            HeadEmployee.Name = "Head";
            HeadEmployee.Surname = "Headovsky";
            HeadEmployee.Contractor = c1;
            HeadEmployee.Number = "89795";
            HeadEmployee.PhoneNumber = "055555666";
            HeadEmployee.Title = Employee.JobTitle.Head;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee, HeadEmployee);

            Employee NurseEmployee1 = new Employee();
            NurseEmployee1.User = Nurse1;
            NurseEmployee1.Name = "Nurse";
            NurseEmployee1.Surname = "Nursy";
            NurseEmployee1.Contractor = c1;
            NurseEmployee1.District = di1;
            NurseEmployee1.Number = "44646";
            NurseEmployee1.PhoneNumber = "222333444";
            NurseEmployee1.Title = Employee.JobTitle.HealthNurse;
            Employee NurseEmployee2 = new Employee();
            NurseEmployee2.User = Nurse2;
            NurseEmployee2.Name = "Katarina";
            NurseEmployee2.Surname = "Morales";
            NurseEmployee2.Contractor = c1;
            NurseEmployee2.District = di2;
            NurseEmployee2.Number = "78797";
            NurseEmployee2.PhoneNumber = "888777654";
            NurseEmployee2.Title = Employee.JobTitle.HealthNurse;
            Employee NurseEmployee3 = new Employee();
            NurseEmployee3.User = Nurse3;
            NurseEmployee3.Name = "Anri";
            NurseEmployee3.Surname = "Astora";
            NurseEmployee3.Contractor = c1;
            NurseEmployee3.District = di3;
            NurseEmployee3.Number = "99999";
            NurseEmployee3.PhoneNumber = "035897546";
            NurseEmployee3.Title = Employee.JobTitle.HealthNurse;
            Employee NurseEmployee4 = new Employee();
            NurseEmployee4.User = Nurse4;
            NurseEmployee4.Name = "Elizabeta";
            NurseEmployee4.Surname = "Magdalena";
            NurseEmployee4.Contractor = c1;
            NurseEmployee4.District = di4;
            NurseEmployee4.Number = "45455";
            NurseEmployee4.PhoneNumber = "666444777";
            NurseEmployee4.Title = Employee.JobTitle.HealthNurse;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee, NurseEmployee1, NurseEmployee2, NurseEmployee3, NurseEmployee4);

            Service ac1 = new Service();
            ac1.ServiceCode = "10";
            ac1.ServiceTitle = "Obisk noseènice";
            //ac1.ServiceCode = "10";
            //ac1.ServiceTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu.";
            //ac1.Report = "Prosti vnos";
            ac1.PreventiveVisit = true;
            ac1.RequiresMedicine = false;
            ac1.RequiresBloodSample = false;
            ac1.RequiresPatients = false;
            Service ac2 = new Service();
            ac2.ServiceCode = "20";
            ac2.ServiceTitle = "Obisk otroènice";
            ac2.PreventiveVisit = true;
            ac2.RequiresMedicine = false;
            ac2.RequiresBloodSample = false;
            ac2.RequiresPatients = true;
            Service ac3 = new Service();
            ac3.ServiceCode = "30";
            ac3.ServiceTitle = "Obisk novorojenèka";
            ac3.PreventiveVisit = true;
            ac3.RequiresMedicine = false;
            ac3.RequiresBloodSample = false;
            ac3.RequiresPatients = true;
            Service ac4 = new Service();
            ac4.ServiceCode = "40";
            ac4.ServiceTitle = "Obisk starostnika";
            ac4.PreventiveVisit = true;
            ac4.RequiresMedicine = false;
            ac4.RequiresBloodSample = false;
            ac4.RequiresPatients = false; // Was in requirements!
            Service ac5 = new Service();
            ac5.ServiceCode = "50";
            ac5.ServiceTitle = "Aplikacija injekcij";
            //ac5.ServiceCode = "10";
            //ac5.ServiceTitle = "Aplikacija injekcije";
            //ac5.Report = "";
            ac5.PreventiveVisit = false;
            ac5.RequiresMedicine = true;
            ac5.RequiresBloodSample = false;
            ac5.RequiresPatients = false;
            Service ac6 = new Service();
            ac6.ServiceCode = "60";
            ac6.ServiceTitle = "Odvzem krvi";
            //ac6.ServiceCode = "10";
            //ac6.ServiceTitle = "Odvzem krvi";
            //ac6.Report = "";
            ac6.PreventiveVisit = false;
            ac6.RequiresMedicine = false;
            ac6.RequiresBloodSample = true;
            ac6.RequiresPatients = false;
            Service ac7 = new Service();
            ac7.ServiceCode = "70";
            ac7.ServiceTitle = "Kontrola zdravstvenega stanja";
            //ac7.ServiceCode = "20";
            //ac7.ServiceTitle = "Krvni pritisk: sistolièni, diastolièni";
            //ac7.Report = "Sistolièni (mm Hg) * Diastolièni(mm Hg) *";
            ac7.PreventiveVisit = false;
            ac7.RequiresMedicine = false;
            ac7.RequiresBloodSample = false;
            ac7.RequiresPatients = false;

            context.Services.AddOrUpdate(y => y.ServiceId, ac1, ac2, ac3, ac4, ac5, ac6, ac7);



            #region Activities

            Activity a1 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu.", Service = ac1 };
            Activity a2 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Povabilo v šolo za starše.", Service = ac1 };
            Activity a3 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev o rednih ginekoloških pregledih.", Service = ac1 };
            Activity a4 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev z bližajoèim se porodom in pravoèasnim odhodom v porodnišnico. ", Service = ac1 };
            Activity a5 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor in vkljuèevanje partnerja v noseènost in porod ter po prihodu domov. ", Service = ac1 };
            Activity a6 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o pripomoèkih, ki jih bo potrebovala v porodnišnici. ", Service = ac1 };
            Activity a7 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice o štetju in beleženju plodovih gibov. ", Service = ac1 };
            Activity a8 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje glede opreme za novorojenca in primerno ležišèe. ", Service = ac1 };
            Activity a9 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o pravilni prehrani, ustrezni izbiri obleke in obutve.", Service = ac1 };
            Activity a10 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o primernem režim življenja, telesne vaje, gibanje na svežem zraku.", Service = ac1 };
            Activity a11 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Odsvetovanje razvad kot so uživanje alkohola, kajenje, uživanje zdravil in drog. ", Service = ac1 };
            Activity a12 = new Activity() { ActivityCode = 120, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev nosoènice z nevšeènostmi in svetovanje glede lajšanja težav zaradi nevšeènosti (slabosti, bruhanja, zaprtja, pogostih mikcij, nespeènosti, zgage, ...).", Service = ac1 };
            Activity a13 = new Activity() { ActivityCode = 130, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice s pravicami do starševskega dopusta (porodniški dopust, pravica do dopusta za nego in varstvo otroka, pravica do oèetovskega dopusta) in o uveljavljanju pravic povezanih z rojstvom otroka (pravica do paketa, otroški dodatek, zdravstveno zavarovanje, rojstni list, ureditev oèetovstva).", Service = ac1 };
            Activity a14 = new Activity() { ActivityCode = 140, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Prièakovan datum poroda", Service = ac1 };
            Activity a15 = new Activity() { ActivityCode = 150, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza: poèutje, telesni znaki noseènosti.", Service = ac1 };
            Activity a16 = new Activity() { ActivityCode = 160, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Družinska anamneza: Odnosi v družini, odnos družine do okolja, bivalni pogoji, ekonomske razmere, zdravstveno stanje družinskih èlanov, zdravstvena prosvetljenost in vzgojenost.", Service = ac1 };
            Activity a17 = new Activity() { ActivityCode = 170, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Izražanje èustev", Service = ac1 };
            Activity a18 = new Activity() { ActivityCode = 180, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Fizièna obremenjenost", Service = ac1 };
            Activity a19 = new Activity() { ActivityCode = 190, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni pritisk: sistolièni, diastolièni", Service = ac1 };
            Activity a20 = new Activity() { ActivityCode = 200, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Srèni utrip", Service = ac1 };
            Activity a21 = new Activity() { ActivityCode = 210, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dihanje", Service = ac1 };
            Activity a22 = new Activity() { ActivityCode = 220, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna temperatura", Service = ac1 };
            Activity a23 = new Activity() { ActivityCode = 230, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Telesna teža pred noseènostjo", Service = ac1 };
            Activity a24 = new Activity() { ActivityCode = 240, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Trenutna telesna teža", Service = ac1 };
            Activity a25 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Pregled materinske knjižice in odpustnice iz porodnišnice. ", Service = ac2 };
            Activity a26 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Kontrola vitalnih funkcij.", Service = ac2 };
            Activity a27 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Opazovanje èišèe. ", Service = ac2 };
            Activity a28 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Nadzor nad izloèanjem blata in urina. ", Service = ac2 };
            Activity a29 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Zdravstveno vzgojno delo glede pravilnega rokovanja z novorojenèkom, uèenje tehnike nege novorojenèka", Service = ac2 };
            Activity a30 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Motivacija za dojenje. Nadzor in pomoè pri dojenju. ", Service = ac2 };
            Activity a31 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o èustveni podpori s strani partnerja.", Service = ac2 };
            Activity a32 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Seznanitev o otrokovih potrebah po toplini, nežnosti in varnosti.", Service = ac2 };
            Activity a33 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o spalnih potrebah otroènice, pravilni negi in higienskem režimu v poporodnem obdobju. ", Service = ac2 };
            Activity a34 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o pravilni prehrani, pitju ustreznih kolièin tekoèin", Service = ac2 };
            Activity a35 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Pouèitev o poporodni telovadbi.", Service = ac2 };
            Activity a36 = new Activity() { ActivityCode = 120, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Sezananitev z nekaterimi obolenji.", Service = ac2 };
            Activity a37 = new Activity() { ActivityCode = 130, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Napotitev na poporodni pregled.", Service = ac2 };
            Activity a38 = new Activity() { ActivityCode = 140, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Seznanitev z metodami zašèite pred nezaželjno noseènostjo.", Service = ac2 };
            Activity a39 = new Activity() { ActivityCode = 150, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o normalnem delu, življenju in spolnih odnosih. ", Service = ac2 };
            Activity a40 = new Activity() { ActivityCode = 160, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni pritisk", Service = ac2 };
            Activity a41 = new Activity() { ActivityCode = 170, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Srèni utrip", Service = ac2 };
            Activity a42 = new Activity() { ActivityCode = 180, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dihanje", Service = ac2 };
            Activity a43 = new Activity() { ActivityCode = 190, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna temperatura", Service = ac2 };
            Activity a44 = new Activity() { ActivityCode = 200, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Trenutna telesna teža", Service = ac2 };
            Activity a45 = new Activity() { ActivityCode = 210, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza: poèutje, telesni znaki noseènosti.", Service = ac2 };
            Activity a46 = new Activity() { ActivityCode = 220, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Družinska anamneza: odnosi v družini, odnos družine do okolja, bivalni pogoji, ekonomske razmere, zdravstveno stanje družinskih èlanov, zdravstvena prosvetljenost in vzgojenost.", Service = ac2 };
            Activity a47 = new Activity() { ActivityCode = 230, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Izražanje èustev", Service = ac2 };
            Activity a48 = new Activity() { ActivityCode = 240, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Fizièna obremenjenost", Service = ac2 };
            Activity a49 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Prikaz nege dojenèka", Service = ac3 };
            Activity a50 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Nega popokovne rane", Service = ac3 };
            Activity a51 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Nudenje pomoèi pri dojenju in seznanitev s tehnikami dojenja.", Service = ac3 };
            Activity a52 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Ureditev ležišèa.", Service = ac3 };
            Activity a53 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o povijanju, oblaèenju, slaèenju", Service = ac3 };
            Activity a54 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Trenutna telesna teža", Service = ac3 };
            Activity a55 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Trenutna telesna višina", Service = ac3 };
            Activity a56 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dojenje", Service = ac3 };
            Activity a57 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dodajanje adaptiranega mleka", Service = ac3 };
            Activity a58 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Izloèanje in odvajanje", Service = ac3 };
            Activity a59 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Ritem spanja", Service = ac3 };
            Activity a60 = new Activity() { ActivityCode = 120, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Povišanje bilirubina (zlatenica)", Service = ac3 };
            Activity a61 = new Activity() { ActivityCode = 130, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Kolki", Service = ac3 };
            Activity a62 = new Activity() { ActivityCode = 140, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Posebnosti", Service = ac3 };
            Activity a63 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza", Service = ac4 };
            Activity a64 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Družinska anamneza", Service = ac4 };
            Activity a65 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni pritisk: sistolièni, diastolièni", Service = ac4 };
            Activity a66 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Srèni utrip", Service = ac4 };
            Activity a67 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dihanje", Service = ac4 };
            Activity a68 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna temperatura", Service = ac4 };
            Activity a69 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna teža", Service = ac4 };
            Activity a70 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Osebna higiena", Service = ac4 };
            Activity a71 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Prehranjevanje in pitje", Service = ac4 };
            Activity a72 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Izloèanje in odvajanje", Service = ac4 };
            Activity a73 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Gibanje", Service = ac4 };
            Activity a74 = new Activity() { ActivityCode = 120, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Èutila in obèutki", Service = ac4 };
            Activity a75 = new Activity() { ActivityCode = 130, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Spanje in poèitek", Service = ac4 };
            Activity a76 = new Activity() { ActivityCode = 140, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Duševno stanje: izražanje èustev in potreb, komunikacija", Service = ac4 };
            Activity a77 = new Activity() { ActivityCode = 150, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Stanje neodvisnosti", Service = ac4 };
            Activity a78 = new Activity() { ActivityCode = 160, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pregled predpisanih terapij", Service = ac4 };
            Activity a79 = new Activity() { ActivityCode = 170, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor, nasvet in vzpodbuda.", Service = ac4 };
            Activity a80 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Aplikacija injekcije", Service = ac5 };
            Activity a81 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor, nasvet in vzpodbuda.", Service = ac5 };
            Activity a82 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Odvzem krvi", Service = ac6 };
            Activity a83 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor, nasvet in vzpodbuda.", Service = ac6 };
            Activity a84 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza", Service = ac7 };
            Activity a85 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni pritisk: sistolièni, diastolièni", Service = ac7 };
            Activity a86 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Srèni utrip", Service = ac7 };
            Activity a87 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dihanje", Service = ac7 };
            Activity a88 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna temperatura", Service = ac7 };
            Activity a89 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni sladkor", Service = ac7 };
            Activity a90 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Oksigenacija SpO2", Service = ac7 };
            Activity a91 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Upoštevanje terapije", Service = ac7 };
            Activity a92 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pregled terapije", Service = ac7 };
            Activity a93 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Navodila za terapijo do naslednjega obiska", Service = ac7 };
            Activity a94 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor, nasvet in vzpodbuda.", Service = ac7 };

            context.Activities.AddOrUpdate(y => y.ActivityId, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55, a56, a57, a58, a59, a60, a61, a62, a63, a64, a65, a66, a67, a68, a69, a70, a71, a72, a73, a74, a75, a76, a77, a78, a79, a80, a81, a82, a83, a84, a85, a86, a87, a88, a89, a90, a91, a92, a93, a94);

            #endregion

            #region ActivityInputs

            ActivityInput ai1 = new ActivityInput() { Activity = a1, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai2 = new ActivityInput() { Activity = a2, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai3 = new ActivityInput() { Activity = a3, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai4 = new ActivityInput() { Activity = a4, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai5 = new ActivityInput() { Activity = a5, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai6 = new ActivityInput() { Activity = a6, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai7 = new ActivityInput() { Activity = a7, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai8 = new ActivityInput() { Activity = a8, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai9 = new ActivityInput() { Activity = a9, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai10 = new ActivityInput() { Activity = a10, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai11 = new ActivityInput() { Activity = a11, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai12 = new ActivityInput() { Activity = a12, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai13 = new ActivityInput() { Activity = a13, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai14 = new ActivityInput() { Activity = a14, Title = "Datum ", InputType = ActivityInput.InputTypeEnum.Date, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai15 = new ActivityInput() { Activity = a15, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai16 = new ActivityInput() { Activity = a16, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai17 = new ActivityInput() { Activity = a17, Title = "Moteno/Ni moteno ", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Moteno;;Ni moteno", Required = true, OneTime = false };
            ActivityInput ai18 = new ActivityInput() { Activity = a17, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai19 = new ActivityInput() { Activity = a18, Title = "Nizka/Srednja/Visoka", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Nizka;;Srednja;;Visoka", Required = true, OneTime = false };
            ActivityInput ai20 = new ActivityInput() { Activity = a18, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai21 = new ActivityInput() { Activity = a19, Title = "Sistolièni (mm Hg) ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai22 = new ActivityInput() { Activity = a19, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai23 = new ActivityInput() { Activity = a20, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;150", Required = true, OneTime = false };
            ActivityInput ai24 = new ActivityInput() { Activity = a21, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;150", Required = true, OneTime = false };
            ActivityInput ai25 = new ActivityInput() { Activity = a22, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;45", Required = true, OneTime = false };
            ActivityInput ai26 = new ActivityInput() { Activity = a23, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai27 = new ActivityInput() { Activity = a24, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai28 = new ActivityInput() { Activity = a25, Title = "Datum rojstva otroka", InputType = ActivityInput.InputTypeEnum.Date, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai29 = new ActivityInput() { Activity = a25, Title = "Porodna teža otroka (g)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;20000", Required = true, OneTime = false };
            ActivityInput ai116 = new ActivityInput() { Activity = a25, Title = "Porodna višina otroka (cm)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;100", Required = true, OneTime = false };
            ActivityInput ai117 = new ActivityInput() { Activity = a25, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai30 = new ActivityInput() { Activity = a26, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai31 = new ActivityInput() { Activity = a27, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai32 = new ActivityInput() { Activity = a28, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai33 = new ActivityInput() { Activity = a29, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai34 = new ActivityInput() { Activity = a30, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai35 = new ActivityInput() { Activity = a31, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai36 = new ActivityInput() { Activity = a32, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai37 = new ActivityInput() { Activity = a33, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai38 = new ActivityInput() { Activity = a34, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai39 = new ActivityInput() { Activity = a35, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai40 = new ActivityInput() { Activity = a36, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai41 = new ActivityInput() { Activity = a37, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai42 = new ActivityInput() { Activity = a38, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai43 = new ActivityInput() { Activity = a39, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai44 = new ActivityInput() { Activity = a40, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai45 = new ActivityInput() { Activity = a40, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai46 = new ActivityInput() { Activity = a41, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;150", Required = true, OneTime = false };
            ActivityInput ai47 = new ActivityInput() { Activity = a42, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;150", Required = true, OneTime = false };
            ActivityInput ai48 = new ActivityInput() { Activity = a43, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;45", Required = true, OneTime = false };
            ActivityInput ai49 = new ActivityInput() { Activity = a44, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai50 = new ActivityInput() { Activity = a45, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai51 = new ActivityInput() { Activity = a46, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai52 = new ActivityInput() { Activity = a47, Title = "Moteno/Ni moteno", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Moteno;;Ni moteno", Required = true, OneTime = false };
            ActivityInput ai53 = new ActivityInput() { Activity = a47, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai54 = new ActivityInput() { Activity = a48, Title = "Nizka/Srednja/Visoka", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Nizka;;Srednja;;Visoka", Required = true, OneTime = false };
            ActivityInput ai55 = new ActivityInput() { Activity = a48, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai56 = new ActivityInput() { Activity = a49, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai57 = new ActivityInput() { Activity = a50, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai58 = new ActivityInput() { Activity = a51, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai59 = new ActivityInput() { Activity = a52, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai60 = new ActivityInput() { Activity = a53, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai61 = new ActivityInput() { Activity = a54, Title = "g", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;20000", Required = true, OneTime = false };
            ActivityInput ai62 = new ActivityInput() { Activity = a55, Title = "cm", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;300", Required = true, OneTime = false };
            ActivityInput ai63 = new ActivityInput() { Activity = a56, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai64 = new ActivityInput() { Activity = a56, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai65 = new ActivityInput() { Activity = a57, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai66 = new ActivityInput() { Activity = a57, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai67 = new ActivityInput() { Activity = a58, Title = "Posebnosti", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Ni posebnosti;;Mikcija;;Defekacija;;Napenjanje;;Kolike;;Polivanje;;Bruhanje", Required = true, OneTime = false };
            ActivityInput ai68 = new ActivityInput() { Activity = a58, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai69 = new ActivityInput() { Activity = a59, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai70 = new ActivityInput() { Activity = a60, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai71 = new ActivityInput() { Activity = a61, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai72 = new ActivityInput() { Activity = a62, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai73 = new ActivityInput() { Activity = a63, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai74 = new ActivityInput() { Activity = a64, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai75 = new ActivityInput() { Activity = a65, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai76 = new ActivityInput() { Activity = a65, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai77 = new ActivityInput() { Activity = a66, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;150", Required = true, OneTime = false };
            ActivityInput ai78 = new ActivityInput() { Activity = a67, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;150", Required = true, OneTime = false };
            ActivityInput ai79 = new ActivityInput() { Activity = a68, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;45", Required = true, OneTime = false };
            ActivityInput ai80 = new ActivityInput() { Activity = a69, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai81 = new ActivityInput() { Activity = a70, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai82 = new ActivityInput() { Activity = a71, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai83 = new ActivityInput() { Activity = a72, Title = "Urin", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai84 = new ActivityInput() { Activity = a72, Title = "Blato", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai85 = new ActivityInput() { Activity = a73, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai86 = new ActivityInput() { Activity = a74, Title = "Vid", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai87 = new ActivityInput() { Activity = a74, Title = "Vonj", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai88 = new ActivityInput() { Activity = a74, Title = "Sluh", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai89 = new ActivityInput() { Activity = a74, Title = "Okus", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai90 = new ActivityInput() { Activity = a74, Title = "Otip", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai91 = new ActivityInput() { Activity = a75, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai92 = new ActivityInput() { Activity = a76, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai93 = new ActivityInput() { Activity = a77, Title = "Odvisnost", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Samostojen;;Delno odvisen;;Povsem odvisen", Required = true, OneTime = false };
            ActivityInput ai94 = new ActivityInput() { Activity = a77, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai95 = new ActivityInput() { Activity = a77, Title = "Pomoè: svojci, drugi", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai96 = new ActivityInput() { Activity = a78, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai97 = new ActivityInput() { Activity = a79, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai981 = new ActivityInput() { Activity = a80, Title = "Injekcije aplicirane", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne;;Delno", Required = true, OneTime = false };
            ActivityInput ai98 = new ActivityInput() { Activity = a80, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai99 = new ActivityInput() { Activity = a81, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai1001 = new ActivityInput() { Activity = a82, Title = "Št. rdeèih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1002 = new ActivityInput() { Activity = a82, Title = "Št. modrih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1003 = new ActivityInput() { Activity = a82, Title = "Št. rumenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1004 = new ActivityInput() { Activity = a82, Title = "Št. zelenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai100 = new ActivityInput() { Activity = a82, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai101 = new ActivityInput() { Activity = a83, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai102 = new ActivityInput() { Activity = a84, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai103 = new ActivityInput() { Activity = a85, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai104 = new ActivityInput() { Activity = a85, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai105 = new ActivityInput() { Activity = a86, Title = "Udarci na minuto", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;150", Required = true, OneTime = false };
            ActivityInput ai106 = new ActivityInput() { Activity = a87, Title = "Vdihi na minuto", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;150", Required = true, OneTime = false };
            ActivityInput ai107 = new ActivityInput() { Activity = a88, Title = "st C", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "35;;45", Required = true, OneTime = false };
            ActivityInput ai108 = new ActivityInput() { Activity = a89, Title = "mmol/L", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;100", Required = true, OneTime = false };
            ActivityInput ai109 = new ActivityInput() { Activity = a89, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai110 = new ActivityInput() { Activity = a90, Title = "%", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;100", Required = true, OneTime = false };
            ActivityInput ai111 = new ActivityInput() { Activity = a91, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Delno;;Ne", Required = true, OneTime = false };
            ActivityInput ai112 = new ActivityInput() { Activity = a91, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai113 = new ActivityInput() { Activity = a92, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai114 = new ActivityInput() { Activity = a93, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai115 = new ActivityInput() { Activity = a94, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };

            /*
             ActivityInput ai1 = new ActivityInput() { Activity = a1, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai2 = new ActivityInput() { Activity = a2, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai3 = new ActivityInput() { Activity = a3, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai4 = new ActivityInput() { Activity = a4, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai5 = new ActivityInput() { Activity = a5, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai6 = new ActivityInput() { Activity = a6, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai7 = new ActivityInput() { Activity = a7, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai8 = new ActivityInput() { Activity = a8, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai9 = new ActivityInput() { Activity = a9, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai10 = new ActivityInput() { Activity = a10, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai11 = new ActivityInput() { Activity = a11, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai12 = new ActivityInput() { Activity = a12, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai13 = new ActivityInput() { Activity = a13, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai14 = new ActivityInput() { Activity = a14, Title = "Datum ", InputType = ActivityInput.InputTypeEnum.Date, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai15 = new ActivityInput() { Activity = a15, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai16 = new ActivityInput() { Activity = a16, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai17 = new ActivityInput() { Activity = a17, Title = "Moteno/Ni moteno ", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Moteno;;Ni moteno", Required = true, OneTime = false };
            ActivityInput ai18 = new ActivityInput() { Activity = a17, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai19 = new ActivityInput() { Activity = a18, Title = "Nizka/Srednja/Visoka", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Nizka;;Srednja;;Visoka", Required = true, OneTime = false };
            ActivityInput ai20 = new ActivityInput() { Activity = a18, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai21 = new ActivityInput() { Activity = a19, Title = "Sistolièni (mm Hg) ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai22 = new ActivityInput() { Activity = a19, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai23 = new ActivityInput() { Activity = a20, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai24 = new ActivityInput() { Activity = a21, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai25 = new ActivityInput() { Activity = a22, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai26 = new ActivityInput() { Activity = a23, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai27 = new ActivityInput() { Activity = a24, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai28 = new ActivityInput() { Activity = a25, Title = "Datum rojstva otroka", InputType = ActivityInput.InputTypeEnum.Date, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai29 = new ActivityInput() { Activity = a25, Title = "Porodna teža otroka (g)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = true };
            ActivityInput ai30 = new ActivityInput() { Activity = a26, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai31 = new ActivityInput() { Activity = a27, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai32 = new ActivityInput() { Activity = a28, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai33 = new ActivityInput() { Activity = a29, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai34 = new ActivityInput() { Activity = a30, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai35 = new ActivityInput() { Activity = a31, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai36 = new ActivityInput() { Activity = a32, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai37 = new ActivityInput() { Activity = a33, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai38 = new ActivityInput() { Activity = a34, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai39 = new ActivityInput() { Activity = a35, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai40 = new ActivityInput() { Activity = a36, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai41 = new ActivityInput() { Activity = a37, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai42 = new ActivityInput() { Activity = a38, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai43 = new ActivityInput() { Activity = a39, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai44 = new ActivityInput() { Activity = a40, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai45 = new ActivityInput() { Activity = a40, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai46 = new ActivityInput() { Activity = a41, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai47 = new ActivityInput() { Activity = a42, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai48 = new ActivityInput() { Activity = a43, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai49 = new ActivityInput() { Activity = a44, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai50 = new ActivityInput() { Activity = a45, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai51 = new ActivityInput() { Activity = a46, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai52 = new ActivityInput() { Activity = a47, Title = "Moteno/Ni moteno", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Moteno;;Ni moteno", Required = true, OneTime = false };
            ActivityInput ai53 = new ActivityInput() { Activity = a47, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai54 = new ActivityInput() { Activity = a48, Title = "Nizka/Srednja/Visoka", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Nizka;;Srednja;;Visoka", Required = true, OneTime = false };
            ActivityInput ai55 = new ActivityInput() { Activity = a48, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai56 = new ActivityInput() { Activity = a49, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai57 = new ActivityInput() { Activity = a50, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai58 = new ActivityInput() { Activity = a51, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai59 = new ActivityInput() { Activity = a52, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai60 = new ActivityInput() { Activity = a53, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai61 = new ActivityInput() { Activity = a54, Title = "g", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai62 = new ActivityInput() { Activity = a55, Title = "cm", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai63 = new ActivityInput() { Activity = a56, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai64 = new ActivityInput() { Activity = a56, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai65 = new ActivityInput() { Activity = a57, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai66 = new ActivityInput() { Activity = a57, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai67 = new ActivityInput() { Activity = a58, Title = "Ni posebnosti/Mikcija/Defekacija/Napenjanje/Kolike/Polivanje/Bruhanje", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Ni posebnosti;;Mikcija;;Defekacija;;Napenjanje;;Kolike;;Polivanje;;Bruhanje", Required = true, OneTime = false };
            ActivityInput ai68 = new ActivityInput() { Activity = a58, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai69 = new ActivityInput() { Activity = a59, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai70 = new ActivityInput() { Activity = a60, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai71 = new ActivityInput() { Activity = a61, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai72 = new ActivityInput() { Activity = a62, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai73 = new ActivityInput() { Activity = a63, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai74 = new ActivityInput() { Activity = a64, Title = "Prosti vnos ", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai75 = new ActivityInput() { Activity = a65, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai76 = new ActivityInput() { Activity = a65, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai77 = new ActivityInput() { Activity = a66, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai78 = new ActivityInput() { Activity = a67, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai79 = new ActivityInput() { Activity = a68, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai80 = new ActivityInput() { Activity = a69, Title = "kg ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai81 = new ActivityInput() { Activity = a70, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai82 = new ActivityInput() { Activity = a71, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai83 = new ActivityInput() { Activity = a72, Title = "Urin", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai84 = new ActivityInput() { Activity = a72, Title = "Blato", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai85 = new ActivityInput() { Activity = a73, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai86 = new ActivityInput() { Activity = a74, Title = "Vid", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai87 = new ActivityInput() { Activity = a74, Title = "Vonj", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai88 = new ActivityInput() { Activity = a74, Title = "Sluh", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai89 = new ActivityInput() { Activity = a74, Title = "Okus", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai90 = new ActivityInput() { Activity = a74, Title = "Otip", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai91 = new ActivityInput() { Activity = a75, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai92 = new ActivityInput() { Activity = a76, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai93 = new ActivityInput() { Activity = a77, Title = "Samostojen/Delno odvisen/Povsem odvisen", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Samostojen;;Delno odvisen;;Povsem odvisen", Required = true, OneTime = false };
            ActivityInput ai94 = new ActivityInput() { Activity = a77, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai95 = new ActivityInput() { Activity = a77, Title = "Pomoè: svojci, drugi", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai96 = new ActivityInput() { Activity = a78, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai97 = new ActivityInput() { Activity = a79, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai98 = new ActivityInput() { Activity = a80, Title = "", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai99 = new ActivityInput() { Activity = a81, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai100 = new ActivityInput() { Activity = a82, Title = "", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai101 = new ActivityInput() { Activity = a83, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai102 = new ActivityInput() { Activity = a84, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai103 = new ActivityInput() { Activity = a85, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai104 = new ActivityInput() { Activity = a85, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai105 = new ActivityInput() { Activity = a86, Title = "Udarci na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai106 = new ActivityInput() { Activity = a87, Title = "Vdihi na minuto ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai107 = new ActivityInput() { Activity = a88, Title = "st C ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai108 = new ActivityInput() { Activity = a89, Title = "mmol/L", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai109 = new ActivityInput() { Activity = a89, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai110 = new ActivityInput() { Activity = a90, Title = "% ", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai111 = new ActivityInput() { Activity = a91, Title = "Da/Delno/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Delno;;Ne", Required = true, OneTime = false };
            ActivityInput ai112 = new ActivityInput() { Activity = a91, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai113 = new ActivityInput() { Activity = a92, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai114 = new ActivityInput() { Activity = a93, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai115 = new ActivityInput() { Activity = a94, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
             
             */

            context.ActivityInputs.AddOrUpdate(y => y.ActivityInputId, ai981, ai1, ai2, ai3, ai4, ai5, ai6, ai7, ai8, ai9, ai10, ai11, ai12, ai13, ai14, ai15, ai16, ai17, ai18, ai19, ai20, ai21, ai22, ai23, ai24, ai25, ai26, ai27, ai28, ai29, ai30, ai31, ai32, ai33, ai34, ai35, ai36, ai37, ai38, ai39, ai40, ai41, ai42, ai43, ai44, ai45, ai46, ai47, ai48, ai49, ai50, ai51, ai52, ai53, ai54, ai55, ai56, ai57, ai58, ai59, ai60, ai61, ai62, ai63, ai64, ai65, ai66, ai67, ai68, ai69, ai70, ai71, ai72, ai73, ai74, ai75, ai76, ai77, ai78, ai79, ai80, ai81, ai82, ai83, ai84, ai85, ai86, ai87, ai88, ai89, ai90, ai91, ai92, ai93, ai94, ai95, ai96, ai97, ai98, ai99, ai100, ai101, ai102, ai103, ai104, ai105, ai106, ai107, ai108, ai109, ai110, ai111, ai112, ai113, ai114, ai115, ai116, ai117, ai1001, ai1002, ai1003, ai1004);

            #endregion

        }
    }
}
