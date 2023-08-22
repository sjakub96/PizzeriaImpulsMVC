using PizzeriaImpulsMVC.Domain.Models;

namespace PizzeriaImpulsMVC.Domain.Interfaces;

public interface IShoppingCartRepository
{
    List<ShoppingCart> GetShoppingCart(string userId);
    void DeleteFromShoppingCart(int recordId);
    int AddToCart(ShoppingCart shoppingCart);

}