using Microsoft.AspNetCore.Mvc;

namespace Project.WebApp.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
