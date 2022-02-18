using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using AutoMapper.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Pizza
{
    public class NewPizzaVm :IMapFrom<PizzeriaImpulsMVC.Domain.Models.Pizza>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool IsMeat { get; set; }

        public List<ComponentForListVm>? ComponentPizzas { get; set; }

        public void Mapping(Profile profile)
        {
            
            profile.CreateMap<NewPizzaVm, PizzeriaImpulsMVC.Domain.Models.Pizza>()
                .ForPath(x => x.ComponentPizzas, opt => opt.MapFrom(cp => cp.ComponentPizzas))
                .ReverseMap();

        }

    }
}
