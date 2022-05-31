using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonusarakOgren.Data;
using KonusarakOgren.Models;
using KonusarakOgren.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using KonusarakOgren.Filters;

namespace KonusarakOgren.Controllers
{
    [AllowAnonymous]
    [FilterTeacherControl]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _context;
        private readonly IStudentService _serviceStudent;

        public TeacherController(ITeacherService context, IStudentService serviceStudent)
        {
            _context = context;
            _serviceStudent = serviceStudent;
        }
        [FilterTeacherControl]
        public IActionResult CreatedStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FilterTeacherControl]
        public async Task<IActionResult> CreatedStudent(Student student)
        {
            student.teacherId = HttpContext.Session.GetInt32("ID");
            if (ModelState.IsValid)
            {
                await _serviceStudent.AddAsync(student);
                //teacher.Students.Add(student);
            }
            return RedirectToAction("/Exam/List");
        }

        // GET: Teachers
        [FilterStatus]
        public async Task<IActionResult> List()
        {
            return View(await _context.getAllAsync());
        }
        [FilterTeacherControl]
        public async Task<IActionResult> Profile()
        {
            int id = (int)HttpContext.Session.GetInt32("ID");
            var students =await _context.TeacherDetails(id);
            return View(students);
        }
        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var teacher = await _context.getByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,status,Name,LastName,UserName,Password")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(teacher);
               
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var teacher = await _context.getByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,status,Name,LastName,UserName,Password")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await  _context.UpdateAsync(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            await _context.removeAsync(id);

            return View();
        }
    }
}
