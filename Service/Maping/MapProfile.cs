using AutoMapper;
using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Service.Maping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Visitor, inputInformationDto>();
            CreateMap<Student, inputInformationDto>();
            CreateMap<Teacher, inputInformationDto>();
            CreateMap<Teacher, VisitorNoDetailDto>();
            CreateMap<Student, VisitorNoDetailDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuesAndAns>();
           // CreateMap<List<Question>,List<QuestionDto>>();
            CreateMap<Exam, ExamDto>();
            CreateMap<Exam, ExamNoDetailDto>();
            CreateMap<Exam, StudentExamDto>();
            CreateMap<List<Question>, ExamDetailDto>();
           // CreateMap<ExamDto, ExamDetailDto>();
             CreateMap<Teacher, ExamDetailDto>();
            CreateMap<VisitorNoDetailDto, StudentDetailDto>();
            CreateMap<List<ExamNoDetailDto>, StudentDetailDto>();
            CreateMap<List<Exam>, StudentDetailDto>();
            CreateMap<ExamDto, StudentDetailDto>();
            CreateMap<Student_Exams, StudentExamDto>()
                .IncludeMembers(x=>x.exam)
                .ForMember(x => x.examDto, opt => opt.MapFrom(x => x.exam));
            CreateMap<StudentExamDto, StudentDetailDto>();
            //Navigation Propery Maping(Önemli)
            CreateMap<Exam, ExamDetailDto>()
                   .IncludeMembers(x => x.Questions)
                   .IncludeMembers(x=>x.teacher)
                   .ForMember(x => x.Questions, opt => opt.MapFrom(x => x.Questions.ToList()))
                   .ForMember(x => x.teacher, opt => opt.MapFrom(x => x.teacher));
                  

            CreateMap<Student, StudentDetailDto>()
                .IncludeMembers(x => x.TakenExams)
                .IncludeMembers(x => x.teacher)
                .IncludeMembers(x=>x.teacher.CreatedExams)
                .ForMember(x => x.studentExamDtos, opt => opt.MapFrom(x => x.TakenExams.ToList()))
                .ForMember(x=>x.Teacher,opt=>opt.MapFrom(x=>x.teacher))
                .ForMember(x=>x.Exams,opt=>opt.MapFrom(x=>x.teacher.CreatedExams.Where(x=>x.dateTime>DateTime.Now)));
            //   //.ForPath(x => x.QuestionDtos, opt => opt.MapFrom(x => x.Questions));
            ////   .ForMember(x=>x.QuestionDtos,a=>a.MapFrom(x=>x.Questions.SelectMany(x=>x.)));
            //   CreateMap<Teacher, TeacherStudentsDto>()
            //       .ForMember(x => x.Students, opt => opt.MapFrom(x => x.Students));
            //   CreateMap<Exam, ExamStudentsListDto>()
            //       .ForMember(x => x.teacherStudents, opt => opt.MapFrom(x => x.teacher))
            //       .ForPath(x=>x.teacherStudents.Students,opt=>opt.MapFrom(x=>x.teacher.Students));
            //   CreateMap<Teacher, TeacherExamsDto>()
            //       .ForMember(x => x.Exams, opt => opt.MapFrom(x => x.CreatedExams));
            //   CreateMap<Student, StudentDetailDto>()
            //       .ForMember(x => x.Teacher, opt => opt.MapFrom(x => x.teacher))
            //       .ForPath(x=>x.Exams,opt=>opt.MapFrom(x=>x.teacher.CreatedExams));

            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Exam, ExamDetailDto>()
            //    .IncludeMembers(x => x.Questions)
            //    .ForMember(x => x.Questions, opt => opt.MapFrom(x => x.Questions.ToList()));
            //});
        }
    } }
