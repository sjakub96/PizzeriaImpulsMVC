using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
        private readonly IComponentRepository _componentRepository;

        public PizzaService(IMapper mapper, IPizzaRepository pizzaRepository, IComponentRepository componentRepository)
        {
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
            _componentRepository = componentRepository;
        }

        public ListPizzaForListVm GetAllPizzasForList(int pageSize, int pageNumber, string filterString)
        {
            var pizzas = GetAllPizzas(filterString);

            var pizzasToShow = pizzas.Skip(pageSize*(pageNumber - 1)).Take(pageSize).ToList();

            var pizzasList = new ListPizzaForListVm()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                FilterString = filterString,
                Pizzas = pizzasToShow,
                Count = pizzas.Count
            };

            return pizzasList;
        }
         
        public List<PizzaForListVm> GetAllPizzas(string filterString)
        {
            var pizzas = _pizzaRepository.GetAllPizzas().Where(p => p.Name.Contains(filterString.ToLower())).ToList();

            var components = _componentRepository.GetAllComponents().ToList();

            var pizzaList = new List<PizzaForListVm>();

            for (int i = 0; i < pizzas.Count; i++)
            {
                var componentList = new List<ComponentForListVm>();

                for (int b = 0; b < components.Count; b++)
                {
                    for (int c = 0; c < pizzas[i].ComponentPizzas.ToList().Count; c++)
                    {
                        if (components[b].Id == pizzas[i].ComponentPizzas.ToList()[c].ComponentId)
                        {
                            var component = new ComponentForListVm()
                            {
                                Id = components[b].Id,
                                IsMeat = components[b].IsMeat,
                                Price = components[b].Price,
                                Name = components[b].Name,
                            };

                            componentList.Add(component);
                        }
                    }
                        
                }

                var pizzaForList = new PizzaForListVm()
                {
                    Id = pizzas[i].Id,
                    Name = pizzas[i].Name,
                    Price = pizzas[i].Price,
                    IsMeat = pizzas[i].IsMeat,
                    Components = componentList
                };

                pizzaList.Add(pizzaForList);
            }
            return pizzaList;
        }

        public int AddPizza(NewPizzaVm newPizzaVm)
        {
            var componentPizzaList = new List<ComponentPizza>();

            for (int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {

                var componentPizza = new ComponentPizza()
                {
                    PizzaId = newPizzaVm.Id,
                    ComponentId = newPizzaVm.ComponentPizzas[i].Id,
                    
                };

                componentPizzaList.Add(componentPizza);
            }

            bool pizzaIsMeat = false;
            
            if (newPizzaVm.ComponentPizzas.Any(p => p.IsMeat == true))
            {
                pizzaIsMeat = true;
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

        public void DeletePizza(int pizzaId)
        {
            _pizzaRepository.DeletePizza(pizzaId);
        }


    }
}
