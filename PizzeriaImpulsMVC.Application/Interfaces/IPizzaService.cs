using PizzeriaImpulsMVC.Application.ViewModels.Component;
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
        int AddPizza(NewPizzaVm newPizzaVm, int pizzaId);
        List<ComponentForListVm> GetCheckedComponents(NewPizzaVm newPizzaVm);

        ListPizzaForListVm GetAllPizzasForList(int pageSize, int pageNumber, string filterString);
        List<PizzaForListVm> GetAllPizzas(string filterString);
        void DeletePizza(int pizzaId);
        NewPizzaVm GetPizzaForEdit(int pizzaId);
        PizzaForListVm GetPizzaDetails(int pizzaId);
        void EditPizza(NewPizzaVm newPizzaVm, int pizzaId);
    }
}
