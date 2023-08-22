using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;

namespace PizzeriaImpulsMVC.Web.Controllers;

[Authorize]
public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;
    
    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        shoppingCartService = _shoppingCartService;

    }
    [HttpGet]
    public IActionResult Index(string userId)
    {
        var shoppingCart = _shoppingCartService.GetShoppingCart(userId);
        return View(shoppingCart);
    }

    [HttpPost]
    public IActionResult AddToCart(ShoppingCartVm shoppingCartVm)
    {
        
    }
}