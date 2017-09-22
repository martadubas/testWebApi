using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using static Google.Apis.Services.BaseClientService;

namespace WeatherAPI.Models
{
    public class Photo
    {
 
        //public async Task<JsonResult> GetPhotoObject(string city)
        //{
        //    var client = new HttpClient();
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    // Request headers
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d71da69c889d4cb3bebf45094dd10735");

        //    // Request parameters
        //    queryString["q"] = city;
        //    queryString["count"] = "1";
        //    queryString["offset"] = "0";
        //    queryString["mkt"] = "en-us";
        //    queryString["safeSearch"] = "Moderate";
        //    var uri = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?" + queryString;
        //    var result = string.Empty;

        //    var response = await client.GetAsync(uri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsStringAsync();
        //    }
        //    return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result));
        //}

    
        }
    }


