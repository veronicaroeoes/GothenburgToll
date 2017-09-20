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
        List<CreateTollVM> tollList = new List<CreateTollVM>();

        ITollCalculator _tollCalculator;
        IVehicle _vehicle;

        public HomeController(ITollCalculator tollCalculator, IVehicle vehicle)
        {
            _tollCalculator = tollCalculator;
            _vehicle = vehicle;
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
        public IActionResult ViewToll(ViewTollVM input)
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateToll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateToll(CreateTollVM createToll)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CreateToll));
            }

            //createToll.TollFee = _tollCalculator.GetTollFee(createToll.DateTimePass, createToll.VehicleType);

            tollList.Add(createToll);

            // If TempData... 

            return View(nameof(Index));
        }
    }
}
