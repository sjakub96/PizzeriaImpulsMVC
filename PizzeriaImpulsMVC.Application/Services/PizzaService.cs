﻿using AutoMapper;
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
            var pizzas = _pizzaRepository.GetAllPizzas().Where(p => p.Name.Contains(filterString.ToLower()));
            //var components = _componentRepository.GetAllComponents().ToList();

            var pizza = _pizzaRepository.GetPizzaById(8);
            var pizzasList = new List<PizzaForListVm>();
               
                var pizzaForListVm = new PizzaForListVm()
                {
                    Id = pizza.Id,
                    Price = pizza.Price,
                    Name = pizza.Name,
                    IsMeat = pizza.IsMeat,
                    //Components = pizza.ComponentPizzas
                };

                pizzasList.Add(pizzaForListVm);
            

            

            //var pizzaList = new List<PizzaForListVm>();

            /*
            for (int i = 0; i < pizzas.Count; i++)
            {

                
                
                

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
                    Components = pizzas[i].ComponentPizzas
                };

                pizzaList.Add(pizzaForList);
            }
                */
            return pizzasList;
        }

        public int AddPizza(NewPizzaVm newPizzaVm)
        {
            bool pizzaIsMeat = false;
            int componentsPrice = 0;

            //Creating an intermediate table
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
            //TODO: Add automatically calculating price off pizza dependet on components and size

            //Checking if pizza is meat
            if (newPizzaVm.ComponentPizzas.Any(c => c.IsMeat == true))
            {
                pizzaIsMeat = true;
            }

            //Calculating the price off components
            for (int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {
                componentsPrice += newPizzaVm.ComponentPizzas[i].Price;
            }

            //Final price of pizza
            int pizzaPrice = componentsPrice + newPizzaVm.Price;

            //Final pizza
            var pizza = new Pizza()
            {
                Price = pizzaPrice,
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
