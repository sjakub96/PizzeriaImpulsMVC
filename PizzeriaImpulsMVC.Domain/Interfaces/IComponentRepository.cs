using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IComponentRepository
    {
        int AddComponent(Component component);

        void DeleteComponent(int componentId);

        IQueryable<Component> GetAllComponents();
        
    }
}
