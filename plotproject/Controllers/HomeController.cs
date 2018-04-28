using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly PLotContext _context;

        public HomeController(PLotContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReadLicense()
        {
            return View();
        }

        public async Task<IActionResult> LookupVehicle(string license)
        {
            if (license == null)
                return NotFound();
            
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.License == license);

            TempData["license"] = license;

            if (vehicle == null)
                return RedirectToAction(nameof(HomeController.RegisterVehicle), new { License = license } );

            HttpContext.Session.SetString("VehicleLicense", vehicle.License);
            return RedirectToAction(nameof(HomeController.Enter), new { VehicleLicense = license });
        }

        public IActionResult RegisterVehicle(string license)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterVehicle([Bind("License,Make,Model,Color")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (_context.Vehicle.Any(e => e.License == vehicle.License))
                {
                    ModelState.AddModelError("License", "Vehicle with this License already exists");
                    return View(vehicle);
                }
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("VehicleLicense", vehicle.License);
                return RedirectToAction(nameof(HomeController.Enter), new { VehicleLicense = vehicle.License });
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Enter(string vehicleLicense)
        {
            var vehicle = _context.Vehicle.Find(HttpContext.Session.GetString("VehicleLicense"));
            if (vehicle == null)
                return RedirectToAction(nameof(HomeController.ReadLicense));

            // Get an open ticket for the current vehicle
            var ticket = await _context.Ticket.SingleOrDefaultAsync(t => t.VehicleLicense == vehicle.License && t.OutTime == null);
            if (ticket != null)
            {
                // If the ticket is open, and the vehicle has a parking spot, go to checkout
                if (vehicle.ParkingSpot != null)
                    return RedirectToAction(nameof(HomeController.Checkout), new { ticket });
                // If the ticket is open but the vehicle is not parked, go to parking
                return RedirectToAction(nameof(HomeController.Park), new { vehicle });
            }
            ViewData["Types"] = await _context.ParkingType.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enter([Bind("InTime,VehicleLicense,TypeId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("TicketId", ticket.Id);
                return RedirectToAction(nameof(HomeController.Park));
            }
            return View(ticket);
        }

        public async Task<IActionResult> Park()
        {
            var ticket = await _context.Ticket.FindAsync(HttpContext.Session.GetInt32("TicketId"));
            if (ticket == null)
                return RedirectToAction(nameof(HomeController.Enter));
            ViewData["parkingSpots"] = await _context.ParkingSpot.ToListAsync();
            return View(_context.ParkingSpot.Where(s => s.TypeId == ticket.TypeId && s.VehicleLicense == null));
        }

        public IActionResult Checkout()
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
