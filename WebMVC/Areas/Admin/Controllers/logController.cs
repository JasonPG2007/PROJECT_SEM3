using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class logController : Controller
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
		public IActionResult login(string username ,string password)
		{
			var use = username;
			var pas = password;
			return View();
		}
     }   
}
