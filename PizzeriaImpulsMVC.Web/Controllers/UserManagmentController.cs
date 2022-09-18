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
    }
}
