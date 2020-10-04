using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace ConsoleApp_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                string url = "https://azrg-wa-api.azurewebsites.net/";
                string Controller = "weatherforecast";
                string message = WeatherAPIGet(url,Controller);
                Console.WriteLine("Your Result" + message);
            }
        }
        private static string WeatherAPIGet(string WebAPI,string Controller)
        {
            var message = string.Empty;
            IEnumerable<WeatherForecast> weatherForecasts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebAPI);
                //HTTP GET
                var responseTask = client.GetAsync(Controller);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<WeatherForecast>>();
                    readTask.Wait();
                    weatherForecasts = readTask.Result;
                    message = "Success";
                }
                else
                {
                    //log response status here..
                    weatherForecasts = Enumerable.Empty<WeatherForecast>();
                    message = "Failed";
                }
            }
            return message;
        }
    }
}
