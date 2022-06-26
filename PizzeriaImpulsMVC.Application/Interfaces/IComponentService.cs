using PizzeriaImpulsMVC.Application.ViewModels.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IComponentService
    {
        ListComponentForListVm GetAllComponentsForList(int pageSize, int pageNumber, string filterString);

        int AddNewComponent(NewComponentVm newComponentVm);

        void DeleteComponent(int componentId);
        List<ComponentForListVm> GetAllComponents();
        NewComponentVm GetComponentForEdit(int componentId);
        void EditComponent(NewComponentVm editComponentVm);
        ComponentForListVm GetComponentDetails(int componentId);

    }
}
