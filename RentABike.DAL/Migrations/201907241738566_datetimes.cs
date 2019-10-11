namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Bookings", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PeriodCoefficients", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PeriodCoefficients", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PeriodCoefficients", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PeriodCoefficients", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
