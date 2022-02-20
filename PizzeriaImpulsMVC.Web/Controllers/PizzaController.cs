using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Component;
using PizzeriaImpulsMVC.Application.ViewModels.Pizza;
using PizzeriaImpulsMVC.Domain.Models;

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
            var pizzas = _pizzaService.GetAllPizzasForList();

            return View(pizzas);
        }

        [HttpGet]
        [Route("pizza/add")]
        public IActionResult AddPizza()
        {
            var components = _componentService.GetAllComponents();
            
            return View(new NewPizzaVm()
            {
                ComponentPizzas = components
                
            }); 
        }
         
        [HttpPost]
        [Route("pizza/add")]
        public IActionResult AddPizza(NewPizzaVm newPizzaVm)
        {
            var checkedComponents = _pizzaService.GetCheckedComponents(newPizzaVm);

            newPizzaVm.ComponentPizzas = checkedComponents;

            int id = _pizzaService.AddPizza(newPizzaVm);

            return RedirectToAction("Index");
        }
    }
}  //TODO: Add Index view to pizza views with filtering by name and pagination
