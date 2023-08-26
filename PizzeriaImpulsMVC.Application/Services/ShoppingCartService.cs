

using PizzeriaImpulsMVC.Application.Helpers;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;
using PizzeriaImpulsMVC.Domain.Interfaces;

namespace PizzeriaImpulsMVC.Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    
    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }
    public ListShoppingCartVm GetShoppingCart(string userId)
    {
        List<ShoppingCartVm> shoppingCartRows = new List<ShoppingCartVm>();
       

        var shoppingCart = _shoppingCartRepository.GetShoppingCart(userId);

        foreach (var shoppingCartRow in shoppingCart)
        {
            var shoppingCartVm = new ShoppingCartVm()
            {
                RecordId = shoppingCartRow.RecordId,
                CartId = shoppingCartRow.CartId,
                ProductCount = shoppingCartRow.ProductCount,
                ProductId = shoppingCartRow.ProductId,
                ProductName = shoppingCartRow.ProductName,
                ProductSize = shoppingCartRow.ProductSize,
                UnitPrice = shoppingCartRow.UnitPrice,
                TotalPrice = shoppingCartRow.Price,
                ProductType = shoppingCartRow.ProductType
            };

            shoppingCartRows.Add(shoppingCartVm);

        }

        var listShoppingCartVm = new ListShoppingCartVm();

        listShoppingCartVm.ShoppingCartRows = shoppingCartRows;
        listShoppingCartVm.SummaryPrice = shoppingCartRows.Sum(p => p.TotalPrice);

        return listShoppingCartVm;
    }

    public void DeleteRecord(int recordId)
    {
        _shoppingCartRepository.DeleteRecord(recordId);
    }

    public void AddToCart(int productId, string productType, string userName)
    {
        _shoppingCartRepository.AddToCart(productId, productType, userName);

    }
}