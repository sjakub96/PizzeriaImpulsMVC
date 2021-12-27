using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class DrinkSizeDrink
    {
        public int DrinkId { get; set; }
        public Drink? Drink { get; set; }
        public int DrinkSizeId { get; set; }
        public DrinkSize? DrinkSize { get; set; }
    }
}
