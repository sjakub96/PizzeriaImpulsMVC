using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly Context _context;

        public DrinkRepository(Context context)
        {
            _context = context;
        }

        public int AddDrink(Drink drink)
        { 
            _context.Drinks.Add(drink);
            _context.SaveChanges();

            return drink.Id;
        }

        public void AddDrinkSizeDrink(DrinkSizeDrink drinkSizeDrink)
        {
            _context.DrinkSizeDrink.Add(drinkSizeDrink);
            _context.SaveChanges();
        }

        public void DeleteDrink(int drinkId)
        {
            var drink = _context.Drinks.Find(drinkId);

            if(drink != null)
            {
                _context.Drinks.Remove(drink);
                _context.SaveChanges();
            }
        }

        public IQueryable<Drink> GetAllDrinks()
        {
            var drinks = _context.Drinks;

            return drinks;
        }

        public int AddDrinkSize(DrinkSize drinkSize)
        {
            _context.DrinkSizes.Add(drinkSize);
            _context.SaveChanges();

            return drinkSize.Id;
        }

        public void DeleteDrinkSize(int drinkSizeId)
        {
            var drinkSize = _context.DrinkSizes.Find(drinkSizeId);

            if(drinkSize != null)
            {
                _context.DrinkSizes.Remove(drinkSize);
                _context.SaveChanges();
            }
        }

        public IQueryable<DrinkSize> GetAllDrinkSizes()
        {
            var drinkSizes = _context.DrinkSizes;
            
            return drinkSizes;
        }
    }
}
