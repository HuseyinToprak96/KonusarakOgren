using KonusarakOgren.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    [AllowAnonymous]
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Campaigns()
        {
            List<Vm_Campaign> _Campaigns = new List<Vm_Campaign>();
            Vm_Campaign campaign = new Vm_Campaign();
            for (int i = 1; i <= 10; i++)
            {
               campaign = new Vm_Campaign();
               campaign.Image = "Campaign_" + i + ".jpg";
               _Campaigns.Add(campaign);
            }
            TempData["Campaigns"] = _Campaigns;
            return View();
        }


        public IActionResult AcademicCalendar()
        {
            return View();
        }

    }
}
