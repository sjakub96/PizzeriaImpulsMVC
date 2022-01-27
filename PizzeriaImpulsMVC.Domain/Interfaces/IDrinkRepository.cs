using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IDrinkRepository
    {
        int AddDrink(Drink drink);

        void DeleteDrink(int drinkId);

        IQueryable<Drink> GetAllDrinks();

        int AddDrinkSize(DrinkSize drinkSize);

        void DeleteDrinkSize(int drinkSizeId);

        IQueryable<DrinkSize> GetAllDrinkSizes();


    }
}
