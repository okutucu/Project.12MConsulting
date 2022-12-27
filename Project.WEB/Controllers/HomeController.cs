using Microsoft.AspNetCore.Mvc;

namespace Project.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
