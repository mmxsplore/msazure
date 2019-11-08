using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Runtime.InteropServices;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string computername; 
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                computername = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
            else
            {
                computername = System.Environment.GetEnvironmentVariable("HOSTNAME");
            }

            ViewBag.computername = computername;
            ViewBag.blue_or_green = "VIOLET";
            ViewBag.utc_time = DateTime.UtcNow;

            return View();          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
