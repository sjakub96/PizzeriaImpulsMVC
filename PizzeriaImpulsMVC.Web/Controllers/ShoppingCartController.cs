using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Helpers;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;

namespace PizzeriaImpulsMVC.Web.Controllers;


public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;
    
    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;

    }
    [HttpGet]
    public IActionResult Index()
    {
        var userName = HttpContext.User.Identity.Name;
        var shoppingCartVm = _shoppingCartService.GetShoppingCart(userName);
        return View(shoppingCartVm);
    }

    //[HttpPost]
    public IActionResult AddAdditionToCart(int additionId)
    {
        var userName = HttpContext.User.Identity.Name;

        _shoppingCartService.AddToCart(additionId, ProductType.Addition.ToString(), userName);

        return RedirectToAction("Index");
    }

    public IActionResult AddDrinkToCart(int drinkId)
    {
        var userName = HttpContext.User.Identity.Name;

        _shoppingCartService.AddToCart(drinkId, ProductType.Drink.ToString(), userName);

        return RedirectToAction("Index");

    }

    public IActionResult AddPizzaToCart(int pizzaId)
    {
        var userName = HttpContext.User.Identity.Name;

        _shoppingCartService.AddToCart(pizzaId, ProductType.Pizza.ToString(), userName);

        return RedirectToAction("Index");
    }
}