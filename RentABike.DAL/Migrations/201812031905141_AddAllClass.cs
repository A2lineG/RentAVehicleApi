namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeCoefficients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartAge = c.DateTime(nullable: false),
                        EndAge = c.DateTime(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        PeriodCoefficientId = c.Guid(nullable: false),
                        AgeCoefficientId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeCoefficients", t => t.AgeCoefficientId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.PeriodCoefficients", t => t.PeriodCoefficientId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.PeriodCoefficientId)
                .Index(t => t.AgeCoefficientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Surname = c.String(),
                        FirstName = c.String(),
                        DriverLicenseNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Opinions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Year = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mileage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModelId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.PeriodCoefficients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionBookingBookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BookingId = c.Guid(nullable: false),
                        OptionBookingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.OptionBookings", t => t.OptionBookingId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.OptionBookingId);
            
            CreateTable(
                "dbo.OptionBookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsFixedPrice = c.Boolean(nullable: false),
                        PriceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionVehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OptionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptionVehicleVehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        OptionVehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptionVehicles", t => t.OptionVehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.OptionVehicleId);
            
            AddColumn("dbo.Models", "DistanceMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptionVehicleVehicles", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.OptionVehicleVehicles", "OptionVehicleId", "dbo.OptionVehicles");
            DropForeignKey("dbo.OptionBookingBookings", "OptionBookingId", "dbo.OptionBookings");
            DropForeignKey("dbo.OptionBookingBookings", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Bookings", "PeriodCoefficientId", "dbo.PeriodCoefficients");
            DropForeignKey("dbo.Bookings", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Opinions", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Opinions", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "AgeCoefficientId", "dbo.AgeCoefficients");
            DropIndex("dbo.OptionVehicleVehicles", new[] { "OptionVehicleId" });
            DropIndex("dbo.OptionVehicleVehicles", new[] { "VehicleId" });
            DropIndex("dbo.OptionBookingBookings", new[] { "OptionBookingId" });
            DropIndex("dbo.OptionBookingBookings", new[] { "BookingId" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropIndex("dbo.Opinions", new[] { "VehicleId" });
            DropIndex("dbo.Opinions", new[] { "ClientId" });
            DropIndex("dbo.Bookings", new[] { "ClientId" });
            DropIndex("dbo.Bookings", new[] { "AgeCoefficientId" });
            DropIndex("dbo.Bookings", new[] { "PeriodCoefficientId" });
            DropIndex("dbo.Bookings", new[] { "VehicleId" });
            DropColumn("dbo.Models", "DistanceMax");
            DropTable("dbo.OptionVehicleVehicles");
            DropTable("dbo.OptionVehicles");
            DropTable("dbo.OptionBookings");
            DropTable("dbo.OptionBookingBookings");
            DropTable("dbo.PeriodCoefficients");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Opinions");
            DropTable("dbo.Clients");
            DropTable("dbo.Bookings");
            DropTable("dbo.AgeCoefficients");
        }
    }
}
