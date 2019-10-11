namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOptionPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OptionVehicles", "OptionPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OptionVehicles", "OptionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
