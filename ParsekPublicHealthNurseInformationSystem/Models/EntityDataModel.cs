namespace ParsekPublicHealthNurseInformationSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EntityDataModel : DbContext
    {
        // Your context has been configured to use a 'EntityDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ParsekPublicHealthNurseInformationSystem.Models.EntityDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EntityDataModel' 
        // connection string in the application configuration file.
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PostOffice> PostOffices { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        // TODO DATA MODELS
        /*
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialWorkOrder> MaterialWorkOrders { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; } // s?
        public virtual DbSet<MedicineWorkOrder> MedicineWorkOrders { get; set; }
        public virtual DbSet<PatientWorkOrder> PatientWorkOrders { get; set; }
        */
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}