﻿using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Application.ViewModels.Pizza;
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
        List<ComponentForListVm> GetCheckedComponents(NewPizzaVm newPizzaVm);

        ListPizzaForListVm GetAllPizzasForList();
        List<PizzaForListVm> GetAllPizzas();
    }
}
