namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelAndSeed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Models", "DistanceMax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "DistanceMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
