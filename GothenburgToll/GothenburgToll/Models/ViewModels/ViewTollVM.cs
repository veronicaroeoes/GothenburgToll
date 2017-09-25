using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models.ViewModels
{
    [NotMapped]
    public class ViewTollVM : Vehicle
    {
        public DateTime[] DateTimePassArr { get; set; }
        public int TotalFee { get; set; }
    }
}
