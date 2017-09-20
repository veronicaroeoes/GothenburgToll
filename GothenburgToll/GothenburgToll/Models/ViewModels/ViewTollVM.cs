using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.ViewModels
{
    [NotMapped]
    public class ViewTollVM
    {
        public string LicensePlate { get; set; }
    }
}
