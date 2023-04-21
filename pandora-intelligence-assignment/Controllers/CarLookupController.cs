using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net;

namespace pandora_intelligence_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarLookupController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CarLookupController> _logger;

        public CarLookupController(ILogger<CarLookupController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ContentResult?> Get(string? partialPlateNumber = null, string? brand = null, string? type = null)
        {
            string apiBaseUrl = "https://opendata.rdw.nl/resource/m9d7-ebf2.json";
            List<string> queryList = new List<string>();
            if (partialPlateNumber != null) queryList.Add($"$where=kenteken like '%25{partialPlateNumber}%25'");
            if (brand != null) queryList.Add($"merk={brand}");
            if (type != null) queryList.Add($"voertuigsoort={type}");
            string fullQuery = string.Join("&", queryList.ToArray());
            Console.WriteLine(queryList.Count);
            Console.WriteLine(fullQuery.Length);
            Console.WriteLine(fullQuery);
            if (fullQuery.Length == 0) return Content("No arguments provided"); ;
            using (HttpClient client = new HttpClient())
            {
                string fullUrl = apiBaseUrl + "?" + fullQuery;
                Console.WriteLine(fullUrl);
                try
                {
                    HttpResponseMessage response = client.GetAsync(fullUrl).Result;
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(responseBody);
                    return Content(responseBody, "application/json");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}