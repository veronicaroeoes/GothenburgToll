using GothenburgToll.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.Vehicles
{
    [NotMapped]
    public class Motorbike : Vehicle, IVehicle
    {
        public override string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}
