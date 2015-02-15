namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Density : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NutritionFacts", "Density", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NutritionFacts", "Density");
        }
    }
}
