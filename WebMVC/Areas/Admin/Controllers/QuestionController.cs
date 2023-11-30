using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace WebMVC.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string ApiUrl = "";
        public QuestionController()
        {
            httpClient = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrl = "https://localhost:7274/api/QuestionAPI";
        }
        // GET: QuestionController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrl);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Question> listQuestions = JsonSerializer.Deserialize<List<Question>>(data, options);
            return View(listQuestions);
        }
        public async Task<ActionResult> StartQuiz(int id)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"https://localhost:7274/api/QuestionAPI/GetQuestionByExam/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Question question = JsonSerializer.Deserialize<Question>(data, options);
                return View(question);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> StartQuiz(Question question)
        {
            var data = JsonSerializer.Serialize(question);
            var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7274/api/QuestionAPI/CheckAnswer", typeData);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StartQuiz");
            }
            throw new ArgumentException("Error check , please try again");
        }
        // GET: QuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random random = new Random();
                    question.QuestionID = random.Next();
                    question.DateMake = DateTime.Now;
                    var data = JsonSerializer.Serialize(question);
                    var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await httpClient.PostAsync(ApiUrl, typeData);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    throw new ArgumentException("Creat failed.");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
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

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
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
