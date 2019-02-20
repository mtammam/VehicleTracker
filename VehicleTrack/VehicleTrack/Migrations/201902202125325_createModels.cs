namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicelId = c.String(nullable: false),
                        RegNo = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "CustomerId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
        }
    }
}
