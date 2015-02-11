namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VitaminsProteinsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DailyValues", "proteins_units");
            DropColumn("dbo.DailyValues", "proteins_Value");
            DropColumn("dbo.DailyValues", "vitamins_A");
            DropColumn("dbo.DailyValues", "vitamins_C");
            DropColumn("dbo.DailyValues", "vitamins_D");
            DropColumn("dbo.DailyValues", "vitamins_E");
            DropColumn("dbo.DailyValues", "vitamins_units");
            DropColumn("dbo.NutritionFacts", "proteins_units");
            DropColumn("dbo.NutritionFacts", "proteins_Value");
            DropColumn("dbo.NutritionFacts", "vitamins_A");
            DropColumn("dbo.NutritionFacts", "vitamins_C");
            DropColumn("dbo.NutritionFacts", "vitamins_D");
            DropColumn("dbo.NutritionFacts", "vitamins_E");
            DropColumn("dbo.NutritionFacts", "vitamins_units");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NutritionFacts", "vitamins_units", c => c.Int(nullable: false));
            AddColumn("dbo.NutritionFacts", "vitamins_E", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NutritionFacts", "vitamins_D", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NutritionFacts", "vitamins_C", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NutritionFacts", "vitamins_A", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NutritionFacts", "proteins_Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NutritionFacts", "proteins_units", c => c.Int(nullable: false));
            AddColumn("dbo.DailyValues", "vitamins_units", c => c.Int(nullable: false));
            AddColumn("dbo.DailyValues", "vitamins_E", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyValues", "vitamins_D", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyValues", "vitamins_C", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyValues", "vitamins_A", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyValues", "proteins_Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyValues", "proteins_units", c => c.Int(nullable: false));
        }
    }
}
