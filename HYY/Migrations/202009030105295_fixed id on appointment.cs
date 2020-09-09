namespace HYY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedidonappointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Radiographies", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Radiographies", new[] { "Appointment_Id" });
            AddColumn("dbo.Radiographies", "Appointment", c => c.Int(nullable: false));
            DropColumn("dbo.Radiographies", "Appointment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Radiographies", "Appointment_Id", c => c.Int());
            DropColumn("dbo.Radiographies", "Appointment");
            CreateIndex("dbo.Radiographies", "Appointment_Id");
            AddForeignKey("dbo.Radiographies", "Appointment_Id", "dbo.Appointments", "Id");
        }
    }
}
