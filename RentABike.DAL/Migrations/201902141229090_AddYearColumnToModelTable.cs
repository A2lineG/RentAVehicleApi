namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearColumnToModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Year", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "Year");
        }
    }
}
