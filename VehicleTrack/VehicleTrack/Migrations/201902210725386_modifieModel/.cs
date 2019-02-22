namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "Customer_Id" });
            DropColumn("dbo.Vehicles", "CustomerId");
            DropColumn("dbo.Vehicles", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Customer_Id", c => c.Int());
            AddColumn("dbo.Vehicles", "CustomerId", c => c.String(nullable: false));
            CreateIndex("dbo.Vehicles", "Customer_Id");
            AddForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
