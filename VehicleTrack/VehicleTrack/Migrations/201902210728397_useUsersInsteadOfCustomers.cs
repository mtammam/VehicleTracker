namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useUsersInsteadOfCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Vehicles", "ApplicationUserId");
            AddForeignKey("dbo.Vehicles", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Vehicles", new[] { "ApplicationUserId" });
            DropColumn("dbo.Vehicles", "ApplicationUserId");
        }
    }
}
