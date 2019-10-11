namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStatusStrinInBooking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Status", c => c.Boolean(nullable: false));
        }
    }
}
