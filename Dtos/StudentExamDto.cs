using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class StudentExamDto
    {
        public int Id { get; set; }
        public int? StudentsId { get; set; }
        public int? ExamId { get; set; }
        public int TotalTrue { get; set; }
        public int TotalFalse { get; set; }
        public int Point { get; set; }
        public ExamDto examDto { get; set; }
    }
}
