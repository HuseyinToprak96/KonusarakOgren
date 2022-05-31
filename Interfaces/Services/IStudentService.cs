using KonusarakOgren.Dtos;
using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Services
{
    public interface IStudentService:IService<Student>
    {
        Task<StudentDetailDto> StudentDetail(int id);
        Task<inputInformationDto> LoginStudent(string username, string password);
    }
}
