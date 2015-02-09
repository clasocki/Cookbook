namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurementUnit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredients", "units", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredients", "units", c => c.String());
        }
    }
}
