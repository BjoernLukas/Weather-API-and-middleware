using Microsoft.AspNetCore.Mvc;

namespace WeatherAppBLK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        
        [HttpGet(Name = "DummyController")]
        public int Get()
        {



            return 42;
        }


      

    }
}