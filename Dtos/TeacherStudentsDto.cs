using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class TeacherStudentsDto:VisitorNoDetailDto
    {
       public List<VisitorNoDetailDto> Students { get; set; }
    }
}
