using KonusarakOgren.Filters;
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
    [FilterStudentControl]
    public class StudentController:Controller
    {
        
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Profile()
        {
            int id =(int)HttpContext.Session.GetInt32("ID");//Session Id olacak

            return View(await _studentService.StudentDetail(id));

        }
    }
}
