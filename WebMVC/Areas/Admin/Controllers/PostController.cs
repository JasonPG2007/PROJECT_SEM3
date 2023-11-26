using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly HttpClient _httpClient = null;
        private string NewsApiUrl = "";
        public PostController()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            NewsApiUrl = "https://localhost:7274/api/News";
        }
        // GET: PostController
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage res = await _httpClient.GetAsync(NewsApiUrl);
            string strData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<News> listNews = JsonSerializer.Deserialize<List<News>>(strData, option);
            return View(listNews);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News n)
        {
            if(ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(n);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PostAsync(NewsApiUrl, contentData);
                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Post inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View();
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"{NewsApiUrl}/{id}");
            if(res.IsSuccessStatusCode)
            {
                string strData = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                News n = JsonSerializer.Deserialize<News>(strData, options);
                return View(n);
            }
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News n)
        {
            if(ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(n);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PutAsync($"{NewsApiUrl}/{id}", contentData);
                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Post updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(n);
        }

        // GET: PostController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"{NewsApiUrl}/{id}");
            if (res.IsSuccessStatusCode)
            {
                string strData = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                News n = JsonSerializer.Deserialize<News>(strData, options);
                return View(n);
            }
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            HttpResponseMessage res = await _httpClient.DeleteAsync($"{NewsApiUrl}/{id}");
            if (res.IsSuccessStatusCode)
            {
                TempData["Message"] = "Post deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "Error while call Web API";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
