using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var components = _componentService.GetAllComponentsForList(5, 1, "");

            return View(components);
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

            var components = _componentService.GetAllComponentsForList(pageSize, pageNumber.Value, filterString);

            return View(components);
        }

        [HttpGet]
        [Route("component/add")]
        public IActionResult AddComponent()
        {
            return View(new NewComponentVm());
        }

        [HttpPost]
        [Route("component/add")]
        public IActionResult AddComponent(NewComponentVm newComponentVm)
        {
            var id = _componentService.AddNewComponent(newComponentVm);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteComponent(int componentId)
        {
            _componentService.DeleteComponent(componentId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditComponent(int componentId)
        {
            var component = _componentService.GetComponentForEdit(componentId);

            return View(component);
        }

        [HttpPost]
        public IActionResult EditComponent(NewComponentVm newComponentVm)
        {
            _componentService.EditComponent(newComponentVm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetComponentDetails(int componentId)
        {
            var componentDetails = _componentService.GetComponentDetails(componentId);

            return View(componentDetails);
        }

    }
}
