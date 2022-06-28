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

        [HttpGet]
        public IActionResult Index()
        {

            var pizzas = _pizzaService.GetAllPizzasForList(5, 1, "");

            return View(pizzas);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string filterString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if (filterString is null)
            {
                filterString = String.Empty;
            }

            var pizzas = _pizzaService.GetAllPizzasForList(pageSize, pageNumber.Value, filterString);

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

        public IActionResult DeletePizza(int pizzaId)
        {
            _pizzaService.DeletePizza(pizzaId);

            return RedirectToAction("Index");
        }

        public IActionResult GetPizzaDetails(int pizzaId)
        {
            var pizza = _pizzaService.GetPizzaDetails(pizzaId);

            return View(pizza);
        }
    }
}
