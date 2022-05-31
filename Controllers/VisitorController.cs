using KonusarakOgren.Filters;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    [AllowAnonymous]
    [FilterLogin]
    public class VisitorController : Controller
    {
        private readonly IService<Visitor> _service;
        public VisitorController(IService<Visitor> service)
        {
            _service = service;
        }
        [FilterStatus]
        public async Task<IActionResult> List()
        {
            return View(await _service.getAllAsync()); 
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(Visitor visitor)
        {
           await _service.AddAsync(visitor);
            return RedirectToAction("List");
        }
    }
}
