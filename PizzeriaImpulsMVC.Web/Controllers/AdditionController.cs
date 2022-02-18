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
            var additions = _additionService.GetAllAdditionsForList(5, 1, "");

            return View(additions);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string filterString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if(filterString is null)
            {
                filterString = String.Empty;
            }

            var additions = _additionService.GetAllAdditionsForList(pageSize, pageNumber.Value, filterString);

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

        public IActionResult DeleteAddition(int additionId)
        {
            _additionService.DeleteAddition(additionId);

            return RedirectToAction("Index");
        }




    }
}
