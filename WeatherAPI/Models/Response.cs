using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class Response
    {
        public string photoUrl { get; set; }
        public string photoId { get; set; }
        public int weatherId { get; set; }
        public string weatherName { get; set; }
        public int weatherTemp { get; set; }
        public double weatherWindSpeed { get; set; }


        public async Task<Response> GetResponse(string city)
        {
            var client = new HttpClient();
           
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d71da69c889d4cb3bebf45094dd10735");
            // Request parameters
            var queryString = BuildQueryString(city);

            var uriPhoto = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?" + queryString;
            var resultPhoto = string.Empty;

            var responsePhoto = await client.GetAsync(uriPhoto);
             
            //resultPhotoObject.value.FirstOrDefault.photoId
            //var jsonContent = JsonConvert.DeserializeObject<RootPhotoObject>(result);
            //return jsonContent.value.FirstOrDefault().contentUrl;
            
            dynamic uriWeather = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=dfbff8bd48172519b2d4ce7b04359dc7&units=metric";
            var resultWeather = string.Empty;

            var responseWeather = await client.GetAsync(uriWeather);
            if (responseWeather.IsSuccessStatusCode && responsePhoto.IsSuccessStatusCode)
            {
                responseWeather = await responseWeather.Content.ReadAsStringAsync();
                responsePhoto = await responsePhoto.Content.ReadAsStringAsync();
            }

            RootWeatherObject resultWeatherObject = JsonConvert.DeserializeObject<RootWeatherObject>(responseWeather);
            RootPhotoObject resultPhotoObject = JsonConvert.DeserializeObject<RootPhotoObject>(responsePhoto);
           
            return new Response

            {
                photoUrl = resultPhotoObject.value.FirstOrDefault().contentUrl,
                photoId = resultPhotoObject.value.FirstOrDefault().imageId,
                weatherId = resultWeatherObject.id,
                weatherName = resultWeatherObject.name,
                weatherTemp= resultWeatherObject.main.temp,
                weatherWindSpeed = resultWeatherObject.wind.speed
            };

        }

        internal dynamic BuildQueryString(string s)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = s;
            queryString["count"] = "1";
            queryString["offset"] = "0";
            queryString["mkt"] = "en-us";
            queryString["safeSearch"] = "Moderate";
            queryString["size"] = "medium";

            return queryString;
        }
        
    }


    public class InstrumentationPhoto
    {
        public string pageLoadPingUrl { get; set; }
    }

    public class ThumbnailPhoto
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class InsightsSourcesSummaryPhoto
    {
        public int shoppingSourcesCount { get; set; }
        public int recipeSourcesCount { get; set; }
    }

    public class ValuePhoto
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
        public ThumbnailPhoto thumbnail { get; set; }
        public string imageInsightsToken { get; set; }
        public InsightsSourcesSummaryPhoto insightsSourcesSummary { get; set; }
        public string imageId { get; set; }
        public string accentColor { get; set; }
    }

    public class Thumbnail2Photo
    {
        public string thumbnailUrl { get; set; }
    }

    public class QueryExpansionPhoto
    {
        public string text { get; set; }
        public string displayText { get; set; }
        public string webSearchUrl { get; set; }
        public string searchLink { get; set; }
        public Thumbnail2Photo thumbnail { get; set; }
    }

    public class Thumbnail3Photo
    {
        public string thumbnailUrl { get; set; }
    }

    public class SuggestionPhoto
    {
        public string text { get; set; }
        public string displayText { get; set; }
        public string webSearchUrl { get; set; }
        public string searchLink { get; set; }
        public Thumbnail3Photo thumbnail { get; set; }
    }

    public class PivotSuggestionPhoto
    {
        public string pivot { get; set; }
        public List<SuggestionPhoto> suggestions { get; set; }
    }

    public class RootPhotoObject
    {
        public string _type { get; set; }
        public InstrumentationPhoto instrumentation { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<ValuePhoto> value { get; set; }
        public List<QueryExpansionPhoto> queryExpansions { get; set; }
        public int nextOffsetAddCount { get; set; }
        public List<PivotSuggestionPhoto> pivotSuggestions { get; set; }
        public bool displayShoppingSourcesBadges { get; set; }
        public bool displayRecipeSourcesBadges { get; set; }
    }

    public class CoordWeather
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class WeatherObject
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MainWeather
    {
        public int temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int temp_min { get; set; }
        public int temp_max { get; set; }
    }

    public class WindWeather
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class CloudsWeather
    {
        public int all { get; set; }
    }

    public class SysWeather
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootWeatherObject
    {
        public CoordWeather coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public MainWeather main { get; set; }
        public int visibility { get; set; }
        public WindWeather wind { get; set; }
        public CloudsWeather clouds { get; set; }
        public int dt { get; set; }
        public SysWeather sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

}