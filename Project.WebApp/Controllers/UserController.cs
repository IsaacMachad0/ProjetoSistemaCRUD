using Microsoft.AspNetCore.Mvc;

namespace Project.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
