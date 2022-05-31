using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Models
{

    public class Student :BaseEntity
    {

        [ForeignKey("teacher")]
        public int? teacherId { get; set; }
        public Teacher teacher { get; set; }
        public List<Student_Exams> TakenExams { get; set; }
    }
}