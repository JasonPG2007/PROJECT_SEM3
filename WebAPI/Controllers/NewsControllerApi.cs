using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsControllerApi : ControllerBase
    {
        INewsRepository _newsRepository = null;
        private readonly IWebHostEnvironment webHostEnvironment;
        private INewsRepository _repository = new NewsRepository();

        public NewsControllerApi(IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = new NewsRepository();
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public ActionResult<IEnumerable<News>> GetNewsList() => _repository.GetNewsList();

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public ActionResult<News> GetNewsById(int id)
        {
            var news = _repository.GetNewsById(id);
            if (news == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy sản phẩm
            }

            return news;
        }

        // POST api/<NewsController>
        [HttpPost]
        public IActionResult InsertNews(News n)
        {
            try
            {

                _repository.InsertNews(n);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new News record");
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public IActionResult EditNews(int id, News n)
        {
            var temp = _repository.GetNewsById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _repository.EditNews(n);
            return NoContent();
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = _repository.GetNewsById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _repository.DeleteNews(temp);
            return NoContent();
        }

    }
}
