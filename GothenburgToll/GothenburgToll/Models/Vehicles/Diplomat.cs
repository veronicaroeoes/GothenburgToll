using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.Vehicles
{
    public class Diplomat : Vehicle, IVehicle
    {
        public override string GetVehicleType()
        {
            return "Diplomat";
        }
    }
}
