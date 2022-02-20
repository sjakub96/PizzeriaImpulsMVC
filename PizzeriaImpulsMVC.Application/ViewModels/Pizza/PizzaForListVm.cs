using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Pizza
{
    public class PizzaForListVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.Pizza>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool IsMeat { get; set; }

        public ICollection<ComponentForListVm> Components { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PizzeriaImpulsMVC.Domain.Models.Pizza, PizzaForListVm>()
                .ForMember(c => c.Components, opt => opt.MapFrom(p => p.ComponentPizzas
                .Where(x => x.PizzaId == Id)));

        }
    }
}
