using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IVisitorService _visitorService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public LoginController(IVisitorService visitorService, IStudentService studentService, ITeacherService teacherService)
        {
            _visitorService = visitorService;
            _studentService = studentService;
            _teacherService = teacherService;
        }
        public IActionResult Visitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Visitor(string username,string password)
        {
           var dto= await _visitorService.LoginVisitor(username, password);
            if (dto != null) { 
            HttpContext.Session.SetInt32("ID",dto.Id);
            HttpContext.Session.SetString("status","visitor");
            return RedirectToAction( "Index", "Page");}
            else
            {
                TempData["Error"]= "Incorrect username or password";
                return View();
            }
        }
        public IActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Student(string username,string password)
        {
           var dto= await _studentService.LoginStudent(username, password);
            if (dto != null) { 
            HttpContext.Session.SetInt32("ID",dto.Id);
            HttpContext.Session.SetString("status","student");
            return RedirectToAction("Index", "Page");}
            else
            {
                TempData["Error"]= "Incorrect username or password";
                return View();
            }
        }
        public IActionResult Teacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Teacher(string username,string password)
        {
            var dto = await _teacherService.LoginTeacher(username, password);
            if (dto != null)
            {
                HttpContext.Session.SetInt32("ID", dto.Id);
                HttpContext.Session.SetString("status", "teacher");
                return RedirectToAction("Index", "Page");
            }
            else
            {
                TempData["Error"] = "Incorrect username or password";
                return View();
            }
        }
        public IActionResult Out()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Page");
        }
    }
}
