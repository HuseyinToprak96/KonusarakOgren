using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public string question { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Answer { get; set; }
    }
}
