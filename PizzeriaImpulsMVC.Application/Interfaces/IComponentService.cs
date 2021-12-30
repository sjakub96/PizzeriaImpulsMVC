﻿using PizzeriaImpulsMVC.Application.ViewModels.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IComponentService
    {
        ListComponentForListVm GetAllComponentsForList();

        int AddNewComponent(NewComponentVm newComponentVm);

        void DeleteComponent(int componentId);
    }
}
