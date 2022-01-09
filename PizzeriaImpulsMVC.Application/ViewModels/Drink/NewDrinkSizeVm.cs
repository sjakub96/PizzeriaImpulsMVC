using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Drink
{
    public class NewDrinkSizeVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.DrinkSize>
    {
        public int Id { get; set; }
        public decimal Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDrinkSizeVm, PizzeriaImpulsMVC.Domain.Models.DrinkSize>();
                
        }


    }
}
