using Microsoft.AspNetCore.Mvc;

namespace WASP_Web_App.Controllers
{
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
