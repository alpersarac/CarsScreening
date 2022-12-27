using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsScreening
{
    public class CarItem
    {
        public string StockType { get; set; }
        public string Model { get; set; }
        public string Miles { get; set; }
        public string Price { get; set; }
        public string CarLink { get; set; }
        public bool IsHomeDelivery { get; set; }

    }
}
