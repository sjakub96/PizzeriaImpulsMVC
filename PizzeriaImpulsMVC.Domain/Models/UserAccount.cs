using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class UserAccount : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
