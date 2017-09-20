using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public interface IVehicle
    {
        int ID { get; set; }
        string VehicleType { get; set; }
        string LicensePlate { get; set; }
        DateTime DateTimePass { get; set; }

        string GetVehicleType();
    }
}   
