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

        Pizza GetPizzaById(int pizzaId);
        void DeleteComponentPizzas(int pizzaId);
        void EditPizza(Pizza editedPizza);
    }
}
