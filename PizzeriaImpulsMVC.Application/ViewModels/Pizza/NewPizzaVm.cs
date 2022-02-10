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
    public class NewPizzaVm :IMapFrom<PizzeriaImpulsMVC.Domain.Models.Pizza>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool IsMeat { get; set; }

        public ICollection<ComponentForListVm>? Components { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPizzaVm, PizzeriaImpulsMVC.Domain.Models.Pizza>()
                .ForMember(x => x.Components, opt => opt.MapFrom(p => p.Components))
                .ReverseMap();

        }

    }
}
