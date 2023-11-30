using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Areas.Admin.Controllers
{
    public class ExamController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string ApiUrl = "";
        public ExamController()
        {
            httpClient = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrl = "https://localhost:7274/api/ExamAPI";
        }
        // GET: ExamController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrl);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Exam> listExams = JsonSerializer.Deserialize<List<Exam>>(data, options);
            return View(listExams);
        }
        public async Task<ActionResult> ExamDashboard(int id)
        {
            if (id != 0)
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync($"https://localhost:7274/api/ExamAPI/GetRoom/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("StartQuiz", "Question", id);
                }
                TempData["msg"] = "Room not found...";
                return View();
            }
            else
            {
                return View();
            }

        }
        //[HttpPost]
        //public async Task<ActionResult> ExamDashboard(int room)
        //{
        //    var data = JsonSerializer.Serialize(room);
        //    var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        //    HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7274/api/ExamAPI/GetRoom", typeData);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("StartQuiz", "Question");
        //    }
        //    throw new ArgumentException("Room not found...");
        //}
        // GET: ExamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exam exam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random random = new Random();
                    exam.ExamID = random.Next();
                    var data = JsonSerializer.Serialize(exam);
                    var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await httpClient.PostAsync(ApiUrl, typeData);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    throw new ArgumentException("Created failed.");
                }
                else
                {
                    ModelState.AddModelError("error", "Please complete information.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: ExamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: ExamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
