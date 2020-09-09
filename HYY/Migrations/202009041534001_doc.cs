namespace HYY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Radiographies", "Doctor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Radiographies", "Doctor_Id");
            AddForeignKey("dbo.Radiographies", "Doctor_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Radiographies", "Doctor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Radiographies", "Doctor", c => c.String());
            DropForeignKey("dbo.Radiographies", "Doctor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Radiographies", new[] { "Doctor_Id" });
            DropColumn("dbo.Radiographies", "Doctor_Id");
        }
    }
}
