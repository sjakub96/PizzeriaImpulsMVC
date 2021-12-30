using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.ViewModels.Addition;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class AdditionController : Controller
    {
        [HttpGet]
        [Route("addition/all")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("addition/add")]
        public IActionResult AddAddition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddition(NewAdditionVm newAdditionVm)
        {
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteAddition(int additionId)
        {
            return RedirectToAction("Index");
        }




    }
}
