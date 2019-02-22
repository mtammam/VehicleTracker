namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVehicleIdToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vehicles");
            AddColumn("dbo.Vehicles", "VIN", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Vehicles");
            AlterColumn("dbo.Vehicles", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Vehicles", "VIN");
            AddPrimaryKey("dbo.Vehicles", "Id");
        }
    }
}
