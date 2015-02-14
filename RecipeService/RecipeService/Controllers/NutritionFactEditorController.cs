using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeService.Models;

namespace RecipeService.Controllers
{
    public class NutritionFactEditorController : Controller
    {
        private RecipeServiceContext db = new RecipeServiceContext();

        // GET: /NutritionFactEditor/
        public async Task<ActionResult> Index()
        {
            return View(await db.NutritionFacts.ToListAsync());
        }

        // GET: /NutritionFactEditor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionFact nutritionfact = await db.NutritionFacts.FindAsync(id);
            if (nutritionfact == null)
            {
                return HttpNotFound();
            }
            return View(nutritionfact);
        }

        // GET: /NutritionFactEditor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NutritionFactEditor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NutritionFact nutritionfact)
        {
            if (ModelState.IsValid)
            {
                db.NutritionFacts.Add(nutritionfact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nutritionfact);
        }

        // GET: /NutritionFactEditor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionFact nutritionfact = await db.NutritionFacts.FindAsync(id);
            if (nutritionfact == null)
            {
                return HttpNotFound();
            }
            return View(nutritionfact);
        }

        // POST: /NutritionFactEditor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NutritionFact nutritionfact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutritionfact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nutritionfact);
        }

        // GET: /NutritionFactEditor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionFact nutritionfact = await db.NutritionFacts.FindAsync(id);
            if (nutritionfact == null)
            {
                return HttpNotFound();
            }
            return View(nutritionfact);
        }

        // POST: /NutritionFactEditor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NutritionFact nutritionfact = await db.NutritionFacts.FindAsync(id);
            db.NutritionFacts.Remove(nutritionfact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
