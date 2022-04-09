using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IAdditionRepository
    {
        int AddAddition(Addition addition);

        void DeleteAddition(int additionId);

        IQueryable<Addition> GetAllAdditions();

        Addition GetAddition(int additionId);
        void EditAddition(Addition editedAddition);
    }
}
