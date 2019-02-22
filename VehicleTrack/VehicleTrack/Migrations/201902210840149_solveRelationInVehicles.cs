namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solveRelationInVehicles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Vehicles", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Vehicles", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vehicles", "ApplicationUserID");
            AddForeignKey("dbo.Vehicles", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Vehicles", new[] { "ApplicationUserID" });
            AlterColumn("dbo.Vehicles", "ApplicationUserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Vehicles", "ApplicationUserId");
            AddForeignKey("dbo.Vehicles", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
