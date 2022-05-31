using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KonusarakOgren.Data
{
    public class ContextKonusarakOgren:DbContext
    {
        public ContextKonusarakOgren(DbContextOptions<ContextKonusarakOgren> options):base(options)
        {
           
        }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Exams> student_Exams { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
