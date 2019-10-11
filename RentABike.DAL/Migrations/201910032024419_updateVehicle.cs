namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ChassisNumber", c => c.String());
            AddColumn("dbo.Vehicles", "PlateNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "PlateNumber");
            DropColumn("dbo.Vehicles", "ChassisNumber");
        }
    }
}
