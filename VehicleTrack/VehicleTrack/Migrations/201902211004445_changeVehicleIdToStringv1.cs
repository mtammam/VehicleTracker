namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVehicleIdToStringv1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "VehicelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicelId", c => c.String(nullable: false));
        }
    }
}
