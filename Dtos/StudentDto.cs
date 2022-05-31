using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class StudentDto:VisitorNoDetailDto
    {
        public int teacherId { get; set; }
    }
}
