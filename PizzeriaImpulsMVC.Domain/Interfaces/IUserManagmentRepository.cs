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
    }
}
