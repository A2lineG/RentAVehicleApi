namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBrandModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Displacement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncreasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DistanceMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
