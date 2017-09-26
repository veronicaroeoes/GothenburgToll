using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothenburgToll.Models.Interfaces
{
    public interface IVehicle
    {
        int ID { get; set; }

        string SelectedVehicleType { get; set; }

        string LicensePlate { get; set; }

        DateTime DateTimePass { get; set; }

        string GetVehicleType();
    }
}   
