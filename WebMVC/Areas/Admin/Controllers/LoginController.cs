using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		[HttpGet]
		public IActionResult logup()
        {
            return View();
        }
		
		[HttpGet]
        public IActionResult login()
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
