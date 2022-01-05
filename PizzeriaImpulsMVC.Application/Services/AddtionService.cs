using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper? _mapper;

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
            var additions = _additionRepository.GetAllAdditions()
                .ProjectTo<AdditionForListVm>(_mapper.ConfigurationProvider).ToList();

            var additionList = new ListAdditionForListVm()
            {
                Additions = additions,
                Count = additions.Count
            };

            return additionList;
            
        }
    }
}
