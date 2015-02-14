using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.WebPages;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using Cookbook.Services;
using Fonet;
using Saxon;
using Saxon.Api;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestApiService _apiService = new RestApiService();
        private readonly XmlService _xmlService = new XmlService();
        public async Task<ActionResult> Index()
        {
            var recipes = await _apiService.Get<Recipes>("api/Recipes");

            return View(recipes.recipe);
        }

        public async Task<string> LoadNutritionFactHtml(int factId, double quantity, MeasurementUnit units)
        {
            var response =
                await
                    _apiService.CallRestApiGetAsync(string.Format("api/NutritionFacts?factId={0}&quantity={1}&units={2}", factId,
                        quantity, units));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var argList = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("quantity", quantity)
                };
                var xsltDocPath = Server.MapPath("~/App_Data/nutritionFact.xsl");

                return _xmlService.Transform(responseContent, xsltDocPath, argList);
            }

            return "";
        }

        public async Task<string> LoadRecipeSummaryHtml(int recipeId)
        {
            var response =
                await
                    _apiService.CallRestApiGetAsync(string.Format("api/Recipes/summary/{0}", recipeId));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var xsltDocPath = Server.MapPath("~/App_Data/recipeSummary.xsl");

                return _xmlService.Transform(responseContent, xsltDocPath);
            }

            return "";
        }

        public async Task DownloadRecipePdf(int recipeId)
        {
            var response = await _apiService.CallRestApiGetAsync(string.Format("api/Recipes/{0}", recipeId));

            if (!response.IsSuccessStatusCode) return;

            var recipeXml = await response.Content.ReadAsStringAsync();

            var xsltDocPath = Server.MapPath("~/App_Data/printableRecipe.xsl");
            var printableRecipe = _xmlService.Transform(recipeXml, xsltDocPath);

            var xslFoDocument = new XmlDocument();
            xslFoDocument.LoadXml(printableRecipe);

            using (var stream = new FileStream(Server.MapPath("~/App_Data/recipe.pdf"), FileMode.Create))
            {
                var pdfConverter = FonetDriver.Make();
                pdfConverter.Render(xslFoDocument, stream);
  
            }

            Response.AppendHeader("Content-Type", "application/octet-stream");
            Response.AppendHeader("Content-Transfer-Encoding", "Binary");
            Response.AppendHeader("Content-Disposition", "attachment; filename=recipe.pdf");

            Response.WriteFile(Server.MapPath("~/App_Data/recipe.pdf"));
            Response.End();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}