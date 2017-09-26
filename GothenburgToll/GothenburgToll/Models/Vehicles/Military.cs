using GothenburgToll.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.Vehicles
{
    public class Military : Vehicle, IVehicle
    {
        public override string GetVehicleType()
        {
            return "Military";
        }
    }
}
