namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCoefficients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "AgeCoefficientId", "dbo.AgeCoefficients");
            DropForeignKey("dbo.Bookings", "PeriodCoefficientId", "dbo.PeriodCoefficients");
            DropIndex("dbo.Bookings", new[] { "PeriodCoefficientId" });
            DropIndex("dbo.Bookings", new[] { "AgeCoefficientId" });
            AlterColumn("dbo.Bookings", "PeriodCoefficientId", c => c.Guid());
            AlterColumn("dbo.Bookings", "AgeCoefficientId", c => c.Guid());
            CreateIndex("dbo.Bookings", "PeriodCoefficientId");
            CreateIndex("dbo.Bookings", "AgeCoefficientId");
            AddForeignKey("dbo.Bookings", "AgeCoefficientId", "dbo.AgeCoefficients", "Id");
            AddForeignKey("dbo.Bookings", "PeriodCoefficientId", "dbo.PeriodCoefficients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PeriodCoefficientId", "dbo.PeriodCoefficients");
            DropForeignKey("dbo.Bookings", "AgeCoefficientId", "dbo.AgeCoefficients");
            DropIndex("dbo.Bookings", new[] { "AgeCoefficientId" });
            DropIndex("dbo.Bookings", new[] { "PeriodCoefficientId" });
            AlterColumn("dbo.Bookings", "AgeCoefficientId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Bookings", "PeriodCoefficientId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Bookings", "AgeCoefficientId");
            CreateIndex("dbo.Bookings", "PeriodCoefficientId");
            AddForeignKey("dbo.Bookings", "PeriodCoefficientId", "dbo.PeriodCoefficients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "AgeCoefficientId", "dbo.AgeCoefficients", "Id", cascadeDelete: true);
        }
    }
}
