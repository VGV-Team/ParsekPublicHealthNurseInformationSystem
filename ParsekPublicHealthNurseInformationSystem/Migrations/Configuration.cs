namespace ParsekPublicHealthNurseInformationSystem.Migrations
{
    using Models;
    using Models.Model;
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
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1, patient2, patient3);
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
            patient1_1.ParentPatientRelationship = rel1;
            context.Patients.AddOrUpdate(y => y.CardNumber, patient1_1);

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
            Service ac2 = new Service();
            ac2.ServiceCode = "20";
            ac2.ServiceTitle = "Obisk otroènice in novorojenèka";
            ac2.PreventiveVisit = true;
            ac2.RequiresMedicine = false;
            ac2.RequiresBloodSample = false;
            ac2.RequiresPatients = true;

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

            context.Services.AddOrUpdate(y => y.ServiceId, ac1, ac2, /*ac3,*/ ac4, ac5, ac6, ac7);



            #region Activities


            Activity a1 = new Activity() { ActivityCode = 10, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice o normalnem poteku noseènosti in o spremembah na telesu." };
            Activity a2 = new Activity() { ActivityCode = 20, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Povabilo v šolo za starše." };
            Activity a3 = new Activity() { ActivityCode = 30, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev o rednih ginekoloških pregledih." };
            Activity a4 = new Activity() { ActivityCode = 40, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev z bližajoèim se porodom in pravoèasnim odhodom v porodnišnico. " };
            Activity a5 = new Activity() { ActivityCode = 50, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor in vkljuèevanje partnerja v noseènost in porod ter po prihodu domov. " };
            Activity a6 = new Activity() { ActivityCode = 60, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o pripomoèkih, ki jih bo potrebovala v porodnišnici. " };
            Activity a7 = new Activity() { ActivityCode = 70, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice o štetju in beleženju plodovih gibov. " };
            Activity a8 = new Activity() { ActivityCode = 80, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje glede opreme za novorojenca in primerno ležišèe. " };
            Activity a9 = new Activity() { ActivityCode = 90, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o pravilni prehrani, ustrezni izbiri obleke in obutve." };
            Activity a10 = new Activity() { ActivityCode = 100, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Svetovanje o primernem režim življenja, telesne vaje, gibanje na svežem zraku." };
            Activity a11 = new Activity() { ActivityCode = 110, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Odsvetovanje razvad kot so uživanje alkohola, kajenje, uživanje zdravil in drog. " };
            Activity a12 = new Activity() { ActivityCode = 120, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev nosoènice z nevšeènostmi in svetovanje glede lajšanja težav zaradi nevšeènosti (slabosti, bruhanja, zaprtja, pogostih mikcij, nespeènosti, zgage, ...)." };
            Activity a13 = new Activity() { ActivityCode = 130, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Seznanitev noseènice s pravicami do starševskega dopusta (porodniški dopust, pravica do dopusta za nego in varstvo otroka, pravica do oèetovskega dopusta) in o uveljavljanju pravic povezanih z rojstvom otroka (pravica do paketa, otroški dodatek, zdravstveno zavarovanje, rojstni list, ureditev oèetovstva)." };
            Activity a14 = new Activity() { ActivityCode = 140, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Prièakovan datum poroda" };
            Activity a15 = new Activity() { ActivityCode = 150, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza: poèutje, telesni znaki noseènosti." };
            Activity a16 = new Activity() { ActivityCode = 160, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Družinska anamneza: Odnosi v družini, odnos družine do okolja, bivalni pogoji, ekonomske razmere, zdravstveno stanje družinskih èlanov, zdravstvena prosvetljenost in vzgojenost." };
            Activity a17 = new Activity() { ActivityCode = 170, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Izražanje èustev" };
            Activity a18 = new Activity() { ActivityCode = 180, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Fizièna obremenjenost" };
            Activity a19 = new Activity() { ActivityCode = 190, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni pritisk: sistolièni, diastolièni" };
            Activity a20 = new Activity() { ActivityCode = 200, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Srèni utrip" };
            Activity a21 = new Activity() { ActivityCode = 210, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Dihanje" };
            Activity a22 = new Activity() { ActivityCode = 220, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna temperatura" };
            Activity a23 = new Activity() { ActivityCode = 230, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna teža pred noseènostjo" };
            Activity a24 = new Activity() { ActivityCode = 240, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Trenutna telesna teža" };
            Activity a25 = new Activity() { ActivityCode = 250, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Pregled materinske knjižice in odpustnice iz porodnišnice. " };
            Activity a26 = new Activity() { ActivityCode = 260, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Kontrola vitalnih funkcij." };
            Activity a27 = new Activity() { ActivityCode = 270, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Opazovanje èišèe. " };
            Activity a28 = new Activity() { ActivityCode = 280, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Nadzor nad izloèanjem blata in urina. " };
            Activity a29 = new Activity() { ActivityCode = 290, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Zdravstveno vzgojno delo glede pravilnega rokovanja z novorojenèkom, uèenje tehnike nege novorojenèka" };
            Activity a30 = new Activity() { ActivityCode = 300, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Motivacija za dojenje. Nadzor in pomoè pri dojenju. " };
            Activity a31 = new Activity() { ActivityCode = 310, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o èustveni podpori s strani partnerja." };
            Activity a32 = new Activity() { ActivityCode = 320, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Seznanitev o otrokovih potrebah po toplini, nežnosti in varnosti." };
            Activity a33 = new Activity() { ActivityCode = 330, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o spalnih potrebah otroènice, pravilni negi in higienskem režimu v poporodnem obdobju. " };
            Activity a34 = new Activity() { ActivityCode = 340, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o pravilni prehrani, pitju ustreznih kolièin tekoèin" };
            Activity a35 = new Activity() { ActivityCode = 350, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Pouèitev o poporodni telovadbi." };
            Activity a36 = new Activity() { ActivityCode = 360, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Sezananitev z nekaterimi obolenji." };
            Activity a37 = new Activity() { ActivityCode = 370, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Napotitev na poporodni pregled." };
            Activity a38 = new Activity() { ActivityCode = 380, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Seznanitev z metodami zašèite pred nezaželjno noseènostjo." };
            Activity a39 = new Activity() { ActivityCode = 390, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Svetovanje o normalnem delu, življenju in spolnih odnosih. " };
            Activity a40 = new Activity() { ActivityCode = 400, ActivityInputFor = Activity.InputForType.ParentOnly, ActivityTitle = "Krvni pritisk otroènice" };
            Activity a41 = new Activity() { ActivityCode = 410, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Prikaz nege dojenèka" };
            Activity a42 = new Activity() { ActivityCode = 420, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Nega popokovne rane" };
            Activity a43 = new Activity() { ActivityCode = 430, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Nudenje pomoèi pri dojenju in seznanitev s tehnikami dojenja." };
            Activity a44 = new Activity() { ActivityCode = 440, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Ureditev ležišèa." };
            Activity a45 = new Activity() { ActivityCode = 450, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Svetovanje o povijanju, oblaèenju, slaèenju" };
            Activity a46 = new Activity() { ActivityCode = 460, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Trenutna telesna višina" };
            Activity a47 = new Activity() { ActivityCode = 470, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Dojenje" };
            Activity a48 = new Activity() { ActivityCode = 480, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Dodajanje adaptiranega mleka" };
            Activity a49 = new Activity() { ActivityCode = 490, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Izloèanje in odvajanje" };
            Activity a50 = new Activity() { ActivityCode = 500, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Ritem spanja" };
            Activity a51 = new Activity() { ActivityCode = 510, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Povišanje bilirubina (zlatenica)" };
            Activity a52 = new Activity() { ActivityCode = 520, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Kolki" };
            Activity a53 = new Activity() { ActivityCode = 530, ActivityInputFor = Activity.InputForType.PatientOnly, ActivityTitle = "Posebnosti" };
            Activity a54 = new Activity() { ActivityCode = 540, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Anamneza" };
            Activity a55 = new Activity() { ActivityCode = 550, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Družinska anamneza" };
            Activity a56 = new Activity() { ActivityCode = 560, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Telesna teža" };
            Activity a57 = new Activity() { ActivityCode = 570, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Osebna higiena" };
            Activity a58 = new Activity() { ActivityCode = 580, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Prehranjevanje in pitje" };
            Activity a59 = new Activity() { ActivityCode = 590, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Gibanje" };
            Activity a60 = new Activity() { ActivityCode = 600, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Èutila in obèutki" };
            Activity a61 = new Activity() { ActivityCode = 610, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Spanje in poèitek" };
            Activity a62 = new Activity() { ActivityCode = 620, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Duševno stanje: izražanje èustev in potreb, komunikacija" };
            Activity a63 = new Activity() { ActivityCode = 630, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Stanje neodvisnosti" };
            Activity a64 = new Activity() { ActivityCode = 640, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pregled predpisanih terapij" };
            Activity a65 = new Activity() { ActivityCode = 650, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pogovor, nasvet in vzpodbuda." };
            Activity a66 = new Activity() { ActivityCode = 660, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Aplikacija injekcije" };
            Activity a67 = new Activity() { ActivityCode = 670, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Odvzem krvi" };
            Activity a68 = new Activity() { ActivityCode = 680, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Krvni sladkor" };
            Activity a69 = new Activity() { ActivityCode = 690, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Oksigenacija SpO2" };
            Activity a70 = new Activity() { ActivityCode = 700, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Upoštevanje terapije" };
            Activity a71 = new Activity() { ActivityCode = 710, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Pregled terapije" };
            Activity a72 = new Activity() { ActivityCode = 720, ActivityInputFor = Activity.InputForType.All, ActivityTitle = "Navodila za terapijo do naslednjega obiska" };

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



            context.ServiceActivities.AddOrUpdate(x => x.ServiceActivityId, sa1, sa2, sa3, sa4, sa5, sa6, sa7, sa8, sa9, sa10, sa11, sa12, sa13, sa14, sa15, sa16, sa17, sa18, sa19, sa20, sa21, sa22, sa23, sa24, sa25, sa26, sa27, sa28, sa29, sa30, sa31, sa32, sa33, sa34, sa35, sa36, sa37, sa38, sa39, sa40, sa41, sa42, sa43, sa44, sa45, sa46, sa47, sa48, sa49, sa50, sa51, sa52, sa53, sa54, sa55, sa56, sa57, sa58, sa59, sa60, sa61, sa62, sa63, sa64, sa65, sa66, sa67, sa68, sa69, sa70, sa71, sa72, sa73, sa74, sa75, sa76, sa77, sa78, sa79, sa80, sa81, sa82, sa83, sa84, sa85, sa86, sa87, sa88, sa89, sa90, sa91, sa92, sa93);

            context.Activities.AddOrUpdate(x => x.ActivityId, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55, a56, a57, a58, a59, a60, a61, a62, a63, a64, a65, a66, a67, a68, a69, a70, a71, a72);

            context.ActivityInputs.AddOrUpdate(y => y.ActivityInputId, ai1, ai2, ai3, ai4, ai5, ai6, ai7, ai8, ai9, ai10, ai11, ai12, ai13, ai14, ai15, ai16, ai17, ai18, ai19, ai20, ai21, ai22, ai23, ai24, ai25, ai26, ai27, ai28, ai29, ai30, ai31, ai32, ai33, ai34, ai35, ai36, ai37, ai38, ai39, ai40, ai41, ai42, ai43, ai44, ai45, ai57, ai58, ai59, ai60, ai61, ai62, ai63, ai64, ai65, ai66, ai67, ai68, ai69, ai70, ai71, ai72, ai73, ai74, ai80, ai81, ai82, ai83, ai84, ai85, ai86, ai87, ai88, ai89, ai90, ai91, ai92, ai93, ai94, ai95, ai96, ai97, ai98, ai100, ai108, ai109, ai110, ai111, ai112, ai113, ai114, ai116, ai117, ai1001, ai1002, ai1003, ai1004);

            #endregion

            /*
             
             
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

        }
    }
}
