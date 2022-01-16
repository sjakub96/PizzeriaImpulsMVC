using AutoMapper;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Drink;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IMapper? _mapper;
        private readonly IDrinkRepository? _drinkRepository;

        public DrinkService(IMapper mapper, IDrinkRepository drinkRepository)
        {
            _mapper = mapper;
            _drinkRepository = drinkRepository;
        }

        public int AddDrink(NewDrinkVm newDrinkVm)
        {
            var drink = _mapper.Map<Drink>(newDrinkVm);
            var id = _drinkRepository.AddDrink(drink);

            return id;
        }


        public void AddDrinkSizeDrink(int id, int[] DrinkSizeIds)
        {
            foreach(int drinkSizeId in DrinkSizeIds)
            {
                DrinkSizeDrink drinkSizeDrink = new DrinkSizeDrink();
                drinkSizeDrink.DrinkId = id;
                drinkSizeDrink.DrinkSizeId = drinkSizeId;
                _drinkRepository.AddDrinkSizeDrink(drinkSizeDrink);
            }

        }

        public int AddNewDrinkSize(NewDrinkSizeVm newDrinkSizeVm)
        {
            var drinkSize = _mapper.Map<DrinkSize>(newDrinkSizeVm);
            var id = _drinkRepository.AddDrinkSize(drinkSize);

            return id;
        }

        public IQueryable<DrinkSize> GetAllDrinkSizes()
        {
            var drinkSizes = _drinkRepository.GetAllDrinkSizes();

            return drinkSizes;
        }

        public IQueryable<Drink> GetAllDrinks()
        {
            var drinks = _drinkRepository.GetAllDrinks();

            return drinks;
        }

       
    }
}
