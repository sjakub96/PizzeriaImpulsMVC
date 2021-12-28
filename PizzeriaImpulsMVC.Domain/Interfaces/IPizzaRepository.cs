using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        int AddPizza(Pizza pizza);

        void DeletePizza(int pizzaId);

        IQueryable<Pizza> GetAllPizzas();

        int AddPizzaSize(PizzaSize pizzaSize);

        void DeletePizzaSize(int pizzaSizeId);

        IQueryable<PizzaSize> GetAllPizzaSizes();
        
    }
}
