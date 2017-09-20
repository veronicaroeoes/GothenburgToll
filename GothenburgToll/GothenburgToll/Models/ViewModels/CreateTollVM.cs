using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.ViewModels
{
    public class CreateTollVM
    {
        [Required(ErrorMessage = "Enter what kind of vehicle")]
        public string VehicleType { get; set; }

        [Required(ErrorMessage = "Enter license plate")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Enter date and time for passing")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimePass { get; set; }

        public CreateTollVM()
        {
            DateTimePass = DateTime.Now;
        }
    }
}
