using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class ComponentPizza
    {
        
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }
        
    }
}
