using PizzeriaImpulsMVC.Application.Helpers;
using PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;

namespace PizzeriaImpulsMVC.Application.Interfaces;

public interface IShoppingCartService
{
    ListShoppingCartVm GetShoppingCart(string userName);
    void DeleteFromShoppingCart(int recordId);
    int AddToCart(int productId, string productType, string userName);
}