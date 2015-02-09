namespace RecipeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DailyValues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyValues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DailyValues");
        }
    }
}
