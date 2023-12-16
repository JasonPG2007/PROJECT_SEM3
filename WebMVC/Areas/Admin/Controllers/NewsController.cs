using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;
using Microsoft.AspNetCore.JsonPatch;
using Repository;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient = null;
        private string NewsApiUrl = "";
        PetroleumBusinessDBContext db;
        INewsRepository _newsRepository = null;
        INewsCategoryRepository _newsCategoryRepository = null;
        public NewsController()
        {
            _newsCategoryRepository = new NewsCategoryRepository();
            _newsRepository = new NewsRepository();
            db = new PetroleumBusinessDBContext();
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            NewsApiUrl = "https://localhost:7274/api/NewsControllerApi";      
        }
        // GET: NewsController
        public async Task<IActionResult> Index(int? page)
        {
            HttpResponseMessage res = await _httpClient.GetAsync(NewsApiUrl);
            string strData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<News> newsList = JsonSerializer.Deserialize<List<News>>(strData, option);

            int pageNumber = page ?? 1;
            int pageSize = 5;

            IPagedList<News> pagedNewsList = newsList.ToPagedList(pageNumber, pageSize);
            return View(pagedNewsList);
        }


        // GET: NewsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Gửi yêu cầu GET đến API để lấy thông tin chi tiết theo ID
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{NewsApiUrl}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var news = JsonSerializer.Deserialize<News>(data, options);

                // Hiển thị chi tiết của news trên view
                return View(news);
            }
            else
            {
                // Hiển thị thông báo lỗi nếu không lấy được dữ liệu
                return View("Error", new { message = $"Error fetching news details: {responseMessage.StatusCode}" });
            }
        }


        // GET: NewsController/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("https://localhost:7274/api/NewsControllerApi/GetNewsCategory");
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<NewsCategory> listCategory = JsonSerializer.Deserialize<List<NewsCategory>>(data, options);
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                selectList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }
            ViewBag.Items = selectList;
            return View();
        }

        // POST: NewsController/Create API//////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsImage n, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                News news = new News
                {
                    NewsID = random.Next(),
                    Title = n.Title,
                    Contents = n.Contents,
                    ShortContents = n.ShortContents,
                    DateSubmitted = n.DateSubmitted,
                    AccountID = n.AccountID,
                    CategoryID = n.CategoryID,
                };

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Lấy tên tệp từ đường dẫn đầy đủ
                    var fileName = Path.GetFileName(imageFile.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    // Gán chỉ tên tệp (không có đường dẫn đầy đủ)
                    news.Picture = fileName;
                }

                // Send data to API
                string strData = JsonSerializer.Serialize(news);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PostAsync(NewsApiUrl, contentData);

                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Post inserted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Log error or handle API response
                    TempData["Message"] = $"Error while calling Web API: {res.StatusCode}";
                }
            }

            return View(n);
        }

        // GET: NewsController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News n)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(n);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _httpClient.PutAsync($"{NewsApiUrl}/{id}", contentData);
                if (res.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Product updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Message"] = "Error while call Web API";
                }
            }
            return View(n);
        }


        // GET: NewsController/Delete/5
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

        // POST: NewsController/Delete/5
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
