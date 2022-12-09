using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IUserManagmentRepository
    {
       IQueryable<UserAccount> GetAllUsers();
       bool IsUserActive(string userEmail);
       UserAccount GetUserById(string userId);
       void DeleteUser(string userId);
       void RestoreUser(string userId);
       DbSet<IdentityRole> GetRoles();
       void AddRole(IdentityRole identityRole);
       IQueryable<IdentityUserRole<string>> GetUserRoles(string userId);
    }
}
