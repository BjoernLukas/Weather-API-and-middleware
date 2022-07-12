using System.Net;
using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using WeatherAppBLK.Middleware;
using WeatherAppBLK.Time;

namespace WeatherAppBLK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentCityWeatherController : ControllerBase
    {

        [HttpGet(Name = "CurrentCityWeatherController")]
        public async Task<HttpResponseMessage> Get(CancellationToken token)
        {


            var client = new HttpClient();
            
            //Parameters for the API call
            const string apiKey = "2a4d176f29584d73ae764117223006";
            const string city = "London";
            const string currentWeather = "yes"; //current weather conditions output
            const string format = "json";
            const string cityUrl = $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={apiKey}&q={city}&cc={currentWeather}&format={format}";

            #region XML maybe?
            //var response = await client.GetAsync(cityUrl);
            //var responseContent = response.Content.ReadAsStream(); 

            //var xml = new XmlSerializer(typeof(CityWeather));
            //var assignmentResult = new CityWeather();
            //xml.Deserialize(responseContent,);
            #endregion XML maybe?

            var jsonResponse = await client.GetFromJsonAsync<Mapping.Rootobject>(cityUrl, cancellationToken: token);
            
            var tempC = jsonResponse?.data.current_condition[0].temp_C;

            Console.WriteLine(LastFetchTime.FetchTime);
            
            return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent($"Temperature is {tempC}")};


        }
    }
}