using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class TeacherExamsDto:VisitorNoDetailDto
    {
        public List<ExamNoDetailDto> Exams { get; set; }
    }
}
