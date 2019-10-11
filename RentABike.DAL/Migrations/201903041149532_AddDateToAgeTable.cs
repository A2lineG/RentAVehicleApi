namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToAgeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgeCoefficients", "StartAge", c => c.Int(nullable: false));
            AddColumn("dbo.AgeCoefficients", "EndAge", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgeCoefficients", "EndAge");
            DropColumn("dbo.AgeCoefficients", "StartAge");
        }
    }
}
