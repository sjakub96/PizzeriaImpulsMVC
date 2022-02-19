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

            return View();
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
            var checkedComponents = new List<ComponentForListVm>();

            for(int i = 0; i < newPizzaVm.ComponentPizzas.Count; i++)
            {
                if(newPizzaVm.ComponentPizzas[i].IsChecked == true)
                {
                    checkedComponents.Add(newPizzaVm.ComponentPizzas[i]);
                }
            }

            newPizzaVm.ComponentPizzas = checkedComponents;

            int id = _pizzaService.AddPizza(newPizzaVm);

            return RedirectToAction("Index");
        }
    }

    //TODO: Add fully working creating pizza(is working, but why all components are added?)
}
