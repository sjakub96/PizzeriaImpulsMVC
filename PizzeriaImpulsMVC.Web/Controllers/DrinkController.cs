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
            var drinks = _drinkService.GetAllDrinksForList(5, 1, "");
            return View(drinks);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string filterString)
        {
            if(!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if(filterString is null)
            {
                filterString = String.Empty;
            }
            //TODO: Customize page number in Drink View
            var drinks = _drinkService.GetAllDrinksForList(pageSize, pageNumber.Value, filterString);
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

            return RedirectToAction("Index");
        }

        public IActionResult DeleteDrink(int drinkId)
        {
            _drinkService.DeleteDrink(drinkId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditDrink(int drinkId)
        {
            var drink = _drinkService.GetDrinkForEdit(drinkId);
            return View(drink);
        }

        [HttpPost]
        public IActionResult EditDrink(NewDrinkVm editDrinkVm)
        {
            _drinkService.EditDrink(editDrinkVm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetDrinkDetails(int drinkId)
        {
            var drink = _drinkService.GetDrinkDetails(drinkId);

            return View(drink);
        }


    }
}
