using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Controllers
{
    public class NewsPageController : Controller
    {
        // GET: NewsPageController
        private readonly HttpClient _httpClient = null;
        private string NewsApiUrl = "";
        public NewsPageController()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            NewsApiUrl = "https://localhost:7274/api/NewsControllerApi";
        }
        // GET: NewsController
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage res = await _httpClient.GetAsync(NewsApiUrl);
            string strData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<News> newsList = JsonSerializer.Deserialize<List<News>>(strData, option);
            return View(newsList);
        }
    }
}
