﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient = null;
        private string NewsApiUrl = "";
        public NewsController()
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

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
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

/*        public async Task<ActionResult> NewsPage(int id)
        {
            if (id != 0)
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{NewsApiUrl}/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("NewsPage", "News", new { id = id });
                }
                TempData["Message"] = "";
                return View();
            }
            else
            {
                return View();
            }

        }*/
    }
}
