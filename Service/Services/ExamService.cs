using AutoMapper;
using KonusarakOgren.Dtos;
using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Interfaces.UnitOfWork;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Service.Services
{
    public class ExamService : Service<Exam>,IExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamService(IGenericRepository<Exam> genericRepository, IUnitOfWork unitOfWork, IExamRepository examRepository, IMapper mapper) : base(genericRepository, unitOfWork,mapper)
        {
            _examRepository = examRepository;
        }

        public async Task<Exam> ExamDetail(int id)
        {
            var exam =await _examRepository.ExamDetail(id);
         // var examDetail = _mapper.Map<ExamDetailDto>(exam);
            return exam;

        }
        public async Task<ExamStudentsListDto> ExamStudentList(int id)
        {
            var exam = await _examRepository.ExamStudentList(id);
            var examStudentListDto = _mapper.Map<ExamStudentsListDto>(exam);
            return examStudentListDto;
        }

        public async Task<List<QuesAndAns>> ExamwithQuestion(int id)
        {
            var Questions = await _examRepository.ExamwithQuestion(id);
            var QuesAndAnsDtos = _mapper.Map<List<QuesAndAns>>(Questions);
            return QuesAndAnsDtos;
        }

        public async Task<List<ExamDto>> StudentwithExams(int id)
        {
            var exams = await _examRepository.StudentwithExams(id);
            var dto = _mapper.Map<List<ExamDto>>(exams);
            return dto;
        }
    }
}
