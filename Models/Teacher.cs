using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Models
{
    public class Teacher:BaseEntity
    {
       
        public List<Exam> CreatedExams { get; set; }
        public List<Student> Students { get; set; }

    }
}
