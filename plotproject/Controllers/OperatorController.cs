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
