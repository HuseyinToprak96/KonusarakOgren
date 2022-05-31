using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Models
{
    public enum Status { Visitor = 0, Student = 1, Teacher = 2, Admin = 3 }
    public class BaseEntity
    {
        public int Id { get; set; }
        public Status status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
