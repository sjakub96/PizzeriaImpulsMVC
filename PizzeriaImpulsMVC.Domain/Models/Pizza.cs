using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserPrice { get; set; }
        public int ComponentsPrice { get; set; }
        public int TotalPrice { get; set; }
        public bool IsMeat { get; set; }

        public ICollection<ComponentPizza>? ComponentPizzas { get; set; }
    }
}
