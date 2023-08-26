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
        var userId = HttpContext.User.Identity.Name;
        var shoppingCart = _shoppingCartService.GetShoppingCart(userId);
        return RedirectToAction("Index");
    }

    //[HttpPost]
    public IActionResult AddAdditionToCart(int additionId)
    {
        var userName = HttpContext.User.Identity.Name;

        //var userId = "test";

        _shoppingCartService.AddToCart(additionId, ProductType.Addition.ToString(), userName);

        return RedirectToAction("Index");
    }
}