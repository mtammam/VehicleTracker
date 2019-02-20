namespace VehicleTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerInhirtesFromUserIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "CustomerId" });
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "PasswordHash", c => c.String());
            AddColumn("dbo.Customers", "SecurityStamp", c => c.String());
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AddColumn("dbo.Customers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Customers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "UserName", c => c.String());
            AddColumn("dbo.AspNetUserRoles", "Customer_Id", c => c.Int());
            AddColumn("dbo.AspNetUserClaims", "Customer_Id", c => c.Int());
            AddColumn("dbo.AspNetUserLogins", "Customer_Id", c => c.Int());
            AddColumn("dbo.Vehicles", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Vehicles", "CustomerId", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUserClaims", "Customer_Id");
            CreateIndex("dbo.AspNetUserLogins", "Customer_Id");
            CreateIndex("dbo.AspNetUserRoles", "Customer_Id");
            CreateIndex("dbo.Vehicles", "Customer_Id");
            AddForeignKey("dbo.AspNetUserClaims", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserLogins", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserClaims", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Customer_Id" });
            AlterColumn("dbo.Vehicles", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "Customer_Id");
            DropColumn("dbo.AspNetUserLogins", "Customer_Id");
            DropColumn("dbo.AspNetUserClaims", "Customer_Id");
            DropColumn("dbo.AspNetUserRoles", "Customer_Id");
            DropColumn("dbo.Customers", "UserName");
            DropColumn("dbo.Customers", "AccessFailedCount");
            DropColumn("dbo.Customers", "LockoutEnabled");
            DropColumn("dbo.Customers", "LockoutEndDateUtc");
            DropColumn("dbo.Customers", "TwoFactorEnabled");
            DropColumn("dbo.Customers", "PhoneNumberConfirmed");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "SecurityStamp");
            DropColumn("dbo.Customers", "PasswordHash");
            DropColumn("dbo.Customers", "EmailConfirmed");
            DropColumn("dbo.Customers", "Email");
            CreateIndex("dbo.Vehicles", "CustomerId");
            AddForeignKey("dbo.Vehicles", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
