namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDecimalToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "Mileage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Mileage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicles", "Year", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
