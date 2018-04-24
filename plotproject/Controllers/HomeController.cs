using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReadLicense()
        {
            return View();
        }

        public IActionResult LookupVehicle(string license)
        {
            if (license == null)
                return NotFound();

            var vehicle = _context.Vehicle.SingleOrDefaultAsync(m => m.License == license);

            if (vehicle == null)
                return RedirectToAction(nameof(HomeController.RegisterVehicle));

            return RedirectToAction("Enter");
        }

        public IActionResult RegisterVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterVehicle(int something)
        {
            // Save to db
            return RedirectToAction("Enter");
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
