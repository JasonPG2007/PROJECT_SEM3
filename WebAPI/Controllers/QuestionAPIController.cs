using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAPIController : ControllerBase
    {
        private readonly IQuestionRepository questionRepository;
        public QuestionAPIController()
        {
            questionRepository = new QuestionRepository();
        }
        // GET: api/<QuestionAPIController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return questionRepository.GetQuestions();
        }

        // GET api/<QuestionAPIController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var check = questionRepository.GetQuestionById(id);
            if (check == null)
            {
                return NotFound();
            }
            return check;
        }
        [HttpGet("GetAnswerByExam/{id}")]
        public IEnumerable<Question> GetQuestionByExam(int id)
        {
            var check = questionRepository.GetQuestionsByExam(id);
            if (check != null)
            {
                return check;
            }
            return Enumerable.Empty<Question>();
        }

        // POST api/<QuestionAPIController>
        [HttpPost]
        public void Post(Question question)
        {
            questionRepository.InsertQuestion(question);
        }
        [Route("CheckAnswer")]
        [HttpPost]
        public void Post2(Question question)
        {
            questionRepository.InsertQuestion(question);
        }

        // PUT api/<QuestionAPIController>/5
        [HttpPut("{id}")]
        public void Put(Question question)
        {
            questionRepository.UpdateQuestion(question);
        }

        // DELETE api/<QuestionAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            questionRepository.DeleteQuestion(id);
        }
    }
}
