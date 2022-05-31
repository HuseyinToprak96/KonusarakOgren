using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Repositories
{
    public interface ITeacherRepository:IGenericRepository<Teacher>
    {
        Task<Teacher> LoginTeacher(string username, string password);
        Task<List<Student>> TeacherWithStudents(int id);
        Task<Teacher> TeacherDetails(int id);
    }
}
