using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.Services;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Application.ViewModels.UserManagment;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class UserManagmentController : Controller
    {
        private readonly IUserManagmentService _userManagmentService;

        public UserManagmentController(IUserManagmentService userManagmentService)
        {
            _userManagmentService = userManagmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManagmentService.GetAllUsersForList();

            return View(users);
        }

        [HttpGet]
        public IActionResult GetUserDetails(string userId)
        {
            var user = _userManagmentService.GetUserDetails(userId);

            return View(user);
        }
        //TODO: Add User registration date to model
        [HttpGet]
        public IActionResult DeleteUser(string userId)
        {
            _userManagmentService.DeleteUser(userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RestoreUser(string userId)
        {
            _userManagmentService.RestoreUser(userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles =_userManagmentService.GetRoles();

            return View(roles);
        }

        [HttpGet]
        [Route("rolesManagment/add")]
        public IActionResult AddRole()
        {
            return View(new NewRoleVm());
        }

        [HttpPost]
        [Route("rolesManagment/add")]
        public IActionResult AddRole(NewRoleVm newRoleVm)
        {
            _userManagmentService.AddRole(newRoleVm);

            return RedirectToAction("GetRoles");
        }

        [HttpGet]
        public IActionResult ManageUserRoles(string userId) 
        {
            var rolesView = _userManagmentService.GenerateRolesView(userId);

            return View(rolesView);
        }

        [HttpPost]
        public IActionResult ManageUserRoles(string userId, ListRolesForListVm userRolesVm)
        {
            var userRoles = userRolesVm.Roles.Where(u => u.IsChecked == true).ToList();
            _userManagmentService.UpdateUserRoles(userId, userRoles);

            return RedirectToAction("Index");
        }
    }
}
