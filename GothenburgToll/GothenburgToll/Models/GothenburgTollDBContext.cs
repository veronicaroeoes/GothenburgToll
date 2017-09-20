using GothenburgToll.Models;
using GothenburgToll.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GothenburgToll
{
    public class GothenburgTollDBContext : DbContext
    {
        public GothenburgTollDBContext(DbContextOptions<GothenburgTollDBContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }

        internal void AddToll(Vehicle newToll)
        {
                Vehicle newVehicle = new Models.Vehicle();
                newVehicle.LicensePlate = newToll.LicensePlate;
                newVehicle.VehicleType = newToll.VehicleType;
                newVehicle.DateTimePass = newToll.DateTimePass; 
                
                this.Vehicle.Add(newVehicle);
                this.SaveChanges();
        }
    }
}