using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plotproject.Models;

namespace plotproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DriverEnter()
        {
            ViewData["Message"] = "This is where the driver enters the lot";

            return View();
        }

        public IActionResult DriverPark()
        {
            ViewData["Message"] = "This is where the driver chooses where to park";

            return View();
        }

        public IActionResult DriverExit()
        {
            ViewData["Message"] = "This is where the driver pays and leaves";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
