namespace CommunityMedicine.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CenterLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterId = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thanas", t => t.ThanaId, cascadeDelete: true)
                .Index(t => t.ThanaId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TreatmentProcedure = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreferedDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.DiseaseId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenericName = c.String(),
                        Measurement = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Thanas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterId = c.Int(nullable: false),
                        Name = c.String(),
                        Degree = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicineStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicineStoreId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.MedicineStores", t => t.MedicineStoreId, cascadeDelete: true)
                .Index(t => t.MedicineStoreId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientTreatmentId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        MedicineQuantity = c.Double(nullable: false),
                        SelectedDose = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.PatientTreatments", t => t.PatientTreatmentId, cascadeDelete: true)
                .Index(t => t.PatientTreatmentId)
                .Index(t => t.DiseaseId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.String(),
                        ServiceGiven = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientTreatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        Observation = c.String(),
                        Date = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        ServiceTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDiseases", "PatientTreatmentId", "dbo.PatientTreatments");
            DropForeignKey("dbo.PatientTreatments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientTreatments", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.PatientDiseases", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.PatientDiseases", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.StoreDetails", "MedicineStoreId", "dbo.MedicineStores");
            DropForeignKey("dbo.StoreDetails", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Centers", "ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.PreferedDrugs", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.PreferedDrugs", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.PatientTreatments", new[] { "DoctorId" });
            DropIndex("dbo.PatientTreatments", new[] { "CenterId" });
            DropIndex("dbo.PatientDiseases", new[] { "MedicineId" });
            DropIndex("dbo.PatientDiseases", new[] { "DiseaseId" });
            DropIndex("dbo.PatientDiseases", new[] { "PatientTreatmentId" });
            DropIndex("dbo.StoreDetails", new[] { "MedicineId" });
            DropIndex("dbo.StoreDetails", new[] { "MedicineStoreId" });
            DropIndex("dbo.Thanas", new[] { "DistrictId" });
            DropIndex("dbo.PreferedDrugs", new[] { "MedicineId" });
            DropIndex("dbo.PreferedDrugs", new[] { "DiseaseId" });
            DropIndex("dbo.Centers", new[] { "ThanaId" });
            DropTable("dbo.PatientTreatments");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientDiseases");
            DropTable("dbo.StoreDetails");
            DropTable("dbo.MedicineStores");
            DropTable("dbo.Doctors");
            DropTable("dbo.Thanas");
            DropTable("dbo.Districts");
            DropTable("dbo.Medicines");
            DropTable("dbo.PreferedDrugs");
            DropTable("dbo.Diseases");
            DropTable("dbo.Centers");
            DropTable("dbo.CenterLogins");
        }
    }
}
