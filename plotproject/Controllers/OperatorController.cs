using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject.Controllers
{
    public class OperatorController : Controller
    {
        private readonly PLotContext _context;

        public OperatorController(PLotContext context)
        {
            _context = context;
        }

        public ViewResult BigDemo()
        {
            _context.Vehicle.Add(
                new Vehicle
                {
                    License = "A4F8J3",
                    Color = "Red",
                    Make = "Ford",
                    Model = "Explorer"
                }
            );
            _context.SaveChanges();
            var vehicle = _context.Vehicle.Find("A4F8J3");
            vehicle.ParkingSpot = _context.ParkingSpot.Find(12);
            _context.SaveChanges();
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();

            return View(_context.ParkingSpot.Find(12));
        }

        public PartialViewResult IndexVehicles()
        {
            return PartialView("_Index", _context.Vehicle.Select(v => v.ToString()));
        }

        public PartialViewResult IndexTickets()
        {
            return PartialView("_Index", _context.Ticket.Select(t => t.ToString()));
        }

        // GET: Vehicles
        public IActionResult Index()
        {
            ViewData["vehicles"] = _context.Vehicle.Select(v => new SelectListItem {
                Text = v.ToString(),
                Value = v.License
            });
            ViewData["tickets"] = _context.Ticket.Select(t => new SelectListItem
            {
                Text = t.ToString(),
                Value = t.Id.ToString()
            });

            return View();
        }
    }
}
