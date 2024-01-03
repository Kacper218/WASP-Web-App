using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Auth model)
        {
            try
            {
                string authData = await _apiClient.GetLoginInfo(model);
                ViewData["AuthData"] = authData;

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blad fetchowania");
                return RedirectToAction(nameof(Index));
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
