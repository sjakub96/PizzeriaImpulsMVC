using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Application.ViewModels.Pizza;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly IComponentService _componentService;

        public PizzaController(IPizzaService pizzaService, IComponentService componentService)
        {
            _pizzaService = pizzaService;
            _componentService = componentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("pizza/add")]
        public IActionResult AddPizza()
        {
            
            var components = _componentService.GetAllComponents();

            return View(new NewPizzaVm()
            {
                Components = components
            }); 
        }
         

        [HttpPost]
        [Route("pizza/add")]
        public IActionResult AddPizza(NewPizzaVm newPizzaVm)
        {

            int id = _pizzaService.AddPizza(newPizzaVm);

            return RedirectToAction("Index");
        }
    }

    //TODO: Add fully working creating pizza
}
