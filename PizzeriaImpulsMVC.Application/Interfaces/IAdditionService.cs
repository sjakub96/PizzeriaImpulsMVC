using PizzeriaImpulsMVC.Application.ViewModels.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IAdditionService
    {
        ListAdditionForListVm GetAllAdditionsForList(int pageSize, int pageNumber, string filterString);

        int AddNewAddition(NewAdditionVm newAdditionVm);

        void DeleteAddition(int additionId);
    }
}
