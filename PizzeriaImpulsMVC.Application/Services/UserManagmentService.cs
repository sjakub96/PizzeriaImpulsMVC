using AutoMapper;
using AutoMapper.QueryableExtensions;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.UserManagment;
using PizzeriaImpulsMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Services
{
    public class UserManagmentService : IUserManagmentService
    {
        private readonly IUserManagmentRepository _userManagmentRepository;
        private readonly IMapper _mapper;

        public UserManagmentService(IUserManagmentRepository userManagmentRepository, IMapper mapper)
        {
            _userManagmentRepository = userManagmentRepository;
            _mapper = mapper;
        }

        public ListUserForListVm GetAllUsersForList()
        {
            var users = _userManagmentRepository.GetAllUsers()
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider)
                .ToList();

           
            var userList = new ListUserForListVm()
            {
                Users = users
            };

            return userList;

        }

        public UserForListVm GetUserDetails(string userId)
        {
            var user = _userManagmentRepository.GetUserById(userId);

            var userVm = new UserForListVm
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                IsActive = user.IsActive,
                Country = user.UserAddress.Country,
                City = user.UserAddress.City,
                Street = user.UserAddress.Street,
                HomeNumber = user.UserAddress.HomeNumber,
                ApartmentNumber = user.UserAddress.ApartmentNumber
            };

            return userVm;
        }

        public void DeleteUser(string userId)
        {
            _userManagmentRepository.DeleteUser(userId);
        }

        public void RestoreUser(string userId)
        {
            _userManagmentRepository.RestoreUser(userId);
        }
    }
}
