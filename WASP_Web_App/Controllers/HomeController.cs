using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WASP_Web_App.Entities;
using WASP_Web_App.Models;

namespace WASP_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiClient _apiClient;
        private readonly PasswordHasher<Auth> _passwordHasher;

        public HomeController(ILogger<HomeController> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
            _passwordHasher = new PasswordHasher<Auth>();
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                Auth Karol = new Auth
                {
                    Login = "Benek",
                    Password = "sianosiano",
                    User_ID = 0
                };
                ////password hashing here
                //var hashedPassword = _passwordHasher.HashPassword(Karol, Karol.Password);
                //Karol.Password = hashedPassword;
                string authData = await _apiClient.GetLoginInfo(Karol);
                Console.WriteLine("HASLO TU: {0}", Karol.Password);
                _logger.LogInformation("Karol git: {AuthData}", authData);

                // Process weatherData or pass it to the view

                ViewData["AuthData"] = authData;

                return View();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blad fetchowania");
                return View();
            }

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
