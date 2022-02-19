using AutoMapper;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Application.ViewModels.Pizza;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class PizzaService : IPizzaService

    {
        private readonly IMapper _mapper;
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IMapper mapper, IPizzaRepository pizzaRepository)
        {
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
        }

        public int AddPizza(NewPizzaVm newPizzaVm)
        {
            //var pizza = _mapper.Map<Pizza>(newPizzaVm);

            var componentPizzaList = new List<ComponentPizza>();


            for (int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {

                var componentPizza = new ComponentPizza()
                {
                    PizzaId = newPizzaVm.Id,
                    ComponentId = newPizzaVm.ComponentPizzas[i].Id
                };

                componentPizzaList.Add(componentPizza);
            }

            bool pizzaIsMeat = false;

            for (int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {
                if (newPizzaVm.ComponentPizzas[i].IsMeat)
                {
                    pizzaIsMeat = true;
                    break;
                }
            }

            var pizza = new Pizza()
            {
                Price = newPizzaVm.Price,
                IsMeat = pizzaIsMeat,
                Name = newPizzaVm.Name,
                ComponentPizzas = componentPizzaList
            };

            var id = _pizzaRepository.AddPizza(pizza);

            return id;
        }

        public List<ComponentForListVm> GetCheckedComponents(NewPizzaVm newPizzaVm)
        {
            var checkedComponents = new List<ComponentForListVm>();

            for (int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {
                if (newPizzaVm.ComponentPizzas[i].IsChecked == true)
                {
                    checkedComponents.Add(newPizzaVm.ComponentPizzas[i]);
                }
            }

            return checkedComponents;
        }
    }
}
