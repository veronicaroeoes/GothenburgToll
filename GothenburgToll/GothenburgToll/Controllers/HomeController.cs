using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GothenburgToll.Models.ViewModels;
using GothenburgToll.Models;
using GothenburgToll.Models.Interfaces;

namespace GothenburgToll.Controllers
{
    public class HomeController : Controller
    {
        GothenburgTollDBContext _context;
        ITollCalculator _tollCalculator;

        public HomeController(ITollCalculator tollCalculator, GothenburgTollDBContext context)
        {
            _tollCalculator = tollCalculator;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Vehicle model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction(nameof(CreateToll), model);
        }
        
        [HttpGet]
        public IActionResult ViewToll(ViewTollVM model)
        {
            var selectedVehicle = _context.GetVehicleByLicensePlate(model.LicensePlate);

            if (selectedVehicle == null)
            {
                TempData["Succeded"] = "There is no toll for this license plate yet";
                return RedirectToAction("Success");
            }

            IVehicle vehicleType = VehicleService.GetIVehicle(selectedVehicle.SelectedVehicleType);
            selectedVehicle.TotalFee = _tollCalculator.GetTollFee(vehicleType, selectedVehicle.DateTimePassArr);
            DateTime[] newArr = selectedVehicle.DateTimePassArr.OrderByDescending(n => n).ToArray();
            selectedVehicle.DateTimePassArr = newArr;

            return View(selectedVehicle);
        }

        [HttpPost]
        public IActionResult ViewToll()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateToll(string licensePlate)
        {
            var selectedVehicle = _context.CreateVehicleByLicensePlate(licensePlate);

            return View(_context.ListItems(selectedVehicle));
        }

        [HttpPost]
        public IActionResult CreateToll(CreateTollVM createToll)
        {
            if (!ModelState.IsValid)
            {
                CreateTollVM model = _context.CreateVehicleByLicensePlate(createToll.LicensePlate);
                return View(_context.ListItems(model));
            }

            _context.AddToll(createToll);

            TempData["Succeded"] = "Toll added!";

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
