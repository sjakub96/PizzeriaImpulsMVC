using PizzeriaImpulsMVC.Application.ViewModels.Drink;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IDrinkService
    {
        int AddNewDrinkSize(NewDrinkSizeVm newDrinkSizeVm);
        int AddDrink(NewDrinkVm newDrinkVm);
        void AddDrinkSizeDrink(int id, int[] DrinkSizeIds);
        IQueryable<Drink> GetAllDrinks();
        IQueryable<DrinkSize> GetAllDrinkSizes();
        ListDrinkForListVm GetAllDrinksForList();
    }
}
