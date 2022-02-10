using AutoMapper;
using AutoMapper.QueryableExtensions;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Addition;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class AdditionService : IAdditionService
    {
        private readonly IAdditionRepository? _additionRepository;
        private readonly IMapper? _mapper;

        public AdditionService(IAdditionRepository additionRepository, IMapper mapper)
        {
            _additionRepository = additionRepository;
            _mapper = mapper;
        }

        public int AddNewAddition(NewAdditionVm newAdditionVm)
        {
            var addition = _mapper.Map<Addition>(newAdditionVm);
            var id = _additionRepository.AddAddition(addition);

            return id;
        }

        public void DeleteAddition(int additionId)
        {
            _additionRepository.DeleteAddition(additionId);
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
