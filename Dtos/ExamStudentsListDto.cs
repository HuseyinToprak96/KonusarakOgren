using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class ExamStudentsListDto:ExamDto
    {
        public TeacherStudentsDto  teacherStudents { get; set; }
    }
}
