using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.ViewModels
{
    [NotMapped]
    public class CreateTollVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Select what kind of vehicle")]
        public string VehicleType { get; set; }

        [Required(ErrorMessage = "Enter license plate")]
        public string LicensePlate { get; set; }

        //todo: fixa select listItem, jämför ViewsCarsOvn...
        //public SelectListItem[] VehicleTypeTest { get; set; } 

        [Required(ErrorMessage = "Enter date and time for passing")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimePass { get; set; }

        public CreateTollVM()
        {
            DateTimePass = DateTime.Now;
        }
    }
}
