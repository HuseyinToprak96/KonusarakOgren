using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(ContextKonusarakOgren context) : base(context)
        {
        }

        public async Task<Exam> ExamDetail(int id)
        {
            var exam = await _context.Exams.Include(x=>x.teacher).Include(x=>x.Questions).Where(e => e.ExamId == id).SingleOrDefaultAsync();
            return exam;
        }

        public async Task<Exam> ExamStudentList(int id)
        {
            var exam = await _context.Exams.Include(x => x.teacher).ThenInclude(x => x.Students).Where(x => x.ExamId == id).SingleOrDefaultAsync();
            return exam;
        }

        public async Task<List<Question>> ExamwithQuestion(int id)
        {
            var questions = await _context.Exams.Include(x => x.Questions).Where(x => x.ExamId == id).Select(x=>new { x.Questions }).SingleOrDefaultAsync();
            return questions.Questions;
        }

        public async Task<List<Exam>> StudentwithExams(int id)
        {
            var student = await _context.Students.Include(x => x.teacher).ThenInclude(x => x.CreatedExams).Where(x => x.Id == id).SingleOrDefaultAsync();
            return student.teacher.CreatedExams.Where(x=>x.dateTime>DateTime.Now).ToList();
        }
    }
}
