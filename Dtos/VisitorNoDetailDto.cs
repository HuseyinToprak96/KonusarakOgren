using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Dtos
{
    public class VisitorNoDetailDto
    {
        public int Id { get; set; }
        public Status status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
