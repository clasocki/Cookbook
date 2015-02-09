namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NutritionFacts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NutritionFacts", "units", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NutritionFacts", "units", c => c.String());
        }
    }
}
