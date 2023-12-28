using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WASP_Web_App.Models;

namespace WASP_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;     
        private readonly ApiClient _apiClient;
 
        public HomeController(ILogger<HomeController> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                string weatherData = await _apiClient.GetWeatherForecastAsync();

                _logger.LogInformation("Pogoda git: {WeatherData}", weatherData);
                Console.WriteLine("test" + weatherData);
                Console.WriteLine("asdasd");

                // Process weatherData or pass it to the view

                ViewData["WeatherData"] = weatherData;

                return View();

            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Blad fetchowania");
                return View();
            }
        }
    }
}

