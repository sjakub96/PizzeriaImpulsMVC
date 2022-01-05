using AutoMapper;
using AutoMapper.QueryableExtensions;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository? _componentRepository;
        private readonly IMapper? _mapper;

        public int AddNewComponent(NewComponentVm newComponentVm)
        {
            throw new NotImplementedException();
        }

        public void DeleteComponent(int componentId)
        {
            throw new NotImplementedException();
        }

        public ListComponentForListVm GetAllComponentsForList()
        {
            var components = _componentRepository.GetAllComponents()
                .ProjectTo<ComponentForListVm>(_mapper.ConfigurationProvider).ToList();

            var componentsList = new ListComponentForListVm()
            {
                Components = components,
                Count = components.Count
            };

            return componentsList;
        }
    }
}
