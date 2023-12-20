using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsCategoryController : Controller
    {
        private readonly HttpClient _httpClient = null;
        private string NewsCategoryApiUrl = "";
        public NewsCategoryController()
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            NewsCategoryApiUrl = "https://localhost:7274/api/NewsCategoryControllerApi";
        }
        // GET: NewsCategoryController
        public async Task<IActionResult> Index(int? page)
        {
            HttpResponseMessage res = await _httpClient.GetAsync(NewsCategoryApiUrl);
            string strData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<NewsCategory> newsCategoryList = JsonSerializer.Deserialize<List<NewsCategory>>(strData, option);
            int pageNumber = (page ?? 1); // Nếu page là null, sử dụng trang 1.
            int pageSize = 5; // 
            IPagedList<NewsCategory> pagedNewsCategories = newsCategoryList.ToPagedList(pageNumber, pageSize);
            return View(pagedNewsCategories);
        }

        // GET: NewsCategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCategory n)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                n.CategoryID = random.Next();
                string strData = JsonSerializer.Serialize(n);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage res = await _httpClient.PostAsync(NewsCategoryApiUrl, contentData);

                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "News category inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while calling Web API";
                }
            }
            return View(n);
        }

        // GET: NewsCategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"{NewsCategoryApiUrl}/{id}");
            if (res.IsSuccessStatusCode)
            {
                string strData = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                NewsCategory n = JsonSerializer.Deserialize<NewsCategory>(strData, options);
                return View(n);
            }
            return View();
        }

        // POST: NewsCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsCategory n)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(n);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PutAsync($"{NewsCategoryApiUrl}/{id}", contentData);
                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Category updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(n);
        }

        // GET: NewsCategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"{NewsCategoryApiUrl}/{id}");
            if (res.IsSuccessStatusCode)
            {
                string strData = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                NewsCategory n = JsonSerializer.Deserialize<NewsCategory>(strData, options);
                return View(n);
            }
            return View();
        }

        // POST: NewsCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            HttpResponseMessage res = await _httpClient.DeleteAsync($"{NewsCategoryApiUrl}/{id}");
            if (res.IsSuccessStatusCode)
            {
                TempData["Message"] = "Category deleted successfully";
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
