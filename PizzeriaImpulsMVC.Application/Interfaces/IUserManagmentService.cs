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
        ListUserForListVm GetAllUsersForList();
    }
}
