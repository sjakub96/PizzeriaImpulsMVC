using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Drink
{
    public class DrinkForListVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.Drink>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }

        public ICollection<DrinkSizeForListVm> DrinkSizes { get; set; }

        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PizzeriaImpulsMVC.Domain.Models.Drink, DrinkForListVm>();
            
        }
    }
}
