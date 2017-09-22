using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public async Task<JsonResult> GetWeather(string city)
        {
            Weather weather = new Weather();


            return Json(await weather.getWeatherForecatsAsync(city), JsonRequestBehavior.AllowGet);
        }


        
        public async Task<string> GetPhotoObject(string city)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d71da69c889d4cb3bebf45094dd10735");

            // Request parameters
            queryString["q"] = city;
            queryString["count"] = "1";
            queryString["offset"] = "0";
            queryString["mkt"] = "en-us";
            queryString["safeSearch"] = "Moderate";
            queryString["imageType"] = "Photo";
            //queryString["width"] = "10";
            //queryString["height"] = "20";
            queryString["size"] = "medium";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?" + queryString;
            var result = string.Empty;

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }


            var jsonContent = JsonConvert.DeserializeObject<RootObject>(result);

            
            
            return jsonContent.value.FirstOrDefault().contentUrl;
        }


    }


    public class Instrumentation
    {
        public string pageLoadPingUrl { get; set; }
    }

    public class Thumbnail
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class InsightsSourcesSummary
    {
        public int shoppingSourcesCount { get; set; }
        public int recipeSourcesCount { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string webSearchUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public DateTime datePublished { get; set; }
        public string contentUrl { get; set; }
        public string hostPageUrl { get; set; }
        public string contentSize { get; set; }
        public string encodingFormat { get; set; }
        public string hostPageDisplayUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string imageInsightsToken { get; set; }
        public InsightsSourcesSummary insightsSourcesSummary { get; set; }
        public string imageId { get; set; }
        public string accentColor { get; set; }
    }

    public class Thumbnail2
    {
        public string thumbnailUrl { get; set; }
    }

    public class QueryExpansion
    {
        public string text { get; set; }
        public string displayText { get; set; }
        public string webSearchUrl { get; set; }
        public string searchLink { get; set; }
        public Thumbnail2 thumbnail { get; set; }
    }

    public class Thumbnail3
    {
        public string thumbnailUrl { get; set; }
    }

    public class Suggestion
    {
        public string text { get; set; }
        public string displayText { get; set; }
        public string webSearchUrl { get; set; }
        public string searchLink { get; set; }
        public Thumbnail3 thumbnail { get; set; }
    }

    public class PivotSuggestion
    {
        public string pivot { get; set; }
        public List<Suggestion> suggestions { get; set; }
    }

    public class RootObject
    {
        public string _type { get; set; }
        public Instrumentation instrumentation { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<Value> value { get; set; }
        public List<QueryExpansion> queryExpansions { get; set; }
        public int nextOffsetAddCount { get; set; }
        public List<PivotSuggestion> pivotSuggestions { get; set; }
        public bool displayShoppingSourcesBadges { get; set; }
        public bool displayRecipeSourcesBadges { get; set; }
    }
}