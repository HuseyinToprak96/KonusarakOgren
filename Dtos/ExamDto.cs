using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class ExamDto
    {
        public int ExamId { get; set; }
        public DateTime dateTime { get; set; }
        public string ExamTitle { get; set; }
        public string ExamParagraph { get; set; }
    }
}
