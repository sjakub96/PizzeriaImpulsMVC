﻿using PizzeriaImpulsMVC.Application.ViewModels.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IPizzaService
    {
        int AddPizza(NewPizzaVm newPizzaVm);
    }
}
