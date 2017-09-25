using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    [NotMapped]
    public class Car : Vehicle
    {
         public override string GetVehicleType()
        {
            return "Car";
        }
    }
}
