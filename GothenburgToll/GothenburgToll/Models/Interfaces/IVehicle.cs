using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public interface IVehicle
    {
        int ID { get; set; }

        [Required(ErrorMessage = "Select what kind of vehicle")]
        string SelectedVehicleType { get; set; }

        [Required(ErrorMessage = "Enter license plate")]
        string LicensePlate { get; set; }

        [Required(ErrorMessage = "Enter date and time for passing")]
        [DataType(DataType.DateTime)]
        DateTime DateTimePass { get; set; }

        string GetVehicleType();
    }
}   
