﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PizzeriaImpulsMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.UserManagment
{
    public class RolesForListVm : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityRole, RolesForListVm>();

        }
    }
}