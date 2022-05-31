using KonusarakOgren.Interfaces.Repositories;
using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ContextKonusarakOgren context) : base(context)
        {
        }

        public async Task<Teacher> LoginTeacher(string username, string password)
        {
            return await _context.Teachers.Where(x => x.UserName == username && x.Password == password).SingleOrDefaultAsync();
        }

        public async Task<Teacher> TeacherDetails(int id)
        {
            return await _context.Teachers.Include(x => x.CreatedExams).Include(x => x.Students).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Student>> TeacherWithStudents(int id)
        {
            return await _context.Students.Where(x => x.teacherId == id).ToListAsync();
        }
    }
}
