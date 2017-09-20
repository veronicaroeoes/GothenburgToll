using GothenburgToll.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public interface ITollCalculator
    {
        int GetTollFee(IVehicle vehicle, DateTime[] dates);
        int GetTollFee(DateTime date, IVehicle vehicle);
        ViewTollVM GetOneVehicle(string licensePlate);
    }
}
