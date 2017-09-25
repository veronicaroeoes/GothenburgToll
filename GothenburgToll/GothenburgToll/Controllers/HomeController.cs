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
        //todo: API för helgdagar

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
            var selectedVehicle = _context.GetVehicleByLicensePlate(licensePlate);

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
                var model = _context.CreateVehicleByLicensePlate(createToll.LicensePlate);
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
