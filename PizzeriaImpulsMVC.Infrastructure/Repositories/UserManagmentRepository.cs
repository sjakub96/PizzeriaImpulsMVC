using Microsoft.EntityFrameworkCore;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories
{
    public class UserManagmentRepository : IUserManagmentRepository
    {
        private readonly Context _context;

        public UserManagmentRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<UserAccount> GetAllUsers()
        {
            var users = _context.Users.Include(u => u.UserAddress);
            return users;
        }

        public bool IsUserActive(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if(user == null || user.IsActive == false )
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
