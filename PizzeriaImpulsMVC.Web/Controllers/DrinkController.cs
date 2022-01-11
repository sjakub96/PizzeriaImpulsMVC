using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("drinksize/add")]
        public IActionResult AddNewDrinkSize()
        {
            
            return View(new NewDrinkSizeVm());
        }

        [HttpPost]
        [Route("drinksize/add")]
        public IActionResult AddNewDrinkSize(NewDrinkSizeVm newDrinkSizeVm)
        {
            int id = _drinkService.AddNewDrinkSize(newDrinkSizeVm);

            return RedirectToAction("AddNewDrinkSize");
        }

        [HttpGet]
        [Route("drink/add")]
        public IActionResult AddDrink()
        {
            var drinkSizes = _drinkService.GetAllDrinkSizes().ToList();

            var viewModel = new NewDrinkVm()
            {
                Sizes = drinkSizes
            };
            return View(viewModel);
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
