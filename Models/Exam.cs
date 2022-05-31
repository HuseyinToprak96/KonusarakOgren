using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int Indis { get; set; }
        public DateTime dateTime { get; set; }
        public string ExamTitle { get; set; }
        public string ExamParagraph { get; set; }
        [ForeignKey("teacher")]
        public int TeacherId { get; set; }
        public List<Question> Questions { get; set; }
        public Teacher teacher { get; set; }
        public List<Student_Exams> students_Exams { get; set; }
    }
}
