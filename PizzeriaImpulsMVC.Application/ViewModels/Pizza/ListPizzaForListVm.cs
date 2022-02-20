using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Pizza
{
    public class ListPizzaForListVm
    {
        public List<PizzaForListVm> Pizzas { get; set; }

        public int Count { get; set; }
    }
}
