namespace CommunityMedicine.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patienttreatmentupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientTreatments", "TreatmentCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientTreatments", "TreatmentCode");
        }
    }
}
