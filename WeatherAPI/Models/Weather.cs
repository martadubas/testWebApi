using System;
using System.Net;
using System.Web.Script.Serialization;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public async System.Threading.Tasks.Task<object> getWeatherForecatsAsync(string city)
        {
            
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=dfbff8bd48172519b2d4ce7b04359dc7&units=metric";

            var client = new WebClient();
            string content;
            try
            {
                content = await client.DownloadStringTaskAsync(new Uri(url));
                
            }
            catch (Exception ex)
            {

                content = "";
            }
            
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Object>(content);
            return jsonContent;
        }

    }
}