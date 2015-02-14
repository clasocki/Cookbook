using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Cookbook.Services
{
    public class RestApiService
    {
        private const string RestServiceUri = "http://localhost:19079/";

        public async Task<T> Get<T>(string method)
        {
            var response = await CallRestApiGetAsync(method);

            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>
                    {
                        new XmlMediaTypeFormatter
                        {
                            UseXmlSerializer = true
                        }
                    };
                var recipes = await response.Content.ReadAsAsync<T>(formatters);
                return recipes;
            }

            throw new Exception("Unsuccessful rest api response");
        }

        public async Task<HttpResponseMessage> Post<T>(string requestUri, T postedObject)
        {
            using (var recipeClient = new HttpClient())
            {
                recipeClient.BaseAddress = new Uri(RestServiceUri);

                var formatter = new XmlMediaTypeFormatter
                {
                    UseXmlSerializer = true
                };

                var response = await recipeClient.PostAsync(requestUri, postedObject, formatter);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Put<T>(string requestUri, T postedObject)
        {
            using (var recipeClient = new HttpClient())
            {
                recipeClient.BaseAddress = new Uri(RestServiceUri);

                var formatter = new XmlMediaTypeFormatter
                {
                    UseXmlSerializer = true
                };

                var response = await recipeClient.PutAsync(requestUri, postedObject, formatter);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Delete(string requestUri)
        {
            using (var recipeClient = new HttpClient())
            {
                recipeClient.BaseAddress = new Uri(RestServiceUri);

                var response = await recipeClient.DeleteAsync(requestUri);
                return response;
            }
        }

        public async Task<HttpResponseMessage> CallRestApiGetAsync(string method)
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
    }
}