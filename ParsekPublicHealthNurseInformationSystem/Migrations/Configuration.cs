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

            Role AdminRole = new Role { Title = Role.Admin, Active = true };
            Role EmployeeRole = new Role { Title = Role.Employee, Active = true };
            Role PatientRole = new Role { Title = Role.Patient, Active = true };

            context.Roles.AddOrUpdate(
                r => r.Title,
                AdminRole,
                EmployeeRole,
                PatientRole
            );

            JobTitle DoctorJobTitle = new JobTitle { Title = JobTitle.Doctor, Active = true };
            JobTitle HeadJobTitle = new JobTitle { Title = JobTitle.Head, Active = true };
            JobTitle HealthNurseJobTitle = new JobTitle { Title = JobTitle.HealthNurse, Active = true };
            JobTitle CoworkerJobTitle = new JobTitle { Title = JobTitle.Coworker, Active = true };

            context.JobTitles.AddOrUpdate(
                r => r.Title,
                DoctorJobTitle,
                HeadJobTitle,
                HealthNurseJobTitle,
                CoworkerJobTitle
            );


            // Relationships
            var rel1 = new Relationship {Name = "Starš - otrok", Active = true };
            var rel2 = new Relationship {Name = "Ožji družinski krog", Active = true };
            var rel3 = new Relationship {Name = "Širši družinski krog", Active = true };
            var rel4 = new Relationship {Name = "Ni v sorodu", Active = true };
            context.Relationships.AddOrUpdate(rel => rel.Name, rel1, rel2, rel3, rel4);

            // Diseases
            var d1 = new Disease {Code = "Z34.0", Description = "Nadzor nad normalno prvo noseènostjo", Active = true };
            var d2 = new Disease { Code = "Z34.8", Description = "Nadzor nad drugimi normalnimi noseènostmi", Active = true };
            var d3 = new Disease { Code = "Z34.9", Description = "Nadzor nad normalno noseènostjo, neopredeljen", Active = true };
            var d4 = new Disease { Code = "Z35.0", Description = "Nadzor nad noseènostjo z anamnezo infertilnosti", Active = true };
            context.Diseases.AddOrUpdate(d => d.Code, d1, d2, d3, d4);
            // TODO: ...

            // Medicine
            var m1 = new Medicine {Code = "13300", Title = "Abseamed 8.000 i.e./0,8 ml raztopina za inj", Active = true };
            var m2 = new Medicine { Code = "13692", Title = "Acidum nitricum C30 kroglice", Active = true };
            var m3 = new Medicine { Code = "02504", Title = "Acipan 40 mg prašek za raztopino za injicir", Active = true };
            var m4 = new Medicine { Code = "21550", Title = "Aconitum napellus C200 kroglice", Active = true };
            context.Medicines.AddOrUpdate(m => m.Code, m1, m2, m3, m4);
            // TODO: ...

            // Post Office
            var p1 = new PostOffice { Title = "Ajdovšèina", Number = "5270" };
            var p2 = new PostOffice { Title = "Bled", Number = "4260" }; // kremšnite
            var p3 = new PostOffice { Title = "Litija", Number = "1270" };
            var p4 = new PostOffice { Title = "Ljubljana", Number = "1000" };
            context.PostOffices.AddOrUpdate(p => p.Number, p1, p2, p3, p4);
            // TODO: ...

            // Contractors
            var c1 = new Contractor {Title = "ZDRAVSTVENI DOM AJDOVŠÈINA", Number = "00130", Address = "TOVARNIŠKA CESTA 3", PostOffice = p1, Active = true };
            var c2 = new Contractor { Title = "COR MEDICO ZAVOD", Number = "55022", Address = "KOMENSKEGA ULICA 32", PostOffice = p4, Active = true };
            var c3 = new Contractor { Title = "FIZIO CENTER PLUS D.O.O.", Number = "55021", Address = "ULICA MIRE PREGLJEVE 1", PostOffice = p3, Active = true };
            var c4 = new Contractor { Title = "DIAGNOSTIÈNI CENTER BLED D.O.O.", Number = "04970", Address = "POD SKALO 4", PostOffice = p2, Active = true };
            // TODO: ...

            // Districts
            var di1 = new District { Name = "Okoliš 1", Lat = (decimal)100.0, Lon = (decimal)100.0, Contractor = c1 };
            var di2 = new District { Name = "Okoliš 2", Lat = (decimal)200.0, Lon = (decimal)200.0, Contractor = c1 };
            var di3 = new District { Name = "Okoliš 3", Lat = (decimal)300.0, Lon = (decimal)300.0, Contractor = c1 };
            var di4 = new District { Name = "Okoliš 4", Lat = (decimal)400.0, Lon = (decimal)999.0, Contractor = c1 };
            var di5 = new District { Name = "Okoliš 5", Lat = (decimal)400.0, Lon = (decimal)999.0 };
            var di6 = new District { Name = "Okoliš 6", Lat = (decimal)400.0, Lon = (decimal)999.0 };
            var di7 = new District { Name = "Okoliš 7", Lat = (decimal)400.0, Lon = (decimal)999.0 };
            var di8 = new District { Name = "Okoliš 8", Lat = (decimal)400.0, Lon = (decimal)999.0 };

            /*di5.Contractor = c3;
            di6.Contractor = c3;

            di7.Contractor = c4;
            di8.Contractor = c4;*/

            //context.Districts.AddOrUpdate(d => d.Name, di1, di2, di3, di4, di5, di6, di7, di8);
            context.Districts.AddOrUpdate(d => d.Name, di1, di2, di3, di4);
            context.Contractors.AddOrUpdate(c => c.Number, c1, c2, c3, c4);
            // TODO: ...

            var mat1 = new Material { Title = "Epruveta", Description = "Splošno uporabna epruveta", Active = true };
            var mat2 = new Material { Title = "Injekcija", Description = "Splošno uporabna injekcija", Active = true };
            var mat3 = new Material { Title = "Radijeva sol", Description = "Za boljše poèutje", Active = true };
            var mat4 = new Material { Title = "Svinènik", Description = "Za zapisovanje", Active = true };
            context.Materials.AddOrUpdate(m => m.Title, mat1, mat2, mat3, mat4);
            // TODO: ...

            Patient patient1 = new Patient
            {
                CardNumber = "65456",
                Name = "Janežina",
                Surname = "Novak",
                Address = "Žememlje 8",
                PostOffice = p1,
                District = di1,
                PhoneNumber = "1234566666",
                Gender = Models.Patient.GenderEnum.Female,
                BirthDate = DateTime.Now.AddYears(-30),
            };
            Patient patient2 = new Patient
            {
                CardNumber = "99878",
                Name = "Francelj",
                Surname = "Horvat",
                Address = "Partizanska 99",
                PostOffice = p2,
                District = di2,
                PhoneNumber = "090999999",
                Gender = Models.Patient.GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-50)
            };
            Patient patient3 = new Patient
            {
                CardNumber = "78879",
                Name = "Joža",
                Surname = "Boža",
                Address = "Domobranska 11",
                PostOffice = p3,
                District = di1,
                PhoneNumber = "090888880",
                Gender = Models.Patient.GenderEnum.Female,
                BirthDate = DateTime.Now.AddYears(-40)
            };
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1, patient2, patient3);
            Patient patient1_1 = new Patient
            {
                CardNumber = "88888",
                Name = "Sif",
                Surname = "Novak",
                Address = "Žememlje 8",
                PostOffice = p1,
                District = di1,
                PhoneNumber = "090888880",
                Gender = Patient.GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-50),
                ParentPatient = patient1,
                ParentPatientRelationship = rel1
            };
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1_1);

            User Admin = new User
            {
                Employee = null,
                Patient = null,
                Role = AdminRole,
                Email = "admin@parsek.si",
                Password = "admin",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
            User Doctor = new User
            {
                Employee = null,
                Patient = null,
                Role = EmployeeRole,
                Email = "doctor@parsek.si",
                Password = "doctor",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
            User Nurse1 = new User
            {
                Employee = null,
                Patient = null,
                Role = EmployeeRole,
                Email = "nurse1@parsek.si",
                Password = "nurse1",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
            User Nurse2 = new User
            {
                Employee = null,
                Patient = null,
                Role = EmployeeRole,
                Email = "nurse2@parsek.si",
                Password = "nurse2",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
            User Nurse3 = new User
            {
                Employee = null,
                Patient = null,
                Role = EmployeeRole,
                Email = "nurse3@parsek.si",
                Password = "nurse3",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
            User Nurse4 = new User
            {
                Employee = null,
                Patient = null,
                Role = EmployeeRole,
                Email = "nurse4@parsek.si",
                Password = "nurse4",
                Active = true,
                LastLastLogin = DateTime.Now,
                LastLogin = DateTime.Now,
                Deleted = false
            };
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
            Patient1.Deleted = false;
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
            Patient2.Deleted = false;
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
            Patient3.Deleted = false;
            User Head = new User();
            Head.Employee = null;
            Head.Patient = null;
            Head.Role = EmployeeRole;
            Head.Email = "head@parsek.si";
            Head.Password = "head";
            Head.Active = true;
            Head.LastLastLogin = DateTime.Now;
            Head.LastLogin = DateTime.Now;
            Head.Deleted = false;
            context.Users.AddOrUpdate(a => a.Email, Admin, Doctor, Nurse1, Nurse2, Nurse3, Nurse4, Patient1, Patient2, Patient3, Head);


            Employee DoctorEmployee = new Employee();
            DoctorEmployee.User = Doctor;
            DoctorEmployee.Name = "Doctory";
            DoctorEmployee.Surname = "Doktorsky";
            DoctorEmployee.Contractor = c1;
            DoctorEmployee.Number = "78989";
            DoctorEmployee.PhoneNumber = "081579856";
            DoctorEmployee.JobTitle = DoctorJobTitle;
            Employee HeadEmployee = new Employee();
            HeadEmployee.User = Head;
            HeadEmployee.Name = "Head";
            HeadEmployee.Surname = "Headovsky";
            HeadEmployee.Contractor = c1;
            HeadEmployee.Number = "89795";
            HeadEmployee.PhoneNumber = "055555666";
            HeadEmployee.JobTitle = HeadJobTitle;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee, HeadEmployee);

            Employee NurseEmployee1 = new Employee();
            NurseEmployee1.User = Nurse1;
            NurseEmployee1.Name = "Nurse";
            NurseEmployee1.Surname = "Nursy";
            NurseEmployee1.Contractor = c1;
            NurseEmployee1.District = di1;
            NurseEmployee1.Number = "44646";
            NurseEmployee1.PhoneNumber = "222333444";
            NurseEmployee1.JobTitle = HealthNurseJobTitle;
            Employee NurseEmployee2 = new Employee();
            NurseEmployee2.User = Nurse2;
            NurseEmployee2.Name = "Katarina";
            NurseEmployee2.Surname = "Morales";
            NurseEmployee2.Contractor = c1;
            NurseEmployee2.District = di2;
            NurseEmployee2.Number = "78797";
            NurseEmployee2.PhoneNumber = "888777654";
            NurseEmployee2.JobTitle = HealthNurseJobTitle;
            Employee NurseEmployee3 = new Employee();
            NurseEmployee3.User = Nurse3;
            NurseEmployee3.Name = "Anri";
            NurseEmployee3.Surname = "Astora";
            NurseEmployee3.Contractor = c1;
            NurseEmployee3.District = di3;
            NurseEmployee3.Number = "99999";
            NurseEmployee3.PhoneNumber = "035897546";
            NurseEmployee3.JobTitle = HealthNurseJobTitle;
            Employee NurseEmployee4 = new Employee();
            NurseEmployee4.User = Nurse4;
            NurseEmployee4.Name = "Elizabeta";
            NurseEmployee4.Surname = "Magdalena";
            NurseEmployee4.Contractor = c1;
            NurseEmployee4.District = di4;
            NurseEmployee4.Number = "45455";
            NurseEmployee4.PhoneNumber = "666444777";
            NurseEmployee4.JobTitle = HealthNurseJobTitle;
            context.Employees.AddOrUpdate(a => a.Number, DoctorEmployee, NurseEmployee1, NurseEmployee2, NurseEmployee3, NurseEmployee4);

            Service ac1 = new Service
            {
                ServiceCode = "10",
                ServiceTitle = "Obisk noseènice",
                PreventiveVisit = true,
                RequiresMedicine = false,
                RequiresBloodSample = false,
                RequiresPatients = false,
                Active = true
            };
            //ac1.ServiceCode = "10";
            //ac1.ServiceTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu.";
            //ac1.Report = "Prosti vnos";
            /*
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
*/
            Service ac2 = new Service
            {
                ServiceCode = "20",
                ServiceTitle = "Obisk otroènice in novorojenèka",
                PreventiveVisit = true,
                RequiresMedicine = false,
                RequiresBloodSample = false,
                RequiresPatients = true,
                Active = true
            };

            Service ac4 = new Service
            {
                ServiceCode = "40",
                ServiceTitle = "Obisk starostnika",
                PreventiveVisit = true,
                RequiresMedicine = false,
                RequiresBloodSample = false,
                RequiresPatients = false,
                Active = true
            };
            // Was in requirements!
            Service ac5 = new Service
            {
                ServiceCode = "50",
                ServiceTitle = "Aplikacija injekcij",
                PreventiveVisit = false,
                RequiresMedicine = true,
                RequiresBloodSample = false,
                RequiresPatients = false,
                Active = true
            };
            //ac5.ServiceCode = "10";
            //ac5.ServiceTitle = "Aplikacija injekcije";
            //ac5.Report = "";
            Service ac6 = new Service
            {
                ServiceCode = "60",
                ServiceTitle = "Odvzem krvi",
                PreventiveVisit = false,
                RequiresMedicine = false,
                RequiresBloodSample = true,
                RequiresPatients = false,
                Active = true
            };
            //ac6.ServiceCode = "10";
            //ac6.ServiceTitle = "Odvzem krvi";
            //ac6.Report = "";
            Service ac7 = new Service
            {
                ServiceCode = "70",
                ServiceTitle = "Kontrola zdravstvenega stanja",
                PreventiveVisit = false,
                RequiresMedicine = false,
                RequiresBloodSample = false,
                RequiresPatients = false,
                Active = true
            };
            //ac7.ServiceCode = "20";
            //ac7.ServiceTitle = "Krvni pritisk: sistolièni, diastolièni";
            //ac7.Report = "Sistolièni (mm Hg) * Diastolièni(mm Hg) *";

            context.Services.AddOrUpdate(y => y.ServiceId, ac1, ac2, /*ac3,*/ ac4, ac5, ac6, ac7);



            #region Activities

            #region Activity
            Activity a1 = new Activity() { ActivityCode = 10, Active = true, ActivityTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu." };
            Activity a2 = new Activity() { ActivityCode = 20, Active = true, ActivityTitle = "Povabilo v šolo za starše." };
            Activity a3 = new Activity() { ActivityCode = 30, Active = true, ActivityTitle = "Seznanitev o rednih ginekoloških pregledih." };
            Activity a4 = new Activity() { ActivityCode = 40, Active = true, ActivityTitle = "Seznanitev z bližajoèim se porodom in pravoèasnim odhodom v porodnišnico. " };
            Activity a5 = new Activity() { ActivityCode = 50, Active = true, ActivityTitle = "Pogovor in vkljuèevanje partnerja v noseènost in porod ter po prihodu domov. " };
            Activity a6 = new Activity() { ActivityCode = 60, Active = true, ActivityTitle = "Svetovanje o pripomoèkih, ki jih bo potrebovala v porodnišnici. " };
            Activity a7 = new Activity() { ActivityCode = 70, Active = true, ActivityTitle = "Seznanitev noseènice o štetju in beleženju plodovih gibov. " };
            Activity a8 = new Activity() { ActivityCode = 80, Active = true, ActivityTitle = "Svetovanje glede opreme za novorojenca in primerno ležišèe. " };
            Activity a9 = new Activity() { ActivityCode = 90, Active = true, ActivityTitle = "Svetovanje o pravilni prehrani, ustrezni izbiri obleke in obutve." };
            Activity a10 = new Activity() { ActivityCode = 100, Active = true, ActivityTitle = "Svetovanje o primernem režim življenja, telesne vaje, gibanje na svežem zraku." };
            Activity a11 = new Activity() { ActivityCode = 110, Active = true, ActivityTitle = "Odsvetovanje razvad kot so uživanje alkohola, kajenje, uživanje zdravil in drog. " };
            Activity a12 = new Activity() { ActivityCode = 120, Active = true, ActivityTitle = "Seznanitev nosoènice z nevšeènostmi in svetovanje glede lajšanja težav zaradi nevšeènosti (slabosti, bruhanja, zaprtja, pogostih mikcij, nespeènosti, zgage, ...)." };
            Activity a13 = new Activity() { ActivityCode = 130, Active = true, ActivityTitle = "Seznanitev noseènice s pravicami do starševskega dopusta (porodniški dopust, pravica do dopusta za nego in varstvo otroka, pravica do oèetovskega dopusta) in o uveljavljanju pravic povezanih z rojstvom otroka (pravica do paketa, otroški dodatek, zdravstveno zavarovanje, rojstni list, ureditev oèetovstva)." };
            Activity a14 = new Activity() { ActivityCode = 140, Active = true, ActivityTitle = "Prièakovan datum poroda" };
            Activity a15 = new Activity() { ActivityCode = 150, Active = true, ActivityTitle = "Anamneza: poèutje, telesni znaki noseènosti." };
            Activity a16 = new Activity() { ActivityCode = 160, Active = true, ActivityTitle = "Družinska anamneza: Odnosi v družini, odnos družine do okolja, bivalni pogoji, ekonomske razmere, zdravstveno stanje družinskih èlanov, zdravstvena prosvetljenost in vzgojenost." };
            Activity a17 = new Activity() { ActivityCode = 170, Active = true, ActivityTitle = "Izražanje èustev" };
            Activity a18 = new Activity() { ActivityCode = 180, Active = true, ActivityTitle = "Fizièna obremenjenost" };
            Activity a19 = new Activity() { ActivityCode = 190, Active = true, ActivityTitle = "Krvni pritisk: sistolièni, diastolièni" };
            Activity a20 = new Activity() { ActivityCode = 200, Active = true, ActivityTitle = "Srèni utrip" };
            Activity a21 = new Activity() { ActivityCode = 210, Active = true, ActivityTitle = "Dihanje" };
            Activity a22 = new Activity() { ActivityCode = 220, Active = true, ActivityTitle = "Telesna temperatura" };
            Activity a23 = new Activity() { ActivityCode = 230, Active = true, ActivityTitle = "Telesna teža pred noseènostjo" };
            Activity a24 = new Activity() { ActivityCode = 240, Active = true, ActivityTitle = "Trenutna telesna teža" };
            Activity a25 = new Activity() { ActivityCode = 250, Active = true, ActivityTitle = "Pregled materinske knjižice in odpustnice iz porodnišnice. " };
            Activity a26 = new Activity() { ActivityCode = 260, Active = true, ActivityTitle = "Kontrola vitalnih funkcij." };
            Activity a27 = new Activity() { ActivityCode = 270, Active = true, ActivityTitle = "Opazovanje èišèe. " };
            Activity a28 = new Activity() { ActivityCode = 280, Active = true, ActivityTitle = "Nadzor nad izloèanjem blata in urina. " };
            Activity a29 = new Activity() { ActivityCode = 290, Active = true, ActivityTitle = "Zdravstveno vzgojno delo glede pravilnega rokovanja z novorojenèkom, uèenje tehnike nege novorojenèka" };
            Activity a30 = new Activity() { ActivityCode = 300, Active = true, ActivityTitle = "Motivacija za dojenje. Nadzor in pomoè pri dojenju. " };
            Activity a31 = new Activity() { ActivityCode = 310, Active = true, ActivityTitle = "Svetovanje o èustveni podpori s strani partnerja." };
            Activity a32 = new Activity() { ActivityCode = 320, Active = true, ActivityTitle = "Seznanitev o otrokovih potrebah po toplini, nežnosti in varnosti." };
            Activity a33 = new Activity() { ActivityCode = 330, Active = true, ActivityTitle = "Svetovanje o spalnih potrebah otroènice, pravilni negi in higienskem režimu v poporodnem obdobju. " };
            Activity a34 = new Activity() { ActivityCode = 340, Active = true, ActivityTitle = "Svetovanje o pravilni prehrani, pitju ustreznih kolièin tekoèin" };
            Activity a35 = new Activity() { ActivityCode = 350, Active = true, ActivityTitle = "Pouèitev o poporodni telovadbi." };
            Activity a36 = new Activity() { ActivityCode = 360, Active = true, ActivityTitle = "Sezananitev z nekaterimi obolenji." };
            Activity a37 = new Activity() { ActivityCode = 370, Active = true, ActivityTitle = "Napotitev na poporodni pregled." };
            Activity a38 = new Activity() { ActivityCode = 380, Active = true, ActivityTitle = "Seznanitev z metodami zašèite pred nezaželjno noseènostjo." };
            Activity a39 = new Activity() { ActivityCode = 390, Active = true, ActivityTitle = "Svetovanje o normalnem delu, življenju in spolnih odnosih. " };
            Activity a40 = new Activity() { ActivityCode = 400, Active = true, ActivityTitle = "Krvni pritisk otroènice" };
            Activity a41 = new Activity() { ActivityCode = 410, Active = true, ActivityTitle = "Prikaz nege dojenèka" };
            Activity a42 = new Activity() { ActivityCode = 420, Active = true, ActivityTitle = "Nega popokovne rane" };
            Activity a43 = new Activity() { ActivityCode = 430, Active = true, ActivityTitle = "Nudenje pomoèi pri dojenju in seznanitev s tehnikami dojenja." };
            Activity a44 = new Activity() { ActivityCode = 440, Active = true, ActivityTitle = "Ureditev ležišèa." };
            Activity a45 = new Activity() { ActivityCode = 450, Active = true, ActivityTitle = "Svetovanje o povijanju, oblaèenju, slaèenju" };
            Activity a46 = new Activity() { ActivityCode = 460, Active = true, ActivityTitle = "Trenutna telesna višina" };
            Activity a47 = new Activity() { ActivityCode = 470, Active = true, ActivityTitle = "Dojenje" };
            Activity a48 = new Activity() { ActivityCode = 480, Active = true, ActivityTitle = "Dodajanje adaptiranega mleka" };
            Activity a49 = new Activity() { ActivityCode = 490, Active = true, ActivityTitle = "Izloèanje in odvajanje" };
            Activity a50 = new Activity() { ActivityCode = 500, Active = true, ActivityTitle = "Ritem spanja" };
            Activity a51 = new Activity() { ActivityCode = 510, Active = true, ActivityTitle = "Povišanje bilirubina (zlatenica)" };
            Activity a52 = new Activity() { ActivityCode = 520, Active = true, ActivityTitle = "Kolki" };
            Activity a53 = new Activity() { ActivityCode = 530, Active = true, ActivityTitle = "Posebnosti" };
            Activity a54 = new Activity() { ActivityCode = 540, Active = true, ActivityTitle = "Anamneza" };
            Activity a55 = new Activity() { ActivityCode = 550, Active = true, ActivityTitle = "Družinska anamneza" };
            Activity a56 = new Activity() { ActivityCode = 560, Active = true, ActivityTitle = "Telesna teža" };
            Activity a57 = new Activity() { ActivityCode = 570, Active = true, ActivityTitle = "Osebna higiena" };
            Activity a58 = new Activity() { ActivityCode = 580, Active = true, ActivityTitle = "Prehranjevanje in pitje" };
            Activity a59 = new Activity() { ActivityCode = 590, Active = true, ActivityTitle = "Gibanje" };
            Activity a60 = new Activity() { ActivityCode = 600, Active = true, ActivityTitle = "Èutila in obèutki" };
            Activity a61 = new Activity() { ActivityCode = 610, Active = true, ActivityTitle = "Spanje in poèitek" };
            Activity a62 = new Activity() { ActivityCode = 620, Active = true, ActivityTitle = "Duševno stanje: izražanje èustev in potreb, komunikacija" };
            Activity a63 = new Activity() { ActivityCode = 630, Active = true, ActivityTitle = "Stanje neodvisnosti" };
            Activity a64 = new Activity() { ActivityCode = 640, Active = true, ActivityTitle = "Pregled predpisanih terapij" };
            Activity a65 = new Activity() { ActivityCode = 650, Active = true, ActivityTitle = "Pogovor, nasvet in vzpodbuda." };
            Activity a66 = new Activity() { ActivityCode = 660, Active = true, ActivityTitle = "Aplikacija injekcije" };
            Activity a67 = new Activity() { ActivityCode = 670, Active = true, ActivityTitle = "Odvzem krvi" };
            Activity a68 = new Activity() { ActivityCode = 680, Active = true, ActivityTitle = "Krvni sladkor" };
            Activity a69 = new Activity() { ActivityCode = 690, Active = true, ActivityTitle = "Oksigenacija SpO2" };
            Activity a70 = new Activity() { ActivityCode = 700, Active = true, ActivityTitle = "Upoštevanje terapije" };
            Activity a71 = new Activity() { ActivityCode = 710, Active = true, ActivityTitle = "Pregled terapije" };
            Activity a72 = new Activity() { ActivityCode = 720, Active = true, ActivityTitle = "Navodila za terapijo do naslednjega obiska" };
            #endregion

            #region ServiceActivity
            ServiceActivity sa1 = new ServiceActivity() { Activity = a1, Service = ac1, Active = true };
            ServiceActivity sa2 = new ServiceActivity() { Activity = a2, Service = ac1, Active = true };
            ServiceActivity sa3 = new ServiceActivity() { Activity = a3, Service = ac1, Active = true };
            ServiceActivity sa4 = new ServiceActivity() { Activity = a4, Service = ac1, Active = true };
            ServiceActivity sa5 = new ServiceActivity() { Activity = a5, Service = ac1, Active = true };
            ServiceActivity sa6 = new ServiceActivity() { Activity = a6, Service = ac1, Active = true };
            ServiceActivity sa7 = new ServiceActivity() { Activity = a7, Service = ac1, Active = true };
            ServiceActivity sa8 = new ServiceActivity() { Activity = a8, Service = ac1, Active = true };
            ServiceActivity sa9 = new ServiceActivity() { Activity = a9, Service = ac1, Active = true };
            ServiceActivity sa10 = new ServiceActivity() { Activity = a10, Service = ac1, Active = true };
            ServiceActivity sa11 = new ServiceActivity() { Activity = a11, Service = ac1, Active = true };
            ServiceActivity sa12 = new ServiceActivity() { Activity = a12, Service = ac1, Active = true };
            ServiceActivity sa13 = new ServiceActivity() { Activity = a13, Service = ac1, Active = true };
            ServiceActivity sa14 = new ServiceActivity() { Activity = a14, Service = ac1, Active = true };
            ServiceActivity sa15 = new ServiceActivity() { Activity = a15, Service = ac1, Active = true };
            ServiceActivity sa16 = new ServiceActivity() { Activity = a16, Service = ac1, Active = true };
            ServiceActivity sa17 = new ServiceActivity() { Activity = a17, Service = ac1, Active = true };
            ServiceActivity sa18 = new ServiceActivity() { Activity = a18, Service = ac1, Active = true };
            ServiceActivity sa19 = new ServiceActivity() { Activity = a19, Service = ac1, Active = true };
            ServiceActivity sa20 = new ServiceActivity() { Activity = a20, Service = ac1, Active = true };
            ServiceActivity sa21 = new ServiceActivity() { Activity = a21, Service = ac1, Active = true };
            ServiceActivity sa22 = new ServiceActivity() { Activity = a22, Service = ac1, Active = true };
            ServiceActivity sa23 = new ServiceActivity() { Activity = a23, Service = ac1, Active = true };
            ServiceActivity sa24 = new ServiceActivity() { Activity = a24, Service = ac1, Active = true };
            ServiceActivity sa25 = new ServiceActivity() { Activity = a15, Service = ac2, Active = true };
            ServiceActivity sa26 = new ServiceActivity() { Activity = a16, Service = ac2, Active = true };
            ServiceActivity sa27 = new ServiceActivity() { Activity = a17, Service = ac2, Active = true };
            ServiceActivity sa28 = new ServiceActivity() { Activity = a18, Service = ac2, Active = true };
            ServiceActivity sa29 = new ServiceActivity() { Activity = a20, Service = ac2, Active = true };
            ServiceActivity sa30 = new ServiceActivity() { Activity = a21, Service = ac2, Active = true };
            ServiceActivity sa31 = new ServiceActivity() { Activity = a22, Service = ac2, Active = true };
            ServiceActivity sa32 = new ServiceActivity() { Activity = a24, Service = ac2, Active = true };
            ServiceActivity sa33 = new ServiceActivity() { Activity = a25, Service = ac2, Active = true };
            ServiceActivity sa34 = new ServiceActivity() { Activity = a26, Service = ac2, Active = true };
            ServiceActivity sa35 = new ServiceActivity() { Activity = a27, Service = ac2, Active = true };
            ServiceActivity sa36 = new ServiceActivity() { Activity = a28, Service = ac2, Active = true };
            ServiceActivity sa37 = new ServiceActivity() { Activity = a29, Service = ac2, Active = true };
            ServiceActivity sa38 = new ServiceActivity() { Activity = a30, Service = ac2, Active = true };
            ServiceActivity sa39 = new ServiceActivity() { Activity = a31, Service = ac2, Active = true };
            ServiceActivity sa40 = new ServiceActivity() { Activity = a32, Service = ac2, Active = true };
            ServiceActivity sa41 = new ServiceActivity() { Activity = a33, Service = ac2, Active = true };
            ServiceActivity sa42 = new ServiceActivity() { Activity = a34, Service = ac2, Active = true };
            ServiceActivity sa43 = new ServiceActivity() { Activity = a35, Service = ac2, Active = true };
            ServiceActivity sa44 = new ServiceActivity() { Activity = a36, Service = ac2, Active = true };
            ServiceActivity sa45 = new ServiceActivity() { Activity = a37, Service = ac2, Active = true };
            ServiceActivity sa46 = new ServiceActivity() { Activity = a38, Service = ac2, Active = true };
            ServiceActivity sa47 = new ServiceActivity() { Activity = a39, Service = ac2, Active = true };
            ServiceActivity sa48 = new ServiceActivity() { Activity = a40, Service = ac2, Active = true };
            ServiceActivity sa49 = new ServiceActivity() { Activity = a41, Service = ac2, Active = true };
            ServiceActivity sa50 = new ServiceActivity() { Activity = a42, Service = ac2, Active = true };
            ServiceActivity sa51 = new ServiceActivity() { Activity = a43, Service = ac2, Active = true };
            ServiceActivity sa52 = new ServiceActivity() { Activity = a44, Service = ac2, Active = true };
            ServiceActivity sa53 = new ServiceActivity() { Activity = a45, Service = ac2, Active = true };
            ServiceActivity sa54 = new ServiceActivity() { Activity = a46, Service = ac2, Active = true };
            ServiceActivity sa55 = new ServiceActivity() { Activity = a47, Service = ac2, Active = true };
            ServiceActivity sa56 = new ServiceActivity() { Activity = a48, Service = ac2, Active = true };
            ServiceActivity sa57 = new ServiceActivity() { Activity = a49, Service = ac2, Active = true };
            ServiceActivity sa58 = new ServiceActivity() { Activity = a50, Service = ac2, Active = true };
            ServiceActivity sa59 = new ServiceActivity() { Activity = a51, Service = ac2, Active = true };
            ServiceActivity sa60 = new ServiceActivity() { Activity = a52, Service = ac2, Active = true };
            ServiceActivity sa61 = new ServiceActivity() { Activity = a53, Service = ac2, Active = true };
            ServiceActivity sa62 = new ServiceActivity() { Activity = a19, Service = ac4, Active = true };
            ServiceActivity sa63 = new ServiceActivity() { Activity = a20, Service = ac4, Active = true };
            ServiceActivity sa64 = new ServiceActivity() { Activity = a21, Service = ac4, Active = true };
            ServiceActivity sa65 = new ServiceActivity() { Activity = a22, Service = ac4, Active = true };
            ServiceActivity sa66 = new ServiceActivity() { Activity = a49, Service = ac4, Active = true };
            ServiceActivity sa67 = new ServiceActivity() { Activity = a54, Service = ac4, Active = true };
            ServiceActivity sa68 = new ServiceActivity() { Activity = a55, Service = ac4, Active = true };
            ServiceActivity sa69 = new ServiceActivity() { Activity = a56, Service = ac4, Active = true };
            ServiceActivity sa70 = new ServiceActivity() { Activity = a57, Service = ac4, Active = true };
            ServiceActivity sa71 = new ServiceActivity() { Activity = a58, Service = ac4, Active = true };
            ServiceActivity sa72 = new ServiceActivity() { Activity = a59, Service = ac4, Active = true };
            ServiceActivity sa73 = new ServiceActivity() { Activity = a60, Service = ac4, Active = true };
            ServiceActivity sa74 = new ServiceActivity() { Activity = a61, Service = ac4, Active = true };
            ServiceActivity sa75 = new ServiceActivity() { Activity = a62, Service = ac4, Active = true };
            ServiceActivity sa76 = new ServiceActivity() { Activity = a63, Service = ac4, Active = true };
            ServiceActivity sa77 = new ServiceActivity() { Activity = a64, Service = ac4, Active = true };
            ServiceActivity sa78 = new ServiceActivity() { Activity = a65, Service = ac4, Active = true };
            ServiceActivity sa79 = new ServiceActivity() { Activity = a65, Service = ac5, Active = true };
            ServiceActivity sa80 = new ServiceActivity() { Activity = a66, Service = ac5, Active = true };
            ServiceActivity sa81 = new ServiceActivity() { Activity = a65, Service = ac6, Active = true };
            ServiceActivity sa82 = new ServiceActivity() { Activity = a67, Service = ac6, Active = true };
            ServiceActivity sa83 = new ServiceActivity() { Activity = a19, Service = ac7, Active = true };
            ServiceActivity sa84 = new ServiceActivity() { Activity = a20, Service = ac7, Active = true };
            ServiceActivity sa85 = new ServiceActivity() { Activity = a21, Service = ac7, Active = true };
            ServiceActivity sa86 = new ServiceActivity() { Activity = a22, Service = ac7, Active = true };
            ServiceActivity sa87 = new ServiceActivity() { Activity = a54, Service = ac7, Active = true };
            ServiceActivity sa88 = new ServiceActivity() { Activity = a65, Service = ac7, Active = true };
            ServiceActivity sa89 = new ServiceActivity() { Activity = a68, Service = ac7, Active = true };
            ServiceActivity sa90 = new ServiceActivity() { Activity = a69, Service = ac7, Active = true };
            ServiceActivity sa91 = new ServiceActivity() { Activity = a70, Service = ac7, Active = true };
            ServiceActivity sa92 = new ServiceActivity() { Activity = a71, Service = ac7, Active = true };
            ServiceActivity sa93 = new ServiceActivity() { Activity = a72, Service = ac7, Active = true };
            #endregion

            #region ActivityInput
            ActivityInput ai1 = new ActivityInput() { Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = ""};
            ActivityInput ai2 = new ActivityInput() { Title = "Datum ", InputType = ActivityInput.InputTypeEnum.Date, Active = true, PossibleValues = "" };
            ActivityInput ai3 = new ActivityInput() { Title = "Moteno/Ni moteno ", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Moteno;;Ni moteno" };
            ActivityInput ai4 = new ActivityInput() { Title = "Nizka/Srednja/Visoka", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Nizka;;Srednja;;Visoka" };
            ActivityInput ai5 = new ActivityInput() { Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "100;;300" };
            ActivityInput ai6 = new ActivityInput() { Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "100;;300" };
            ActivityInput ai7 = new ActivityInput() { Title = "Udarci na minuto", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "30;;150" };
            ActivityInput ai8 = new ActivityInput() { Title = "Vdihi na minuto", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "10;;150" };
            ActivityInput ai9 = new ActivityInput() { Title = "st C", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "30;;45" };
            ActivityInput ai10 = new ActivityInput() { Title = "kg", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "20;;500" };
            ActivityInput ai11 = new ActivityInput() { Title = "Datum rojstva otroka", InputType = ActivityInput.InputTypeEnum.Date, Active = true, PossibleValues = "" };
            ActivityInput ai12 = new ActivityInput() { Title = "Porodna teža otroka (g)", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "100;;20000" };
            ActivityInput ai13 = new ActivityInput() { Title = "Porodna višina otroka (cm)", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "20;;100" };
            ActivityInput ai14 = new ActivityInput() { Title = "cm", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "20;;300" };
            ActivityInput ai15 = new ActivityInput() { Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Da;;Ne" };
            ActivityInput ai16 = new ActivityInput() { Title = "Prebava", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Ni posebnosti;;Mikcija;;Defekacija;;Napenjanje;;Kolike;;Polivanje;;Bruhanje" };
            ActivityInput ai17 = new ActivityInput() { Title = "Urin", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai18 = new ActivityInput() { Title = "Blato", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai19 = new ActivityInput() { Title = "Vid", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai20 = new ActivityInput() { Title = "Vonj", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai21 = new ActivityInput() { Title = "Sluh", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai22 = new ActivityInput() { Title = "Okus", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai23 = new ActivityInput() { Title = "Otip", InputType = ActivityInput.InputTypeEnum.Free, Active = true, PossibleValues = "" };
            ActivityInput ai24 = new ActivityInput() { Title = "Št. rdeèih epruvet", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;10" };
            ActivityInput ai25 = new ActivityInput() { Title = "Št. modrih epruvet", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;10" };
            ActivityInput ai26 = new ActivityInput() { Title = "Št. rumenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;10" };
            ActivityInput ai27 = new ActivityInput() { Title = "Št. zelenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;10" };
            ActivityInput ai28 = new ActivityInput() { Title = "mmol/L", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;100" };
            ActivityInput ai29 = new ActivityInput() { Title = "%", InputType = ActivityInput.InputTypeEnum.Number, Active = true, PossibleValues = "0;;100" };
            ActivityInput ai30 = new ActivityInput() { Title = "Da/Delno/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Da;;Delno;;Ne" };
            ActivityInput ai31 = new ActivityInput() { Title = "Neodvisnost", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Samostojen;;Delno odvisen;;Povsem odvisen" };
            ActivityInput ai32 = new ActivityInput() { Title = "Pomoè", InputType = ActivityInput.InputTypeEnum.Dropdown, Active = true, PossibleValues = "Svojci;;Drugi" };
            #endregion

            #region ActivityActivityInput
            ActivityActivityInput aai1 = new ActivityActivityInput() { Activity = a1, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai2 = new ActivityActivityInput() { Activity = a2, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai3 = new ActivityActivityInput() { Activity = a3, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai4 = new ActivityActivityInput() { Activity = a4, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai5 = new ActivityActivityInput() { Activity = a5, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai6 = new ActivityActivityInput() { Activity = a6, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai7 = new ActivityActivityInput() { Activity = a7, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai8 = new ActivityActivityInput() { Activity = a8, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai9 = new ActivityActivityInput() { Activity = a9, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai10 = new ActivityActivityInput() { Activity = a10, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai11 = new ActivityActivityInput() { Activity = a11, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai12 = new ActivityActivityInput() { Activity = a12, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai13 = new ActivityActivityInput() { Activity = a13, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai14 = new ActivityActivityInput() { Activity = a14, ActivityInput = ai2, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai15 = new ActivityActivityInput() { Activity = a15, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai16 = new ActivityActivityInput() { Activity = a16, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai17 = new ActivityActivityInput() { Activity = a17, ActivityInput = ai3, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai18 = new ActivityActivityInput() { Activity = a17, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai19 = new ActivityActivityInput() { Activity = a18, ActivityInput = ai4, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai20 = new ActivityActivityInput() { Activity = a18, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai21 = new ActivityActivityInput() { Activity = a19, ActivityInput = ai5, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai22 = new ActivityActivityInput() { Activity = a19, ActivityInput = ai6, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai23 = new ActivityActivityInput() { Activity = a20, ActivityInput = ai7, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai24 = new ActivityActivityInput() { Activity = a21, ActivityInput = ai8, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai25 = new ActivityActivityInput() { Activity = a22, ActivityInput = ai9, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai26 = new ActivityActivityInput() { Activity = a23, ActivityInput = ai10, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai27 = new ActivityActivityInput() { Activity = a24, ActivityInput = ai10, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai28 = new ActivityActivityInput() { Activity = a25, ActivityInput = ai11, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai29 = new ActivityActivityInput() { Activity = a25, ActivityInput = ai12, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai30 = new ActivityActivityInput() { Activity = a25, ActivityInput = ai13, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai31 = new ActivityActivityInput() { Activity = a25, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai32 = new ActivityActivityInput() { Activity = a26, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai33 = new ActivityActivityInput() { Activity = a27, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai34 = new ActivityActivityInput() { Activity = a28, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai35 = new ActivityActivityInput() { Activity = a29, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai36 = new ActivityActivityInput() { Activity = a30, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai37 = new ActivityActivityInput() { Activity = a31, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai38 = new ActivityActivityInput() { Activity = a32, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai39 = new ActivityActivityInput() { Activity = a33, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai40 = new ActivityActivityInput() { Activity = a34, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai41 = new ActivityActivityInput() { Activity = a35, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai42 = new ActivityActivityInput() { Activity = a36, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai43 = new ActivityActivityInput() { Activity = a37, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai44 = new ActivityActivityInput() { Activity = a38, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai45 = new ActivityActivityInput() { Activity = a39, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai46 = new ActivityActivityInput() { Activity = a40, ActivityInput = ai5, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai47 = new ActivityActivityInput() { Activity = a40, ActivityInput = ai6, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.ParentOnly };
            ActivityActivityInput aai48 = new ActivityActivityInput() { Activity = a41, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai49 = new ActivityActivityInput() { Activity = a42, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai50 = new ActivityActivityInput() { Activity = a43, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai51 = new ActivityActivityInput() { Activity = a44, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai52 = new ActivityActivityInput() { Activity = a45, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai53 = new ActivityActivityInput() { Activity = a46, ActivityInput = ai14, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai54 = new ActivityActivityInput() { Activity = a47, ActivityInput = ai15, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai55 = new ActivityActivityInput() { Activity = a47, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai56 = new ActivityActivityInput() { Activity = a48, ActivityInput = ai15, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai57 = new ActivityActivityInput() { Activity = a48, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai58 = new ActivityActivityInput() { Activity = a49, ActivityInput = ai16, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai59 = new ActivityActivityInput() { Activity = a49, ActivityInput = ai17, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai60 = new ActivityActivityInput() { Activity = a49, ActivityInput = ai18, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai61 = new ActivityActivityInput() { Activity = a49, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai62 = new ActivityActivityInput() { Activity = a50, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai63 = new ActivityActivityInput() { Activity = a51, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai64 = new ActivityActivityInput() { Activity = a52, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai65 = new ActivityActivityInput() { Activity = a53, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.PatientOnly };
            ActivityActivityInput aai66 = new ActivityActivityInput() { Activity = a54, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai67 = new ActivityActivityInput() { Activity = a55, ActivityInput = ai1, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai68 = new ActivityActivityInput() { Activity = a56, ActivityInput = ai10, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai69 = new ActivityActivityInput() { Activity = a57, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai70 = new ActivityActivityInput() { Activity = a58, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai71 = new ActivityActivityInput() { Activity = a59, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai72 = new ActivityActivityInput() { Activity = a60, ActivityInput = ai19, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai73 = new ActivityActivityInput() { Activity = a60, ActivityInput = ai20, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai74 = new ActivityActivityInput() { Activity = a60, ActivityInput = ai21, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai75 = new ActivityActivityInput() { Activity = a60, ActivityInput = ai22, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai76 = new ActivityActivityInput() { Activity = a60, ActivityInput = ai23, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai77 = new ActivityActivityInput() { Activity = a61, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai78 = new ActivityActivityInput() { Activity = a62, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai79 = new ActivityActivityInput() { Activity = a63, ActivityInput = ai31, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai80 = new ActivityActivityInput() { Activity = a63, ActivityInput = ai32, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai81 = new ActivityActivityInput() { Activity = a63, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai82 = new ActivityActivityInput() { Activity = a64, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai83 = new ActivityActivityInput() { Activity = a65, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai84 = new ActivityActivityInput() { Activity = a66, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai85 = new ActivityActivityInput() { Activity = a67, ActivityInput = ai24, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai86 = new ActivityActivityInput() { Activity = a67, ActivityInput = ai25, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai87 = new ActivityActivityInput() { Activity = a67, ActivityInput = ai26, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai88 = new ActivityActivityInput() { Activity = a67, ActivityInput = ai27, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai89 = new ActivityActivityInput() { Activity = a67, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai90 = new ActivityActivityInput() { Activity = a68, ActivityInput = ai28, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai91 = new ActivityActivityInput() { Activity = a68, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai92 = new ActivityActivityInput() { Activity = a69, ActivityInput = ai29, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai93 = new ActivityActivityInput() { Activity = a70, ActivityInput = ai30, Active = true, Required = true, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai94 = new ActivityActivityInput() { Activity = a70, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai95 = new ActivityActivityInput() { Activity = a71, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            ActivityActivityInput aai96 = new ActivityActivityInput() { Activity = a72, ActivityInput = ai1, Active = true, Required = false, OneTime = false, ActivityInputFor = ActivityActivityInput.InputForType.All };
            #endregion


            context.ServiceActivities.AddOrUpdate(x => x.ServiceActivityId, sa1, sa2, sa3, sa4, sa5, sa6, sa7, sa8, sa9, sa10, sa11, sa12, sa13, sa14, sa15, sa16, sa17, sa18, sa19, sa20, sa21, sa22, sa23, sa24, sa25, sa26, sa27, sa28, sa29, sa30, sa31, sa32, sa33, sa34, sa35, sa36, sa37, sa38, sa39, sa40, sa41, sa42, sa43, sa44, sa45, sa46, sa47, sa48, sa49, sa50, sa51, sa52, sa53, sa54, sa55, sa56, sa57, sa58, sa59, sa60, sa61, sa62, sa63, sa64, sa65, sa66, sa67, sa68, sa69, sa70, sa71, sa72, sa73, sa74, sa75, sa76, sa77, sa78, sa79, sa80, sa81, sa82, sa83, sa84, sa85, sa86, sa87, sa88, sa89, sa90, sa91, sa92, sa93);

            context.Activities.AddOrUpdate(x => x.ActivityId, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55, a56, a57, a58, a59, a60, a61, a62, a63, a64, a65, a66, a67, a68, a69, a70, a71, a72);

            context.ActivityInputs.AddOrUpdate(y => y.ActivityInputId, ai1, ai2, ai3, ai4, ai5, ai6, ai7, ai8, ai9, ai10, ai11, ai12, ai13, ai14, ai15, ai16, ai17, ai18, ai19, ai20, ai21, ai22, ai23, ai24, ai25, ai26, ai27, ai28, ai29, ai30);

            context.ActivityActivityInputs.AddOrUpdate(x => x.ActivityActivityInputId, aai1, aai2, aai3, aai4, aai5, aai6, aai7, aai8, aai9, aai10, aai11, aai12, aai13, aai14, aai15, aai16, aai17, aai18, aai19, aai20, aai21, aai22, aai23, aai24, aai25, aai26, aai27, aai28, aai29, aai30, aai31, aai32, aai33, aai34, aai35, aai36, aai37, aai38, aai39, aai40, aai41, aai42, aai43, aai44, aai45, aai46, aai47, aai48, aai49, aai50, aai51, aai52, aai53, aai54, aai55, aai56, aai57, aai58, aai59, aai60, aai61, aai62, aai63, aai64, aai65, aai66, aai67, aai68, aai69, aai70, aai71, aai72, aai73, aai74, aai75, aai76, aai77, aai78, aai79, aai80, aai81, aai82, aai83, aai84, aai85, aai86, aai87, aai88, aai89, aai90, aai91, aai92, aai93, aai94, aai95, aai96);

            #endregion

            #region Commented

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
            ActivityInput ai21 = new ActivityInput() { Activity = a19, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai22 = new ActivityInput() { Activity = a19, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai23 = new ActivityInput() { Activity = a20, Title = "Udarci na minuto", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;150", Required = true, OneTime = false };
            ActivityInput ai24 = new ActivityInput() { Activity = a21, Title = "Vdihi na minuto", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "10;;150", Required = true, OneTime = false };
            ActivityInput ai25 = new ActivityInput() { Activity = a22, Title = "st C", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "30;;45", Required = true, OneTime = false };
            ActivityInput ai26 = new ActivityInput() { Activity = a23, Title = "kg", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai27 = new ActivityInput() { Activity = a24, Title = "kg", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai28 = new ActivityInput() { Activity = a25, Title = "Datum rojstva otroka	", InputType = ActivityInput.InputTypeEnum.Date, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai29 = new ActivityInput() { Activity = a25, Title = "Porodna teža otroka (g)	", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;20000", Required = true, OneTime = false };
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
            ActivityInput ai44 = new ActivityInput() { Activity = a40, Title = "Sistolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai45 = new ActivityInput() { Activity = a40, Title = "Diastolièni (mm Hg)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "100;;300", Required = true, OneTime = false };
            ActivityInput ai57 = new ActivityInput() { Activity = a41, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai58 = new ActivityInput() { Activity = a42, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai59 = new ActivityInput() { Activity = a43, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai60 = new ActivityInput() { Activity = a44, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai61 = new ActivityInput() { Activity = a45, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai62 = new ActivityInput() { Activity = a46, Title = "cm", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;300", Required = true, OneTime = false };
            ActivityInput ai63 = new ActivityInput() { Activity = a47, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai64 = new ActivityInput() { Activity = a47, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai65 = new ActivityInput() { Activity = a48, Title = "Da/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Ne", Required = true, OneTime = false };
            ActivityInput ai66 = new ActivityInput() { Activity = a48, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai67 = new ActivityInput() { Activity = a49, Title = "Izberite", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Ni posebnosti;;Mikcija;;Defekacija;;Napenjanje;;Kolike;;Polivanje;;Bruhanje", Required = true, OneTime = false };
            ActivityInput ai68 = new ActivityInput() { Activity = a49, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai69 = new ActivityInput() { Activity = a50, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai70 = new ActivityInput() { Activity = a51, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai71 = new ActivityInput() { Activity = a52, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai72 = new ActivityInput() { Activity = a53, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai73 = new ActivityInput() { Activity = a54, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai74 = new ActivityInput() { Activity = a55, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = true, OneTime = false };
            ActivityInput ai80 = new ActivityInput() { Activity = a56, Title = "kg", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;500", Required = true, OneTime = false };
            ActivityInput ai81 = new ActivityInput() { Activity = a57, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai82 = new ActivityInput() { Activity = a58, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai83 = new ActivityInput() { Activity = a49, Title = "Urin", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai84 = new ActivityInput() { Activity = a49, Title = "Blato", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai85 = new ActivityInput() { Activity = a59, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai86 = new ActivityInput() { Activity = a60, Title = "Vid", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai87 = new ActivityInput() { Activity = a60, Title = "Vonj", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai88 = new ActivityInput() { Activity = a60, Title = "Sluh", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai89 = new ActivityInput() { Activity = a60, Title = "Okus", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai90 = new ActivityInput() { Activity = a60, Title = "Otip", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai91 = new ActivityInput() { Activity = a61, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai92 = new ActivityInput() { Activity = a62, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai93 = new ActivityInput() { Activity = a63, Title = "Odvisnost", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Samostojen;;Delno odvisen;;Povsem odvisen", Required = true, OneTime = false };
            ActivityInput ai94 = new ActivityInput() { Activity = a63, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai95 = new ActivityInput() { Activity = a63, Title = "Pomoè: svojci, drugi", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai96 = new ActivityInput() { Activity = a64, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai97 = new ActivityInput() { Activity = a65, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai98 = new ActivityInput() { Activity = a66, Title = "", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai100 = new ActivityInput() { Activity = a67, Title = "", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai108 = new ActivityInput() { Activity = a68, Title = "mmol/L", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;100", Required = true, OneTime = false };
            ActivityInput ai109 = new ActivityInput() { Activity = a68, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai110 = new ActivityInput() { Activity = a69, Title = "%", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;100", Required = true, OneTime = false };
            ActivityInput ai111 = new ActivityInput() { Activity = a70, Title = "Da/Delno/Ne", InputType = ActivityInput.InputTypeEnum.Dropdown, PossibleValues = "Da;;Delno;;Ne", Required = true, OneTime = false };
            ActivityInput ai112 = new ActivityInput() { Activity = a70, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai113 = new ActivityInput() { Activity = a71, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai114 = new ActivityInput() { Activity = a72, Title = "Prosti vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai116 = new ActivityInput() { Activity = a25, Title = "Porodna višina otroka (cm)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;100", Required = true, OneTime = false };
            ActivityInput ai117 = new ActivityInput() { Activity = a25, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai1001 = new ActivityInput() { Activity = a67, Title = "Št. rdeèih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1002 = new ActivityInput() { Activity = a67, Title = "Št. modrih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1003 = new ActivityInput() { Activity = a67, Title = "Št. rumenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1004 = new ActivityInput() { Activity = a67, Title = "Št. zelenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };

              ActivityInput ai1 = new ActivityInput() { Activity = a1, Title = "Prosti vnos", Required = false };
            ActivityInput ai2 = new ActivityInput() { Activity = a2, Title = "Prosti vnos", Required = false };
            ActivityInput ai3 = new ActivityInput() { Activity = a3, Title = "Prosti vnos", Required = false };
            ActivityInput ai4 = new ActivityInput() { Activity = a4, Title = "Prosti vnos", Required = false };
            ActivityInput ai5 = new ActivityInput() { Activity = a5, Title = "Prosti vnos", Required = false };
            ActivityInput ai6 = new ActivityInput() { Activity = a6, Title = "Prosti vnos", Required = false };
            ActivityInput ai7 = new ActivityInput() { Activity = a7, Title = "Prosti vnos", Required = false };
            ActivityInput ai8 = new ActivityInput() { Activity = a8, Title = "Prosti vnos", Required = false };
            ActivityInput ai9 = new ActivityInput() { Activity = a9, Title = "Prosti vnos", Required = false };
            ActivityInput ai10 = new ActivityInput() { Activity = a10, Title = "Prosti vnos", Required = false };
            ActivityInput ai11 = new ActivityInput() { Activity = a11, Title = "Prosti vnos", Required = false };
            ActivityInput ai12 = new ActivityInput() { Activity = a12, Title = "Prosti vnos", Required = false };
            ActivityInput ai13 = new ActivityInput() { Activity = a13, Title = "Prosti vnos", Required = false };
            ActivityInput ai14 = new ActivityInput() { Activity = a14, Title = "Datum ", Required = true };
            ActivityInput ai15 = new ActivityInput() { Activity = a15, Title = "Prosti vnos ", Required = true };
            ActivityInput ai16 = new ActivityInput() { Activity = a16, Title = "Prosti vnos ", Required = true };
            ActivityInput ai17 = new ActivityInput() { Activity = a17, Title = "Moteno/Ni moteno ", Required = true };
            ActivityInput ai18 = new ActivityInput() { Activity = a17, Title = "Prosti vnos", Required = false };
            ActivityInput ai19 = new ActivityInput() { Activity = a18, Title = "Nizka/Srednja/Visoka", Required = true };
            ActivityInput ai20 = new ActivityInput() { Activity = a18, Title = "Prosti vnos", Required = false };
            ActivityInput ai21 = new ActivityInput() { Activity = a19, Title = "Sistolièni (mm Hg)", Required = true };
            ActivityInput ai22 = new ActivityInput() { Activity = a19, Title = "Diastolièni (mm Hg)", Required = true };
            ActivityInput ai23 = new ActivityInput() { Activity = a20, Title = "Udarci na minuto", Required = true };
            ActivityInput ai24 = new ActivityInput() { Activity = a21, Title = "Vdihi na minuto", Required = true };
            ActivityInput ai25 = new ActivityInput() { Activity = a22, Title = "st C", Required = true };
            ActivityInput ai26 = new ActivityInput() { Activity = a23, Title = "kg", Required = true };
            ActivityInput ai27 = new ActivityInput() { Activity = a24, Title = "kg", Required = true };
            ActivityInput ai28 = new ActivityInput() { Activity = a25, Title = "Datum rojstva otroka	", Required = true };
            ActivityInput ai29 = new ActivityInput() { Activity = a25, Title = "Porodna teža otroka (g)	", Required = true };
            ActivityInput ai30 = new ActivityInput() { Activity = a26, Title = "Prosti vnos", Required = false };
            ActivityInput ai31 = new ActivityInput() { Activity = a27, Title = "Prosti vnos", Required = false };
            ActivityInput ai32 = new ActivityInput() { Activity = a28, Title = "Prosti vnos", Required = false };
            ActivityInput ai33 = new ActivityInput() { Activity = a29, Title = "Prosti vnos", Required = false };
            ActivityInput ai34 = new ActivityInput() { Activity = a30, Title = "Prosti vnos", Required = false };
            ActivityInput ai35 = new ActivityInput() { Activity = a31, Title = "Prosti vnos", Required = false };
            ActivityInput ai36 = new ActivityInput() { Activity = a32, Title = "Prosti vnos", Required = false };
            ActivityInput ai37 = new ActivityInput() { Activity = a33, Title = "Prosti vnos", Required = false };
            ActivityInput ai38 = new ActivityInput() { Activity = a34, Title = "Prosti vnos", Required = false };
            ActivityInput ai39 = new ActivityInput() { Activity = a35, Title = "Prosti vnos", Required = false };
            ActivityInput ai40 = new ActivityInput() { Activity = a36, Title = "Prosti vnos", Required = false };
            ActivityInput ai41 = new ActivityInput() { Activity = a37, Title = "Prosti vnos", Required = false };
            ActivityInput ai42 = new ActivityInput() { Activity = a38, Title = "Prosti vnos", Required = false };
            ActivityInput ai43 = new ActivityInput() { Activity = a39, Title = "Prosti vnos", Required = false };
            ActivityInput ai44 = new ActivityInput() { Activity = a40, Title = "Sistolièni (mm Hg)", Required = true };
            ActivityInput ai45 = new ActivityInput() { Activity = a40, Title = "Diastolièni (mm Hg)", Required = true };
            ActivityInput ai57 = new ActivityInput() { Activity = a41, Title = "Prosti vnos", Required = false };
            ActivityInput ai58 = new ActivityInput() { Activity = a42, Title = "Prosti vnos", Required = false };
            ActivityInput ai59 = new ActivityInput() { Activity = a43, Title = "Prosti vnos", Required = false };
            ActivityInput ai60 = new ActivityInput() { Activity = a44, Title = "Prosti vnos", Required = false };
            ActivityInput ai61 = new ActivityInput() { Activity = a45, Title = "Prosti vnos", Required = false };
            ActivityInput ai62 = new ActivityInput() { Activity = a46, Title = "cm", Required = true };
            ActivityInput ai63 = new ActivityInput() { Activity = a47, Title = "Da/Ne", Required = true };
            ActivityInput ai64 = new ActivityInput() { Activity = a47, Title = "Prosti vnos", Required = false };
            ActivityInput ai65 = new ActivityInput() { Activity = a48, Title = "Da/Ne", Required = true };
            ActivityInput ai66 = new ActivityInput() { Activity = a48, Title = "Prosti vnos", Required = false };
            ActivityInput ai67 = new ActivityInput() { Activity = a49, Title = "Ni posebnosti/Mikcija/Defekacija/Napenjanje/Kolike/Polivanje/Bruhanje", Required = true };
            ActivityInput ai68 = new ActivityInput() { Activity = a49, Title = "Prosti vnos", Required = false };
            ActivityInput ai69 = new ActivityInput() { Activity = a50, Title = "Prosti vnos", Required = true };
            ActivityInput ai70 = new ActivityInput() { Activity = a51, Title = "Prosti vnos", Required = true };
            ActivityInput ai71 = new ActivityInput() { Activity = a52, Title = "Prosti vnos", Required = true };
            ActivityInput ai72 = new ActivityInput() { Activity = a53, Title = "Prosti vnos", Required = false };
            ActivityInput ai73 = new ActivityInput() { Activity = a54, Title = "Prosti vnos", Required = true };
            ActivityInput ai74 = new ActivityInput() { Activity = a55, Title = "Prosti vnos", Required = true };
            ActivityInput ai80 = new ActivityInput() { Activity = a56, Title = "kg", Required = true };
            ActivityInput ai81 = new ActivityInput() { Activity = a57, Title = "Prosti vnos", Required = false };
            ActivityInput ai82 = new ActivityInput() { Activity = a58, Title = "Prosti vnos", Required = false };
            ActivityInput ai83 = new ActivityInput() { Activity = a49, Title = "Urin", Required = false };
            ActivityInput ai84 = new ActivityInput() { Activity = a49, Title = "Blato", Required = false };
            ActivityInput ai85 = new ActivityInput() { Activity = a59, Title = "Prosti vnos", Required = false };
            ActivityInput ai86 = new ActivityInput() { Activity = a60, Title = "Vid", Required = false };
            ActivityInput ai87 = new ActivityInput() { Activity = a60, Title = "Vonj", Required = false };
            ActivityInput ai88 = new ActivityInput() { Activity = a60, Title = "Sluh", Required = false };
            ActivityInput ai89 = new ActivityInput() { Activity = a60, Title = "Okus", Required = false };
            ActivityInput ai90 = new ActivityInput() { Activity = a60, Title = "Otip", Required = false };
            ActivityInput ai91 = new ActivityInput() { Activity = a61, Title = "Prosti vnos", Required = false };
            ActivityInput ai92 = new ActivityInput() { Activity = a62, Title = "Prosti vnos", Required = false };
            ActivityInput ai93 = new ActivityInput() { Activity = a63, Title = "Samostojen/Delno odvisen/Povsem odvisen", Required = true };
            ActivityInput ai94 = new ActivityInput() { Activity = a63, Title = "Prosti vnos", Required = false };
            ActivityInput ai95 = new ActivityInput() { Activity = a63, Title = "Pomoè: svojci, drugi", Required = false };
            ActivityInput ai96 = new ActivityInput() { Activity = a64, Title = "Prosti vnos", Required = false };
            ActivityInput ai97 = new ActivityInput() { Activity = a65, Title = "Prosti vnos", Required = false };
            ActivityInput ai98 = new ActivityInput() { Activity = a66, Title = "", Required = false };
            ActivityInput ai100 = new ActivityInput() { Activity = a67, Title = "", Required = false };
            ActivityInput ai108 = new ActivityInput() { Activity = a68, Title = "mmol/L", Required = true };
            ActivityInput ai109 = new ActivityInput() { Activity = a68, Title = "Prosti vnos", Required = false };
            ActivityInput ai110 = new ActivityInput() { Activity = a69, Title = "%", Required = true };
            ActivityInput ai111 = new ActivityInput() { Activity = a70, Title = "Da/Delno/Ne", Required = true };
            ActivityInput ai112 = new ActivityInput() { Activity = a70, Title = "Prosti vnos", Required = false };
            ActivityInput ai113 = new ActivityInput() { Activity = a71, Title = "Prosti vnos", Required = false };
            ActivityInput ai114 = new ActivityInput() { Activity = a72, Title = "Prosti vnos", Required = false };
            ActivityInput ai116 = new ActivityInput() { Activity = a25, Title = "Porodna višina otroka (cm)", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "20;;100", Required = true, OneTime = false };
            ActivityInput ai117 = new ActivityInput() { Activity = a25, Title = "Prost vnos", InputType = ActivityInput.InputTypeEnum.Free, PossibleValues = "", Required = false, OneTime = false };
            ActivityInput ai1001 = new ActivityInput() { Activity = a67, Title = "Št. rdeèih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1002 = new ActivityInput() { Activity = a67, Title = "Št. modrih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1003 = new ActivityInput() { Activity = a67, Title = "Št. rumenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
            ActivityInput ai1004 = new ActivityInput() { Activity = a67, Title = "Št. zelenih epruvet", InputType = ActivityInput.InputTypeEnum.Number, PossibleValues = "0;;10", Required = true, OneTime = false };
             */

            #endregion

        }
    }
}
