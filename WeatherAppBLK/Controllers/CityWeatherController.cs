using System.Text.Json;
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
        public async Task<string> Get(CancellationToken token)
        {
            var client = new HttpClient();

            //var client = _httpClientFactory.CreateClient();

            var url = @"https://api.worldweatheronline.com/premium/v1/weather.ashx";

            var jsonOptions = new System.Text.Json.JsonSerializerOptions()
            {
                

            };



            var jsonObject = await client.GetFromJsonAsync<CityWeather>(url);




            return "Work in progress";
        }


        

    }
}