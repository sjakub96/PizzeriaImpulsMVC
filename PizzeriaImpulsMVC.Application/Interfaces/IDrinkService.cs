﻿using PizzeriaImpulsMVC.Application.ViewModels.Drink;
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
    }
}
