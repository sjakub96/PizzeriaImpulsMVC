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
            var pizzas = _context.Pizzas.Include(t => t.ComponentPizzas).ThenInclude(c => c.Component);

            return pizzas;
        }

        public Pizza GetPizzaById(int pizzaId)
        {
            var pizza = _context.Pizzas
                .Include(t => t.ComponentPizzas)
                .ThenInclude(c => c.Component)
                .FirstOrDefault(x => x.Id == pizzaId);
                
            return pizza;

        }

        public void DeleteComponentPizzas(int pizzaId)
        {
            var componentsPizzasToDelete = _context.ComponentPizzas.Where(x => x.PizzaId == pizzaId);

            _context.RemoveRange(componentsPizzasToDelete);
            _context.SaveChanges();
        }

        public void EditPizza(Pizza editedPizza)
        {
            _context.Attach(editedPizza);
            _context.Entry(editedPizza).Property("Name").IsModified = true;
            _context.Entry(editedPizza).Property("IsMeat").IsModified = true;
            _context.Entry(editedPizza).Property("UserPrice").IsModified = true;
            _context.Entry(editedPizza).Property("ComponentsPrice").IsModified = true;
            _context.Entry(editedPizza).Property("TotalPrice").IsModified = true;
            _context.Entry(editedPizza).Property("ComponentPizzas").IsModified = true;
            /*
             declare @componentId int;

             set @componentId = 3


             select * from Pizzas 
             where Id in (
	             select PizzaId  from ComponentPizzas
	             where ComponentId = @componentId)
              */


            _context.SaveChanges();
        }


    }
}
