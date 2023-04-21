using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net;

namespace pandora_intelligence_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarLookupController : ControllerBase
    {

        private readonly ILogger<CarLookupController> _logger;
        private const string apiBaseUrl = "https://opendata.rdw.nl/resource/m9d7-ebf2.json";

        public CarLookupController(ILogger<CarLookupController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ContentResult> Get(string? partialPlateNumber = null, string? brand = null, string? type = null)
        {
            List<string> queryList = new List<string>();
            if (partialPlateNumber != null) queryList.Add($"$where=kenteken like '%25{partialPlateNumber}%25'");
            if (brand != null) queryList.Add($"merk={brand}");
            if (type != null) queryList.Add($"voertuigsoort={type}");
            string fullQuery = string.Join("&", queryList.ToArray());
            Console.WriteLine(queryList.Count);
            Console.WriteLine(fullQuery.Length);
            Console.WriteLine(fullQuery);
            if (fullQuery.Length == 0) return Content("No arguments provided");
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
                    var errorResult = Content("Something went wrong");
                    errorResult.StatusCode = 400;
                    return errorResult;
                }
            }
        }
    }
}