using Microsoft.AspNetCore.Mvc;

namespace Project.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
