using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Component
{
    public class NewComponentVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.Component>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool IsMeat { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewComponentVm, PizzeriaImpulsMVC.Domain.Models.Component>()
                .ReverseMap();
        }
    }
}
