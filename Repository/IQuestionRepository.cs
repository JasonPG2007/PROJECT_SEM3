﻿using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> GetQuestion();
        public Question GetQuestionById(int id);
        public void InsertQuestion(Question question);
        public void UpdateQuestion(Question question);
        public void DeleteQuestion(Question question);
    }
}
