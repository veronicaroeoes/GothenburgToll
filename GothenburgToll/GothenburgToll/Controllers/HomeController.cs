using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GothenburgToll.Models.ViewModels;
using GothenburgToll.Models;

namespace GothenburgToll.Controllers
{
    public class HomeController : Controller
    {
        GothenburgTollDBContext _context;
        ITollCalculator _tollCalculator;
        IVehicle _vehicle;

        public HomeController(ITollCalculator tollCalculator, IVehicle vehicle, GothenburgTollDBContext context)
        {
            _tollCalculator = tollCalculator;
            _vehicle = vehicle;
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewToll(string licensePlate)
        {
            return View(licensePlate.ToString());
        }

        [HttpPost]
        public IActionResult ViewToll(Vehicle input)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateToll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateToll(Vehicle createToll)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CreateToll));
            }

            _context.AddToll(createToll);

            // If TempData... 

            return RedirectToAction(nameof(Index));
        }
    }
}
