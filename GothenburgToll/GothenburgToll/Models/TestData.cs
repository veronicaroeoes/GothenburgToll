using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GothenburgToll.Models
{
    public class TestData
    {
        public void createVehicle()
        {
            Car car = new Car();

        }

        public DateTime[] createDateTime()
        {
            DateTime[] dates = new DateTime[] {
            new DateTime (2017, 06, 21, 10, 20, 1),
            new DateTime (2017, 06, 21, 10, 23, 16),
            new DateTime (2017, 06, 21, 22, 15, 23)
            };

            return dates;
        }
    }
}
