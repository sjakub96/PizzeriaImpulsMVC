using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Addition;
using PizzeriaImpulsMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class AddtionService : IAdditionService
    {
        private readonly IAdditionRepository? _additionRepository;

        public int AddNewAddition(NewAdditionVm newAdditionVm)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddition(int additionId)
        {
            throw new NotImplementedException();
        }

        public ListAdditionForListVm GetAllAdditionsForList()
        {
            var additions = _additionRepository.GetAllAdditions();

            ListAdditionForListVm additionResult = new ListAdditionForListVm();
            additionResult.Additions = new List<AdditionForListVm>();

            foreach (var addition in additions)
            {
                var additionVm = new AdditionForListVm()
                {
                    Id = addition.Id,
                    Name = addition.Name,
                    Price = addition.Price
                };

                additionResult.Additions.Add(additionVm);

            }

            additionResult.Count = additionResult.Additions.Count();

            return additionResult;
        }
    }
}
