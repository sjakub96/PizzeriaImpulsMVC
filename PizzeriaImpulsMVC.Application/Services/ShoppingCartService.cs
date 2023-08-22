

using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;
using PizzeriaImpulsMVC.Domain.Interfaces;

namespace PizzeriaImpulsMVC.Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    
    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        shoppingCartRepository = _shoppingCartRepository;
    }
    public ListShoppingCartVm GetShoppingCart(string userId)
    {
        List<ShoppingCartVm> shoppingCartRows = new List<ShoppingCartVm>();
        var shoppingCart = _shoppingCartRepository.GetShoppingCart(userId);
        
    }

    public void DeleteFromShoppingCart(int recordId)
    {
        
    }

    public int AddToCart(ShoppingCartVm shoppingCartVm)
    {
        return 0;
    }
}