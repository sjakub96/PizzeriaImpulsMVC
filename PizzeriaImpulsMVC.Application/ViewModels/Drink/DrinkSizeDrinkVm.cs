using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Drink
{
    public class DrinkSizeDrinkVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.DrinkSizeDrink>
    {
        public int DrinkId { get; set; }
        public int DrinkSizeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DrinkSizeDrinkVm, PizzeriaImpulsMVC.Domain.Models.DrinkSizeDrink>()
                .ForMember(x => x.Drink, opt => opt.Ignore())
                .ForMember(x => x.DrinkSize, opt => opt.Ignore());
        }
    }
}
