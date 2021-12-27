using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class PizzaSize
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public ICollection<PizzaSizePizza>? PizzaSizePizzas { get; set; }

    }
}
