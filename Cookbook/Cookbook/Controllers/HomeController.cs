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
using Cookbook.Models;
using Fonet;
using Saxon;
using Saxon.Api;
using Recipe = Cookbook.Models.Recipe;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        private const string RestServiceUri = "http://localhost:19079/";
        public async Task<ActionResult> Index()
        {
            var nutritionData = new XmlDocument();
            nutritionData.Load(Server.MapPath("~/App_Data/nutritionFacts.xml"));

            var response = await CallRestApiAsync("api/Recipes");

            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>
                    {
                        new XmlMediaTypeFormatter
                        {
                            UseXmlSerializer = true
                        }
                    };
                var recipes = await response.Content.ReadAsAsync<Recipes>(formatters);
                return View(recipes.recipe);
            }

            //var xmlSerializer = new XmlSerializer(typeof(Recipes));
            //var recipes = (Recipes)xmlSerializer.Deserialize(new StreamReader(Server.MapPath("~/App_Data/recipes.xml")));

            return HttpNotFound();
        }

        private string Transform(string xmlString, string xsltPath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            using (var stream = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto }))
                {
                    var xslTransform = new XslCompiledTransform();
                    xslTransform.Load(xsltPath);
                    xslTransform.Transform(xmlDocument, xmlWriter);
                }

                return stream.ToString();
            }
        }

        private string Transform(string xmlString, string xsltPath, List<KeyValuePair<string, object>> xsltArgs)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            var argList = new XsltArgumentList();

            xsltArgs.ForEach(argPair => argList.AddParam(argPair.Key, "", argPair.Value));

            using (var stream = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto }))
                {
                    var xslTransform = new XslCompiledTransform();
                    xslTransform.Load(xsltPath);
                    xslTransform.Transform(xmlDocument, argList, xmlWriter);
                }

                return stream.ToString();
            }
        }

        private async Task<HttpResponseMessage> CallRestApiAsync(string method)
        {
            using (var recipeClient = new HttpClient())
            {
                recipeClient.BaseAddress = new Uri(RestServiceUri);
                recipeClient.DefaultRequestHeaders.Accept.Clear();
                recipeClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await recipeClient.GetAsync(method);

                return response;
            }
        }

        public async Task<string> LoadNutritionFactHtml(int factId, double quantity, MeasurementUnit units)
        {
            var response =
                await
                    CallRestApiAsync(string.Format("api/NutritionFacts?factId={0}&quantity={1}&units={2}", factId,
                        quantity, units));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var argList = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("quantity", quantity)
                };
                var xsltDocPath = Server.MapPath("~/App_Data/nutritionFact.xsl");

                return Transform(responseContent, xsltDocPath, argList);
            }

            return "";
        }

        public async Task<string> LoadRecipeSummaryHtml(int recipeId)
        {
            var response =
                await
                    CallRestApiAsync(string.Format("api/Recipes/summary/{0}", recipeId));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var xsltDocPath = Server.MapPath("~/App_Data/recipeSummary.xsl");

                return Transform(responseContent, xsltDocPath);
            }

            return "";
        }

        public async Task DownloadRecipePdf(int recipeId)
        {
            var response = await CallRestApiAsync(string.Format("api/Recipes/{0}", recipeId));

            if (!response.IsSuccessStatusCode) return;

            var recipeXml = await response.Content.ReadAsStringAsync();

            var xsltDocPath = Server.MapPath("~/App_Data/printableRecipe.xsl");
            var printableRecipe = Transform(recipeXml, xsltDocPath);

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