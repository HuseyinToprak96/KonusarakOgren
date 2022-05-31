using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Models
{
    public class Student_Exams
    {
        public int Id { get; set; }
        [ForeignKey("student")]
        public int? StudentsId { get; set; }
        [ForeignKey("exam")]
        public int? ExamId { get; set; }
        public int TotalTrue { get; set; }
        public int TotalFalse { get; set; }
        public int Point { get; set; }
        public bool IsEntry { get; set; }
        public Student student { get; set; }
        public Exam exam { get; set; }
    }
}
