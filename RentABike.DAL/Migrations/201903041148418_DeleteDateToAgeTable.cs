namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateToAgeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AgeCoefficients", "StartAge");
            DropColumn("dbo.AgeCoefficients", "EndAge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AgeCoefficients", "EndAge", c => c.DateTime(nullable: false));
            AddColumn("dbo.AgeCoefficients", "StartAge", c => c.DateTime(nullable: false));
        }
    }
}
