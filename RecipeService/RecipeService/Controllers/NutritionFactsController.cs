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
using System.Web.UI.WebControls;
using RecipeService.Models;
using RecipeService.UnitConverter;
using UnitsNet;

namespace RecipeService.Controllers
{
    [RoutePrefix("api/NutritionFacts")]
    public class NutritionFactsController : ApiController
    {
        private RecipeServiceContext db = new RecipeServiceContext();

        [ResponseType(typeof(NutritionData))]
        public IHttpActionResult GetNutritionData(int factId, double quantity, MeasurementUnit units)
        {
            var nutritionFact = db.NutritionFacts.Find(factId);
            if (nutritionFact == null)
                return NotFound();

            nutritionFact.quantity = Convert.ToDecimal(UnitService.ConvertFromGrams(nutritionFact.quantity, units, nutritionFact.Density));

            var dailyValues = db.DailyValues.Find(1);
            

            return Ok(new NutritionData
            {
                nutritionfacts = new[] { nutritionFact },
                dailyvalues = dailyValues
            });
        }

        // GET api/NutritionFacts
        public IQueryable<NutritionFact> GetNutritionFacts()
        {
            return db.NutritionFacts;
        }

        // GET api/NutritionFacts/5
        [ResponseType(typeof(NutritionFact))]
        public IHttpActionResult GetNutritionFact(int id)
        {
            NutritionFact nutritionfact = db.NutritionFacts.Find(id);
            if (nutritionfact == null)
            {
                return NotFound();
            }

            return Ok(nutritionfact);
        }

        // PUT api/NutritionFacts/5
        public IHttpActionResult PutNutritionFact(int id, NutritionFact nutritionfact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nutritionfact.id)
            {
                return BadRequest();
            }

            db.Entry(nutritionfact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionFactExists(id))
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

        // POST api/NutritionFacts
        [ResponseType(typeof(NutritionFact))]
        public IHttpActionResult PostNutritionFact(NutritionFact nutritionfact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NutritionFacts.Add(nutritionfact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nutritionfact.id }, nutritionfact);
        }

        // DELETE api/NutritionFacts/5
        [ResponseType(typeof(NutritionFact))]
        public IHttpActionResult DeleteNutritionFact(int id)
        {
            NutritionFact nutritionfact = db.NutritionFacts.Find(id);
            if (nutritionfact == null)
            {
                return NotFound();
            }

            db.NutritionFacts.Remove(nutritionfact);
            db.SaveChanges();

            return Ok(nutritionfact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NutritionFactExists(int id)
        {
            return db.NutritionFacts.Count(e => e.id == id) > 0;
        }
    }
}