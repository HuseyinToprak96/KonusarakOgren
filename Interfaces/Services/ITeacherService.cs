using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Services
{
    public interface ITeacherService:IService<Teacher>
    {
        Task<inputInformationDto> LoginTeacher(string username, string password);
        Task<List<Student>> TeacherWithStudents(int id);
        Task<Teacher> TeacherDetails(int id);
    }
}
