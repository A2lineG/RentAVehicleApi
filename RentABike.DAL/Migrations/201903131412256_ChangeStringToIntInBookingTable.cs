namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStringToIntInBookingTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Number", c => c.String());
        }
    }
}
