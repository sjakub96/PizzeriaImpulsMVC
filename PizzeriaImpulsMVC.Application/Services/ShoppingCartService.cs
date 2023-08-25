﻿

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
        shoppingCartRepository = _shoppingCartRepository;
    }
    public ListShoppingCartVm GetShoppingCart(string userId)
    {
        List<ShoppingCartVm> shoppingCartRows = new List<ShoppingCartVm>();
        var shoppingCart = _shoppingCartRepository.GetShoppingCart(userId);
        return new ListShoppingCartVm();
    }

    public void DeleteFromShoppingCart(int recordId)
    {
        
    }

    public int AddToCart(int productId, ProductType productType, string userId)
    {
        var id = _shoppingCartRepository.AddToCart(productId, productType.ToString(), userId);

        return id;
    }
}