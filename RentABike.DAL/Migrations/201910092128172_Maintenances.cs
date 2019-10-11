namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maintenances : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maintenances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Comment = c.String(),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maintenances", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Maintenances", new[] { "VehicleId" });
            DropTable("dbo.Maintenances");
        }
    }
}
