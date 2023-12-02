using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;
using X.PagedList;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        INewsRepository _newsRepository = null;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PostController(IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = new NewsRepository();
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: PostController
        [HttpGet]
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            var _newsList = _newsRepository.GetNewsByName(searchString is null ? null : searchString.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            return View(_newsList);
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
        public ActionResult Create(News n)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _newsRepository.InsertNews(n);
                    TempData["SuccessMessage"] = "News created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "New creation failed";
                }
            }
            catch (Exception ex)
            {

            }
            return View(n);
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            var n = _newsRepository.GetNewsById(id);
            return View(n);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, News n)
        {
            try
            {
                _newsRepository.EditNews(n);
                TempData["Message"] = "Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        [HttpPost]
        public JsonResult DeleteId(int id)
        {
            try
            {
                var record = _newsRepository.GetNewsById(id);
                if (record == null)
                {
                    return Json(new { success = false, message = "Newsletter not found" });
                }
                _newsRepository.DeleteNews(id);
                TempData["Message"] = "Deleted successfully";
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new {success = false, message = ex.Message});
            }
        }

        // POST: PostController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _newsRepository.DeleteNews(id);
                TempData["Message"] = "Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public JsonResult ListName(string _n)
        {
            if (!string.IsNullOrEmpty(_n))
            {
                var data = _newsRepository.GetNewsByName(_n.ToLower(), "name");
                var responseData = data.Select(nn => nn.Title).ToList();
                return Json(new
                {
                    data = responseData,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}
