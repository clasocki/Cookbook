using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Cookbook.Models;
using Cookbook.Services;

namespace Cookbook.Controllers
{
    public class RecipesController : Controller
    {
        private RestApiService apiService = new RestApiService();
        private CookbookContext db = new CookbookContext();

        // GET: /Recipes/
        public async Task<ActionResult> Index()
        {
            return View(await db.Recipes.ToListAsync());
        }

        // GET: /Recipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: /Recipes/Create
        public async Task<ActionResult> Create()
        {
            var newRecipe = new Recipe
            {
                ingredients = new List<Ingredient>(),
                content = new List<RecipeSection>()
            };
            return View(newRecipe);
        }

        public async Task<ActionResult> BlankRecipeSection()
        {
            return PartialView("RecipeSectionRow", new RecipeSection());
        }

        public async Task<ActionResult> BlankIngredientRow()
        {
            await PopulateIngredientsDropDownList();

            return PartialView("IngredientEditorRow", new Ingredient());
        }

        private async Task PopulateIngredientsDropDownList(object selectedIngredient = null)
        {
            var nutritionFacts = await apiService.Get<List<NutritionFact>>("api/NutritionFacts/");
            ViewBag.NutritionFactId = new SelectList(nutritionFacts, "id", "foodname", selectedIngredient);
            TempData["nutritionFacts"] = nutritionFacts;
        }

        private void UpdateIngredients(Recipe recipe)
        {
            var nutritionFacts = (List<NutritionFact>)TempData["nutritionFacts"];

            foreach (var ingredient in recipe.ingredients)
                ingredient.name = nutritionFacts.First(x => x.id == ingredient.NutritionFactId).foodname;
        }

        // POST: /Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                UpdateIngredients(recipe);

                var response = await apiService.Post("api/Recipe", recipe);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                return RedirectToAction("Index", "Home");
            }

            await PopulateIngredientsDropDownList();
            return View(recipe);
        }

        // GET: /Recipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = await apiService.Get<Recipe>(string.Format("api/Recipes/{0}", id));
            if (recipe == null)
            {
                return HttpNotFound();
            }

            await PopulateIngredientsDropDownList();
            return View(recipe);
        }

        // POST: /Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                UpdateIngredients(recipe);

                var response = await apiService.Put(string.Format("api/Recipe/{0}", recipe.id), recipe);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                return RedirectToAction("Index", "Home");
            }

            await PopulateIngredientsDropDownList();
            return View(recipe);
        }

        // GET: /Recipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = await apiService.Get<Recipe>(string.Format("api/Recipes/{0}", id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: /Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await apiService.Delete(string.Format("api/Recipe/{0}", id));
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
