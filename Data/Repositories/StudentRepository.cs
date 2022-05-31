using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContextKonusarakOgren context) : base(context)
        {
        }

        public async Task<Student> LoginStudent(string username, string password)
        {
            return await _context.Students.Where(x => x.UserName == username && x.Password == password).SingleOrDefaultAsync();
        }

        public async Task<Student> StudentDetail(int id)
        {
            var student =await _context.Students.Include(x => x.teacher).ThenInclude(x => x.CreatedExams).Where(x => x.Id == id).Include(x=>x.TakenExams).SingleOrDefaultAsync();
            return student;
        }
    }
}
