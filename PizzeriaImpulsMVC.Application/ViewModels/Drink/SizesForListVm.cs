using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Drink
{
    public class SizesForListVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.DrinkSize>
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PizzeriaImpulsMVC.Domain.Models.DrinkSize, SizesForListVm>();
        }
    }
}
