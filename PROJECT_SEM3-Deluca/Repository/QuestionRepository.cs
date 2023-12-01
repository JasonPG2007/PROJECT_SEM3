using DataAccess;
using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        public void DeleteQuestion(int id) => QuestionDAO.Instance.DeleteQuestion(id);

        public Question GetQuestionById(int id) => QuestionDAO.Instance.GetQuestionById(id);

        public IEnumerable<Question> GetQuestions() => QuestionDAO.Instance.GetQuestions();

        public IEnumerable<Question> GetQuestionsByExam(int id) => QuestionDAO.Instance.GetQuestionsByExam(id);

        public void InsertQuestion(Question question) => QuestionDAO.Instance.InsertQuestion(question);

        public void UpdateQuestion(Question question) => QuestionDAO.Instance.UpdateQuestion(question);
    }
}
