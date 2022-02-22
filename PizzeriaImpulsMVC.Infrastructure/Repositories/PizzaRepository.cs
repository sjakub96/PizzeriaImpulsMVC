using Microsoft.EntityFrameworkCore;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly Context _context;

        public PizzaRepository(Context context)
        {
            _context = context;
        }

        public int AddPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return pizza.Id;
        }

        public void DeletePizza(int pizzaId)
        {
            var pizza = _context.Pizzas.Find(pizzaId);

            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
            }
        }

        public IQueryable<Pizza> GetAllPizzas()
        {
            var pizzas = _context.Pizzas.Include(t => t.ComponentPizzas);

            return pizzas;
        }

       
    }
}
