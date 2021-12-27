using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class DrinkSize
    {
        public int Id { get; set; }
        public decimal Size { get; set; }

        public ICollection<DrinkSizeDrink>? DrinkSizeDrinks { get; set; }
    }
}
