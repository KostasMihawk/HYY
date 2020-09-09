namespace HYY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Radiographies", "Appointment_Id", c => c.Int());
            AddColumn("dbo.Radiographies", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Radiographies", "Appointment_Id");
            CreateIndex("dbo.Radiographies", "Patient_Id");
            AddForeignKey("dbo.Radiographies", "Appointment_Id", "dbo.Appointments", "Id");
            AddForeignKey("dbo.Radiographies", "Patient_Id", "dbo.Patients", "Id");
            DropColumn("dbo.Radiographies", "Appointment");
            DropColumn("dbo.Radiographies", "Patient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Radiographies", "Patient", c => c.Int(nullable: false));
            AddColumn("dbo.Radiographies", "Appointment", c => c.Int(nullable: false));
            DropForeignKey("dbo.Radiographies", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Radiographies", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Radiographies", new[] { "Patient_Id" });
            DropIndex("dbo.Radiographies", new[] { "Appointment_Id" });
            DropColumn("dbo.Radiographies", "Patient_Id");
            DropColumn("dbo.Radiographies", "Appointment_Id");
        }
    }
}
