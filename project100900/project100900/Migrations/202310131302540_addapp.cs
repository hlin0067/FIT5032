namespace project100900.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TotalRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "RatingCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RatingCount");
            DropColumn("dbo.AspNetUsers", "TotalRating");
        }
    }
}
