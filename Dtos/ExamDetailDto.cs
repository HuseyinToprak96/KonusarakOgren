using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class ExamDetailDto
    {
        public ExamDto examDto { get; set; }
         public VisitorNoDetailDto teacher { get; set; }
        public List<QuestionDto> Questions  { get; set; }
    }
}
