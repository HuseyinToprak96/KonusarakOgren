using KonusarakOgren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Interfaces.Repositories
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<Student> StudentDetail(int id);
        Task<Student> LoginStudent(string username, string password);

    }
}
