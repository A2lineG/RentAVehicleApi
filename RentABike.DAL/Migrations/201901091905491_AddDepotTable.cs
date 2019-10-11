namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepotTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depots",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "DepotId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Bookings", "DepotId");
            AddForeignKey("dbo.Bookings", "DepotId", "dbo.Depots", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "DepotId", "dbo.Depots");
            DropIndex("dbo.Bookings", new[] { "DepotId" });
            DropColumn("dbo.Bookings", "DepotId");
            DropTable("dbo.Depots");
        }
    }
}
