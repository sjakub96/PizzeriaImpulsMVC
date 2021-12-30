using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.ViewModels.Component;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class ComponentController : Controller
    {
        [HttpGet]
        [Route("component/all")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("component/add")]
        public IActionResult AddComponent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComponent(NewComponentVm newComponentVm)
        {
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteComponent(int componentId)
        {
            return RedirectToAction("Index");
        }

    }
}
