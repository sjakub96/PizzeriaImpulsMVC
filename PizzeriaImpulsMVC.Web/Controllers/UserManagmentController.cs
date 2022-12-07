using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;

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
        
    }
}
