using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Repositories
{
    public  interface IExamRepository:IGenericRepository<Exam>
    {
        Task<Exam> ExamDetail(int id);
        Task<Exam> ExamStudentList(int id);
        Task<List<Question>> ExamwithQuestion(int id);
        Task<List<Exam>> StudentwithExams(int id);
    }
}
