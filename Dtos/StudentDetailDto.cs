using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class StudentDetailDto:StudentDto
    {
        public List<ExamNoDetailDto> Exams { get; set; }
        public VisitorNoDetailDto Teacher { get; set; }
        public List<StudentExamDto> studentExamDtos { get; set; }
    }
}
