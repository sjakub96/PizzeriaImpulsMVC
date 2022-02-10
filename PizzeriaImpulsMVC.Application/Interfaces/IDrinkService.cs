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
        int AddDrink(NewDrinkVm newDrinkVm);
        IQueryable<Drink> GetAllDrinks();
        ListDrinkForListVm GetAllDrinksForList();
        void DeleteDrink(int drinkId);
    }
}
