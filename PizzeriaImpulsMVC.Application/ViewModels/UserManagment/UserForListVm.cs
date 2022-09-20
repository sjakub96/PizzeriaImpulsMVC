using AutoMapper;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.UserManagment
{
    public class UserForListVm : IMapFrom<PizzeriaImpulsMVC.Domain.Models.UserAccount>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PizzeriaImpulsMVC.Domain.Models.UserAccount, UserForListVm>();

        }
    }
}
