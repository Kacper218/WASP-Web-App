using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WASP_Web_App.Models;

namespace WASP_Web_App.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        
        private readonly ApiClient _apiClient;

        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        public HomeController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Weather()
        {
            string weatherData = await _apiClient.GetWeatherForecastAsync();
            // Process weatherData or pass it to the view

            ViewData["WeatherData"] = weatherData;

            return View();

        }
    }
}

