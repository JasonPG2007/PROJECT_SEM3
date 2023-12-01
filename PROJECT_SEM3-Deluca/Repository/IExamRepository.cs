﻿using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IExamRepository
    {
        public IEnumerable<Exam> GetExams();
        public Exam GetExamById(int id);
        public void InsertExam(Exam exam);
        public void UpdateExam(Exam exam);
        public void DeleteExam(int id);
    }
}
