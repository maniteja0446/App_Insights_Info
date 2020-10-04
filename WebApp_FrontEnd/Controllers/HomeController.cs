using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp_FrontEnd.Models;

namespace WebApp_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://azrg-wa-api.azurewebsites.net/weatherforecast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    weatherForecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(apiResponse);
                }
            }
            return View(weatherForecasts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
