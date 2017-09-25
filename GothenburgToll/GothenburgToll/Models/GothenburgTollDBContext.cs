using GothenburgToll.Models;
using GothenburgToll.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GothenburgToll
{
    public class GothenburgTollDBContext : DbContext
    {
        public GothenburgTollDBContext(DbContextOptions<GothenburgTollDBContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }

        internal CreateTollVM ListItems(CreateTollVM viewModel)
        {
            if (viewModel != null)
            {
                return new CreateTollVM
                {
                    LicensePlate = viewModel.LicensePlate,
                    SelectedVehicleType = viewModel.SelectedVehicleType,
                    DateTimePass = DateTime.Now,
                    VehicleType = new SelectListItem[]
                    {
                    new SelectListItem { Text = viewModel.SelectedVehicleType, Value = viewModel.SelectedVehicleType, Selected = true}
                    }
                };
            }
            return new CreateTollVM
            {
                VehicleType = new SelectListItem[]
                    {
                            new SelectListItem { Text = "Car", Value = "Car"},
                            new SelectListItem { Text = "Motorbike", Value="Motorbike"},
                            new SelectListItem { Text = "Diplomat", Value="Diplomat"},
                            new SelectListItem { Text = "Emergency", Value="Emergency"},
                            new SelectListItem { Text = "Foreign", Value="Foreign"},
                            new SelectListItem { Text = "Military", Value="Military"},
                            new SelectListItem { Text = "Tractor", Value="Tractor"}
                    }
            };
        }

        internal void AddToll(CreateTollVM newToll)
        {
            var corrLicense = newToll.LicensePlate.Replace(" ", "").ToUpper();

            Vehicle newVehicle = new Vehicle();
            newVehicle.LicensePlate = corrLicense;
            newVehicle.SelectedVehicleType = newToll.SelectedVehicleType;
            newVehicle.DateTimePass = newToll.DateTimePass;

            this.Vehicle.Add(newVehicle);
            this.SaveChanges();
        }

        internal CreateTollVM CreateVehicleByLicensePlate(string licensePlate)
        {
            var corrLicense = licensePlate.Replace(" ", "").ToUpper();

            return this.Vehicle
                .Where(v => v.LicensePlate == corrLicense)
                .Select(v => new CreateTollVM
                {
                    LicensePlate = corrLicense,
                    SelectedVehicleType = v.SelectedVehicleType
                }).LastOrDefault();
        }

        internal ViewTollVM GetVehicleByLicensePlate(string licensePlate)
        {
            var corrLicense = licensePlate.Replace(" ", "").ToUpper();

            return this.Vehicle
                .Where(v => v.LicensePlate == corrLicense)
                .Select(v => new ViewTollVM
                {
                    LicensePlate = corrLicense,
                    SelectedVehicleType = v.SelectedVehicleType,
                    DateTimePassArr = Vehicle.Where(x => x.LicensePlate == corrLicense).OrderBy(o => o.DateTimePass).Select(d => d.DateTimePass).ToArray()
                }).LastOrDefault();
        }
    }
}