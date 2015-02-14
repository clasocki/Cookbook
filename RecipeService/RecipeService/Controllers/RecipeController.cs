using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RecipeService.Models;
using WebGrease.Css.Extensions;

namespace RecipeService.Controllers
{
    [RoutePrefix("api/Recipes")]
    public class RecipeController : ApiController
    {
        private RecipeServiceContext db = new RecipeServiceContext();

        [Route("")]
        // GET api/Recipe
        public Recipes GetRecipeList()
        {
            var recipes = db.Recipes
                .Include(x => x.ingredients)
                .Include(x => x.content)
                .Include(x => x.ingredients)
                .ToArray();

            return new Recipes {recipe = recipes};
        }

        [Route("summary/{recipeId:int}")]
        [ResponseType(typeof(RecipeSummary))]
        public IHttpActionResult GetRecipeSummary(int recipeId)
        {
            var recipe = db.Recipes
                .Include(x => x.ingredients)
                .Include(x => x.content)
                .Include(x => x.ingredients)
                .Include(x => x.ingredients.Select(y => y.NutritionFact))
                .SingleOrDefault(x => x.id == recipeId);

            if (recipe == null)
                return NotFound();

            var ingredients = recipe.ingredients;
            var nutritionFacts = ingredients.Select(x => x.NutritionFact).ToList();

            var dailyValues = db.DailyValues.Find(1);

            return Ok(new RecipeSummary
            {
                Ingredients = ingredients,
                NutritionFacts = nutritionFacts,
                DailyValues = dailyValues
            });
        }

        // GET api/Recipes/5
        [Route("{id:int}")]
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult GetRecipe(int id)
        {
            var recipe = db.Recipes
                .Include(x => x.ingredients)
                .Include(x => x.content)
                .Include(x => x.ingredients)
                .SingleOrDefault(x => x.id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT api/Recipe/5
        public IHttpActionResult PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.id)
            {
                return BadRequest();
            }

            var context = ((IObjectContextAdapter)db).ObjectContext;

            db.Ingredients.ForEach(i =>
            {
                if (!recipe.ingredients.Any(x => x.id == i.id))
                    db.Ingredients.Remove(i);
                else
                    context.Detach(i);
            });

            

            db.RecipeSections.ForEach(section =>
            {
                if (!recipe.content.Any(x => x.id == section.id))
                    db.RecipeSections.Remove(section);
                else
                    context.Detach(section);
            });

            recipe.ingredients.ForEach(i =>
            {
                if (i.id == 0)
                    db.Ingredients.Add(i);
                else
                    db.Entry(i).State = EntityState.Modified;
            });
            recipe.content.ForEach(section =>
            {
                if (section.id == 0)
                    db.RecipeSections.Add(section);
                else
                    db.Entry(section).State = EntityState.Modified;
            });

            db.Entry(recipe).State = EntityState.Modified;
            
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Recipe
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecipeExists(recipe.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = recipe.id }, recipe);
        }

        // DELETE api/Recipe/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(string id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.id == id) > 0;
        }
    }
}