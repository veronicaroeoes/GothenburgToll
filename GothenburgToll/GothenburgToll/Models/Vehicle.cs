using GothenburgToll.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public class Vehicle : IVehicle
    {
        public int ID { get; set; }

        public string SelectedVehicleType { get; set; }

        [Required(ErrorMessage = "Enter license plate")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Enter date and time for passing")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimePass { get; set; }

        public virtual string GetVehicleType()
        {
            return SelectedVehicleType;
        }
    }
}
