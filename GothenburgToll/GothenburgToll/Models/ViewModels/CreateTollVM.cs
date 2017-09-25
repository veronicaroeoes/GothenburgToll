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
    public class CreateTollVM : Vehicle
    {
        public SelectListItem[] VehicleType { get; set; }
    }
}
