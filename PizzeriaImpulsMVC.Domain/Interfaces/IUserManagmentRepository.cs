using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Interfaces
{
    public interface IUserManagmentRepository
    {
        public bool IsUserActive(string userEmail);
    }
}
