using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository = new NewsRepository();

        // GET: api/<NewsController>
        [HttpGet]
        public ActionResult<IEnumerable<News>> GetAllNews() => _newsRepository.GetAllNews();

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public ActionResult<News> GetNewsById(int id)
        {
            var news = _newsRepository.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return news;
        }

        // POST api/<NewsController>
        [HttpPost]
        public IActionResult PostNews(News n)
        {
            try
            {
                _newsRepository.SaveNews(n);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating news record");
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateNews(int id, News n)
        {
            var temp = _newsRepository.GetNewsById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _newsRepository.UpdateNews(n);
            return NoContent();
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                var temp = _newsRepository.GetNewsById(id);
                if (temp == null) { return NotFound(); }
                _newsRepository.DeleteNews(temp);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error delete news record");
            }
        }
    }
}
