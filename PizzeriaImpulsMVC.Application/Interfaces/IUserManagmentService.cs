using PizzeriaImpulsMVC.Application.ViewModels.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IUserManagmentService
    {
        void DeleteUser(string userId);
        void RestoreUser(string userId);
        ListUserForListVm GetAllUsersForList();
        UserForListVm GetUserDetails(string userId);
        ListRolesForListVm GetRoles();
        void AddRole(NewRoleVm newRoleVm);
        ListUserRolesVm GetUserRoles(string userId);
        ListRolesForListVm GenerateRolesView(string userId);
    }
}
