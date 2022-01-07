using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Addition;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class AdditionController : Controller
    {
        private readonly IAdditionService _additionService;

        public AdditionController(IAdditionService additionService)
        {
            _additionService = additionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var additions = _additionService.GetAllAdditionsForList();

            return View(additions);
        }

        [HttpGet]
        [Route("addition/add")]
        public IActionResult AddAddition()
        {
            return View(new NewAdditionVm());
        }

        [HttpPost]
        [Route("addition/add")]
        public IActionResult AddAddition(NewAdditionVm newAdditionVm)
        {
            var id = _additionService.AddNewAddition(newAdditionVm);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteAddition(int additionId)
        {
            return RedirectToAction("Index");
        }




    }
}
