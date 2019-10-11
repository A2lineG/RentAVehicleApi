namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteYearColumnFromModelTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Models", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Year", c => c.DateTime());
        }
    }
}
