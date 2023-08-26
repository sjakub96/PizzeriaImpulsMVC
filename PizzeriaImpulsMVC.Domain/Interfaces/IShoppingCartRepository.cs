using PizzeriaImpulsMVC.Domain.Models;

namespace PizzeriaImpulsMVC.Domain.Interfaces;

public interface IShoppingCartRepository
{
    List<ShoppingCart> GetShoppingCart(string userId);
    void DeleteFromShoppingCart(int recordId);
    int AddToCart(int productId, string productType, string userName);

}