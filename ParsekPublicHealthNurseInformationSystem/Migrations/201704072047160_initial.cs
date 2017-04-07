namespace ParsekPublicHealthNurseInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        CardNumber = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactSurname = c.String(),
                        ContactAddress = c.String(),
                        ContactPhone = c.String(),
                        ContactRelationship = c.String(),
                        ParentPatientId = c.Int(),
                        ParentPatientRelationship = c.String(),
                        District_DistrictId = c.Int(nullable: false),
                        PostOffice_PostOfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Patients", t => t.ParentPatientId)
                .ForeignKey("dbo.Districts", t => t.District_DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.PostOffices", t => t.PostOffice_PostOfficeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.ParentPatientId)
                .Index(t => t.District_DistrictId)
                .Index(t => t.PostOffice_PostOfficeId);
            
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
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contractor_ContractorId = c.Int(),
                        Disease_DiseaseId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorId)
                .ForeignKey("dbo.Diseases", t => t.Disease_DiseaseId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Contractor_ContractorId)
                .Index(t => t.Disease_DiseaseId)
                .Index(t => t.Employee_EmployeeId);
            
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
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Patients", "PatientId", "dbo.Users");
            DropForeignKey("dbo.Patients", "PostOffice_PostOfficeId", "dbo.PostOffices");
            DropForeignKey("dbo.Visits", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.PatientWorkOrders", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WorkOrders", "Disease_DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.WorkOrders", "Contractor_ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.PatientWorkOrders", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicineWorkOrders", "PatientWorkOrder_PatientWorkOrderId", "dbo.PatientWorkOrders");
            DropForeignKey("dbo.MedicineWorkOrders", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MaterialWorkOrders", "PatientWorkOrder_PatientWorkOrderId", "dbo.PatientWorkOrders");
            DropForeignKey("dbo.MaterialWorkOrders", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Patients", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Patients", "ParentPatientId", "dbo.Patients");
            DropForeignKey("dbo.Employees", "District_DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Employees", "Contractor_ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Contractors", "PostOffice_PostOfficeId", "dbo.PostOffices");
            DropIndex("dbo.Visits", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.WorkOrders", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.WorkOrders", new[] { "Disease_DiseaseId" });
            DropIndex("dbo.WorkOrders", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.MedicineWorkOrders", new[] { "PatientWorkOrder_PatientWorkOrderId" });
            DropIndex("dbo.MedicineWorkOrders", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.MaterialWorkOrders", new[] { "PatientWorkOrder_PatientWorkOrderId" });
            DropIndex("dbo.MaterialWorkOrders", new[] { "Material_MaterialId" });
            DropIndex("dbo.PatientWorkOrders", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.PatientWorkOrders", new[] { "Patient_PatientId" });
            DropIndex("dbo.Patients", new[] { "PostOffice_PostOfficeId" });
            DropIndex("dbo.Patients", new[] { "District_DistrictId" });
            DropIndex("dbo.Patients", new[] { "ParentPatientId" });
            DropIndex("dbo.Patients", new[] { "PatientId" });
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Employees", new[] { "District_DistrictId" });
            DropIndex("dbo.Employees", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.Contractors", new[] { "PostOffice_PostOfficeId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Visits");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineWorkOrders");
            DropTable("dbo.Materials");
            DropTable("dbo.MaterialWorkOrders");
            DropTable("dbo.PatientWorkOrders");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
            DropTable("dbo.Districts");
            DropTable("dbo.Diseases");
            DropTable("dbo.PostOffices");
            DropTable("dbo.Contractors");
        }
    }
}
