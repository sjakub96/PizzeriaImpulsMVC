using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly Context _context;
    
    public ShoppingCartRepository(Context context)
    {
        context = _context;
    }
    
    public List<ShoppingCart> GetShoppingCart(string userId)
    {
        var shoppingCart = _context.ShoppingCarts.Where(u => u.UserId == userId).ToList();

        return shoppingCart;
    }

    public void DeleteFromShoppingCart(int recordId)
    {
        
    }

    public int AddToCart(ShoppingCart shoppingCart)
    {
        return 0;
    }
}