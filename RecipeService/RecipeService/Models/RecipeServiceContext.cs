using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeService.Models
{
    public class RecipeServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecipeServiceContext() : base("name=RecipeServiceContext")
        {
            Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<NutritionFact> NutritionFacts { get; set; }
        public DbSet<RecipeSection> RecipeSections { get; set; }
        public DbSet<DailyValues> DailyValues { get; set; } 
    
    }
}
