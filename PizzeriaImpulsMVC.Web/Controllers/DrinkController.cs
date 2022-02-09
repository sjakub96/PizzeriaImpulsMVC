using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Drink;
using PizzeriaImpulsMVC.Domain.Models;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var drinks = _drinkService.GetAllDrinksForList();
            return View(drinks);
        }


        [HttpGet]
        [Route("drink/add")]
        public IActionResult AddDrink()
        {
            return View(new NewDrinkVm());
                
        }

        [HttpPost]
        [Route("drink/add")]
        public IActionResult AddDrink(NewDrinkVm newDrinkVm)
        {

            int id = _drinkService.AddDrink(newDrinkVm);

            return RedirectToAction("AddDrink");
        }

        
        
    }
}
