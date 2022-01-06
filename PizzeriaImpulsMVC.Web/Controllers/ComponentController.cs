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
            var components = _componentService.GetAllComponentsForList();

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

            return View("AddComponent");
        }

        [HttpDelete]
        public IActionResult DeleteComponent(int componentId)
        {
            return RedirectToAction("Index");
        }

    }
}
