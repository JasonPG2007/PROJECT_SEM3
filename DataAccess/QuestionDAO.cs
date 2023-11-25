using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QuestionDAO
    {
        private static QuestionDAO instance = null;
        private static readonly object Lock = new object();
        public static QuestionDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new QuestionDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Question> GetQuestions()
        {
            using var context = new PetroleumBusinessDBContext();
            var listQuestion = context.Questions.ToList();
            return listQuestion;
        }
        public Question GetQuestionById(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var check = context.Questions.SingleOrDefault(q => q.QuestionID == id);
            if (check != null)
            {
                return check;
            }
            else
            {
                throw new ArgumentException("Question not found.");
            }
        }
        public void InsertQuestion(Question question)
        {
            using var context = new PetroleumBusinessDBContext();
            try
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateQuestion(Question question)
        {
            using var context = new PetroleumBusinessDBContext();
            try
            {
                context.Entry<Question>(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteQuestion(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var check = GetQuestionById(id);
            if (check != null)
            {
                try
                {
                    context.Questions.Remove(check);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
