namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        units = c.String(),
                        NutritionFactId = c.Int(nullable: false),
                        Recipe_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.NutritionFacts", t => t.NutritionFactId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_id)
                .Index(t => t.NutritionFactId)
                .Index(t => t.Recipe_id);
            
            CreateTable(
                "dbo.NutritionFacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        foodname = c.String(),
                        fats_saturatedfat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fats_monounsaturatedfat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fats_polyunsaturatedfat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fats_units = c.Int(nullable: false),
                        calories_fromcarbohydrate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        calories_fromfat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        calories_fromprotein = c.Decimal(nullable: false, precision: 18, scale: 2),
                        calories_units = c.Int(nullable: false),
                        carbohydrates_dietaryfiber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        carbohydrates_sugars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        carbohydrates_units = c.Int(nullable: false),
                        minerals_Calcium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        minerals_Iron = c.Decimal(nullable: false, precision: 18, scale: 2),
                        minerals_Magnesium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        minerals_Potassium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        minerals_Sodium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        minerals_units = c.Int(nullable: false),
                        proteins_units = c.Int(nullable: false),
                        proteins_Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins_A = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins_C = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins_D = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins_E = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins_units = c.Int(nullable: false),
                        quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        units = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        preparationTime_time = c.Decimal(nullable: false, precision: 18, scale: 2),
                        preparationTime_units = c.Int(nullable: false),
                        portions = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RecipeSections",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        SectionText = c.String(),
                        Recipe_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_id)
                .Index(t => t.Recipe_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeSections", "Recipe_id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "NutritionFactId", "dbo.NutritionFacts");
            DropIndex("dbo.Ingredients", new[] { "Recipe_id" });
            DropIndex("dbo.RecipeSections", new[] { "Recipe_id" });
            DropIndex("dbo.Ingredients", new[] { "NutritionFactId" });
            DropTable("dbo.RecipeSections");
            DropTable("dbo.Recipes");
            DropTable("dbo.NutritionFacts");
            DropTable("dbo.Ingredients");
        }
    }
}
