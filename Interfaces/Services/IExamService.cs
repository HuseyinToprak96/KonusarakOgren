using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Services
{
    public interface IExamService:IService<Exam>
    {
        Task<Exam> ExamDetail(int id);
        Task<ExamStudentsListDto> ExamStudentList(int id);
        Task<List<QuesAndAns>> ExamwithQuestion(int id);
        Task<List<ExamDto>> StudentwithExams(int id);
    }
}
