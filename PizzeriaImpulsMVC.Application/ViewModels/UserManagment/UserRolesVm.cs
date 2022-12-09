using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.UserManagment
{
    public class UserRolesVm
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public bool IsChecked { get; set; }

    }
}
