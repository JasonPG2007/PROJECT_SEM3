using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Login(string username,string password)
		{
			return View();
		}

	}
}
