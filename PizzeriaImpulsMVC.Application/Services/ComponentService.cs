using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Domain.Interfaces;
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
            var components = _componentRepository.GetAllComponents();

            ListComponentForListVm componentsResult = new ListComponentForListVm();
            componentsResult.Components = new List<ComponentForListVm>();

            foreach (var component in components)
            {
                var componentVm = new ComponentForListVm()
                {
                    Id = component.Id,
                    Name = component.Name,
                    IsMeat = component.IsMeat,
                    Price = component.Price,
                };

                componentsResult.Components.Add(componentVm);
            }

            componentsResult.Count = componentsResult.Components.Count();

            return componentsResult;
        }
    }
}
