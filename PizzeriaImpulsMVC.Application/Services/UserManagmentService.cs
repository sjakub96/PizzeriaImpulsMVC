using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
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

        public ListRolesForListVm GetRoles()
        {
            var roles = _userManagmentRepository.GetRoles()
                .ProjectTo<RolesForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            var rolesList = new ListRolesForListVm()
            {
                Roles = roles
            };

            return rolesList;
        }

        public void AddRole(NewRoleVm newRoleVm)
        {
            var newRole = new IdentityRole
            {
                Id = newRoleVm.Name,
                Name = newRoleVm.Name,
                NormalizedName = newRoleVm.Name.ToUpper(),
                ConcurrencyStamp = null
            };

            _userManagmentRepository.AddRole(newRole);
        }

        public ListUserRolesVm GetUserRoles(string userId)
        {
            var userRoles = _userManagmentRepository.GetUserRoles(userId);

            var userRolesList = new List<UserRolesVm>();

            foreach (var userRole in userRoles)
            {
                UserRolesVm userRolesVm = new UserRolesVm()
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId,
                    IsChecked = true
                };

                userRolesList.Add(userRolesVm);
            }

            var listUserRoles = new ListUserRolesVm()
            {
                UserRoles = userRolesList,
                
            };

            return listUserRoles;
        }

        public ListRolesForListVm GenerateRolesView(string userId)
        {
            var roles = GetRoles();
            var userRoles = GetUserRoles(userId);

            foreach (var item in roles.Roles)
            {
                for (int i = 0; i < userRoles.UserRoles.Count; i++)
                {
                    if (item.Id == userRoles.UserRoles[i].RoleId)
                    {
                        item.IsChecked = true;
                    }
                }
            }

            roles.UserId = userId;

            return roles;
        }

        public void UpdateUserRoles(string userId, List<RolesForListVm> userRolesVm)
        {
            var userRolesList = new List<IdentityUserRole<string>>();

            foreach (var role in userRolesVm)
            {
                var userRole = new IdentityUserRole<string>
                {
                    RoleId = role.Id,
                    UserId = userId
                };

                userRolesList.Add(userRole);
            }


            _userManagmentRepository.UpdateUserRoles(userId, userRolesList);
        }
    }
}
