using System.Net;
using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAppBLK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityWeatherController : ControllerBase
    {

        //private readonly IHttpClientFactory _httpClientFactory;

        //private CancellationTokenSource _CancellationToken = new();


        [HttpGet(Name = "CityWeatherController")]
        public async Task<HttpResponseMessage> Get(CancellationToken token)
        {
            var client = new HttpClient();

            //var client = _httpClientFactory.CreateClient();


            const string apiKey = "2a4d176f29584d73ae764117223006";
            var format = "json";
            var city = "London";

            var cityUrl = $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={apiKey}&q={city}&fx=no&cc=no&mca=yes&format={format}";

            var baseUrl = @"https://api.worldweatheronline.com/premium/v1/weather.ashx";


            #region XML maybe?
            //var response = await client.GetAsync(cityUrl);
            //var responseContent = response.Content.ReadAsStream(); //TODO: Async

            //var xml = new XmlSerializer(typeof(CityWeather));
            //var assignmentResult = new CityWeather();
            //xml.Deserialize(responseContent,);
            #endregion XML maybe?



            #region Json maybe?
            var jsonOptions = new System.Text.Json.JsonSerializerOptions();


            var jsonResponse = await client.GetFromJsonAsync<CityWeather>(cityUrl, cancellationToken: token);
            #endregion Json maybe?

            


           


            

            


            bool? haveWeatherBeenFetch15min;

            var responseMessageNotModified = new HttpResponseMessage(HttpStatusCode.NotModified) { Content = new StringContent("NotModified") };
            var responseMessageOk = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Response OK") };


            

            //TODO: add logic here
            if (true)
            {
                return responseMessageOk;
            }
            else
            {
                return responseMessageNotModified;
            }
           

            
        }


        

    }
}