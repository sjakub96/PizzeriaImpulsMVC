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

        public ListPizzaForListVm GetAllPizzasForList()
        {
            var pizzas = GetAllPizzas();
            //var pizzas = _pizzaRepository.GetAllPizzas()
                //.ProjectTo<PizzaForListVm>(_mapper.ConfigurationProvider).ToList();

            var pizzasList = new ListPizzaForListVm()
            {
                Pizzas = pizzas,
                Count = pizzas.Count
            };

            return pizzasList;
        }

        public List<PizzaForListVm> GetAllPizzas()
        {
            var pizzas = _pizzaRepository.GetAllPizzas().ToList();

            var componentList = new List<ComponentForListVm>();

            for (int i = 0; i < pizzas.Count; i++)
            {
                for (int b = 0; b < pizzas[i].ComponentPizzas.Count; b++)
                {
                    var component = new ComponentForListVm()
                    {
                        Id = pizzas[i].ComponentPizzas.ToList()[b].ComponentId,

                    };
                    componentList.Add(component);
                }

            }

            
            var pizzaList = new List<PizzaForListVm>();

            for (int i = 0; i < pizzas.Count; i++)
            {
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
