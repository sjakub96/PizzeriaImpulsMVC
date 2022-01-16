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
            var drinks = _drinkService.GetAllDrinks();

            ViewBag.Id = new SelectList(drinks, "DrinkId", "DrinkName");
            ViewBag.DrinkSizes = drinkSizes;

            /*
            var viewModel = new NewDrinkVm()
            {
                Sizes = drinkSizes
            };
            */
            return View();
        }

        [HttpPost]
        [Route("drink/add")]
        public IActionResult AddDrink(NewDrinkVm newDrinkVm, DrinkSizeDrinkVm drinkSizeDrink)
        {

            int id = _drinkService.AddDrink(newDrinkVm);

            drinkSizeDrink.DrinkId = id;

            //_drinkService.AddDrinkSizeDrink(drinkSizeDrink);

            return RedirectToAction("AddDrink");
        }

        [HttpGet]
        [Route("drinksizedrink/add")]
        public IActionResult AddDrinkSizeDrink()
        {
            var drinkSizes = _drinkService.GetAllDrinkSizes();
            var drinks = _drinkService.GetAllDrinks().AsEnumerable();

            ViewBag.Id = new SelectList(drinks, "Id", "Name");
            ViewBag.DrinkSizes = drinkSizes;

            
            return View();
        }

        [HttpPost]
        [Route("drinksizedrink/add")]
        public IActionResult AddDrinkSizeDrink(int id, int []DrinkSizeIds)
        {
            _drinkService.AddDrinkSizeDrink(id, DrinkSizeIds);
            return RedirectToAction("AddDrinkSizeDrink");
        }
    }
}
