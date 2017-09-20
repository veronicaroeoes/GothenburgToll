using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public class Car : IVehicle
    {
        public string GetVehicleType()
        {
            return "Car";
        }
    }
}
