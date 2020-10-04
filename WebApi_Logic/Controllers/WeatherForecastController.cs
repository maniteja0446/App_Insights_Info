using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi_Logic.Model;

namespace WebApi_Logic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Guid guid =  Guid.NewGuid();
            _logger.LogInformation($"Weather Forecast Get Method Executed Successfully : {0} ", guid.ToString());
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();            
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<Static_Data> GetData(int id)
        {
            Guid guid = Guid.NewGuid();
            Static_Data static_Data = null;
            List<Static_Data> static_Datas = null;

            _logger.LogDebug($"Debug {guid.ToString()}");
            _logger.LogInformation($"Debug {guid.ToString()}");
            _logger.LogWarning($"Debug {guid.ToString()}");
            _logger.LogError($"Debug {guid.ToString()}");
            _logger.LogCritical($"Debug {guid.ToString()}");
            try
            {
                static_Datas = new List<Static_Data>();
                for (int i = 0; i < 10; i++)
                {
                    static_Data = new Static_Data();
                    static_Data.Data = "Data";
                    static_Data.Data1 = "Data1";
                    static_Data.Data2 = "Data2";
                    static_Datas.Add(static_Data);
                }
                
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
            }

            return static_Datas;

        }

    }

    
}

