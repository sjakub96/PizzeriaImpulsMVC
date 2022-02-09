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
        public int Price { get; set; }
        public bool IsMeat { get; set; }

        public ICollection<Component>? Components { get; set; }
    }
}
