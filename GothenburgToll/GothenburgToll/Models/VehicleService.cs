using GothenburgToll.Models.Interfaces;
using GothenburgToll.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public class VehicleService
    {
        public static IVehicle GetIVehicle(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Car":
                    return new Car();

                case "Motorbike":
                    return new Motorbike();

                case "Diplomat":
                    return new Diplomat();

                case "Emergency":
                    return new Emergency();

                case "Foreign":
                    return new Foreign();

                case "Military":
                    return new Military();

                case "Tractor":
                    return new Tractor();

                default:
                    return null;
            }
        }
    }
}
