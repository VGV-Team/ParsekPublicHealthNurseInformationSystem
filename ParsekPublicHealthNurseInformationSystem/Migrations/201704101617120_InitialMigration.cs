namespace ParsekPublicHealthNurseInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ServiceCode = c.String(nullable: false),
                        ServiceTitle = c.String(nullable: false),
                        ActivityCode = c.String(nullable: false),
                        ActivityTitle = c.String(nullable: false),
                        Report = c.String(nullable: false),
                        PreventiveVisit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Activity_ActivityId = c.Int(),
                        Contractor_ContractorId = c.Int(),
                        Disease_DiseaseId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                        Issuer_EmployeeId = c.Int(),
                        Nurse_EmployeeId = c.Int(),
                        NurseReplacement_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorId)
                .ForeignKey("dbo.Diseases", t => t.Disease_DiseaseId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Issuer_EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Nurse_EmployeeId)
                .ForeignKey("dbo.Employees", t => t.NurseReplacement_EmployeeId)
                .Index(t => t.Activity_ActivityId)
                .Index(t => t.Contractor_ContractorId)
                .Index(t => t.Disease_DiseaseId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Issuer_EmployeeId)
                .Index(t => t.Nurse_EmployeeId)
                .Index(t => t.NurseReplacement_EmployeeId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PostOffice_PostOfficeId = c.Int(),
                    })
                .PrimaryKey(t => t.ContractorId)
                .ForeignKey("dbo.PostOffices", t => t.PostOffice_PostOfficeId)
                .Index(t => t.PostOffice_PostOfficeId);
            
            CreateTable(
                "dbo.PostOffices",
                c => new
                    {
                        PostOfficeId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostOfficeId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        DiseaseId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DiseaseId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Title = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Contractor_ContractorId = c.Int(nullable: false),
                        District_DistrictId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.District_DistrictId)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.Contractor_ContractorId)
                .Index(t => t.District_DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lon = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        EmailCode = c.String(),
                        EmailExpire = c.DateTime(),
                        Patient_PatientId = c.Int(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        ContactName = c.String(),
                        ContactSurname = c.String(),
                        ContactAddress = c.String(),
                        ContactPhone = c.String(),
                        ContactRelationship = c.String(),
                        ParentPatientId = c.Int(),
                        District_DistrictId = c.Int(nullable: false),
                        ParentPatientRelationship_RelationshipId = c.Int(),
                        PostOffice_PostOfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Patients", t => t.ParentPatientId)
                .ForeignKey("dbo.Districts", t => t.District_DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Relationships", t => t.ParentPatientRelationship_RelationshipId)
                .ForeignKey("dbo.PostOffices", t => t.PostOffice_PostOfficeId, cascadeDelete: true)
                .Index(t => t.ParentPatientId)
                .Index(t => t.District_DistrictId)
                .Index(t => t.ParentPatientRelationship_RelationshipId)
                .Index(t => t.PostOffice_PostOfficeId);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipId);
            
            CreateTable(
                "dbo.PatientWorkOrders",
                c => new
                    {
                        PatientWorkOrderId = c.Int(nullable: false, identity: true),
                        Patient_PatientId = c.Int(),
                        WorkOrder_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.PatientWorkOrderId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_WorkOrderId)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.WorkOrder_WorkOrderId);
            
            CreateTable(
                "dbo.MaterialWorkOrders",
                c => new
                    {
                        MaterialWorkOrderId = c.Int(nullable: false, identity: true),
                        Material_MaterialId = c.Int(),
                        PatientWorkOrder_PatientWorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.MaterialWorkOrderId)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId)
                .ForeignKey("dbo.PatientWorkOrders", t => t.PatientWorkOrder_PatientWorkOrderId)
                .Index(t => t.Material_MaterialId)
                .Index(t => t.PatientWorkOrder_PatientWorkOrderId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.MedicineWorkOrders",
                c => new
                    {
                        MedicineWorkOrderId = c.Int(nullable: false, identity: true),
                        Medicine_MedicineId = c.Int(),
                        PatientWorkOrder_PatientWorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicineWorkOrderId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId)
                .ForeignKey("dbo.PatientWorkOrders", t => t.PatientWorkOrder_PatientWorkOrderId)
                .Index(t => t.Medicine_MedicineId)
                .Index(t => t.PatientWorkOrder_PatientWorkOrderId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Mandatory = c.Boolean(nullable: false),
                        WorkOrder_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_WorkOrderId)
                .Index(t => t.WorkOrder_WorkOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "NurseReplacement_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WorkOrders", "Nurse_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WorkOrders", "Issuer_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WorkOrders", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "PostOffice_PostOfficeId", "dbo.PostOffices");
            DropForeignKey("dbo.PatientWorkOrders", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.PatientWorkOrders", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicineWorkOrders", "PatientWorkOrder_PatientWorkOrderId", "dbo.PatientWorkOrders");
            DropForeignKey("dbo.MedicineWorkOrders", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MaterialWorkOrders", "PatientWorkOrder_PatientWorkOrderId", "dbo.PatientWorkOrders");
            DropForeignKey("dbo.MaterialWorkOrders", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Patients", "ParentPatientRelationship_RelationshipId", "dbo.Relationships");
            DropForeignKey("dbo.Patients", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Patients", "ParentPatientId", "dbo.Patients");
            DropForeignKey("dbo.Employees", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Employees", "Contractor_ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.WorkOrders", "Disease_DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.WorkOrders", "Contractor_ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Contractors", "PostOffice_PostOfficeId", "dbo.PostOffices");
            DropForeignKey("dbo.WorkOrders", "Activity_ActivityId", "dbo.Activities");
            DropIndex("dbo.Visits", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.MedicineWorkOrders", new[] { "PatientWorkOrder_PatientWorkOrderId" });
            DropIndex("dbo.MedicineWorkOrders", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.MaterialWorkOrders", new[] { "PatientWorkOrder_PatientWorkOrderId" });
            DropIndex("dbo.MaterialWorkOrders", new[] { "Material_MaterialId" });
            DropIndex("dbo.PatientWorkOrders", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.PatientWorkOrders", new[] { "Patient_PatientId" });
            DropIndex("dbo.Patients", new[] { "PostOffice_PostOfficeId" });
            DropIndex("dbo.Patients", new[] { "ParentPatientRelationship_RelationshipId" });
            DropIndex("dbo.Patients", new[] { "District_DistrictId" });
            DropIndex("dbo.Patients", new[] { "ParentPatientId" });
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Users", new[] { "Patient_PatientId" });
            DropIndex("dbo.Employees", new[] { "District_DistrictId" });
            DropIndex("dbo.Employees", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.Contractors", new[] { "PostOffice_PostOfficeId" });
            DropIndex("dbo.WorkOrders", new[] { "NurseReplacement_EmployeeId" });
            DropIndex("dbo.WorkOrders", new[] { "Nurse_EmployeeId" });
            DropIndex("dbo.WorkOrders", new[] { "Issuer_EmployeeId" });
            DropIndex("dbo.WorkOrders", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.WorkOrders", new[] { "Disease_DiseaseId" });
            DropIndex("dbo.WorkOrders", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.WorkOrders", new[] { "Activity_ActivityId" });
            DropTable("dbo.Visits");
            DropTable("dbo.Roles");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineWorkOrders");
            DropTable("dbo.Materials");
            DropTable("dbo.MaterialWorkOrders");
            DropTable("dbo.PatientWorkOrders");
            DropTable("dbo.Relationships");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Districts");
            DropTable("dbo.Employees");
            DropTable("dbo.Diseases");
            DropTable("dbo.PostOffices");
            DropTable("dbo.Contractors");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.Activities");
        }
    }
}
