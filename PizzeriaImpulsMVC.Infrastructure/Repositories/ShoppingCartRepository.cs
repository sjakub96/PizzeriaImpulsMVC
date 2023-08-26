using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly Context _context;
    
    public ShoppingCartRepository(Context context)
    {
        _context = context;
    }
    
    public List<ShoppingCart> GetShoppingCart(string userId)
    {
        var shoppingCart = _context.ShoppingCarts.Where(u => u.UserId == userId).ToList();

        return shoppingCart;
    }

    public void DeleteFromShoppingCart(int recordId)
    {
        
    }

    public int AddToCart(int productId, string productType, string userName)
    {
        if (productType == "Pizza")
        {
            
        }
        else if (productType == "Drink")
        {
            
        }
        else if(productType == "Addition")
        {

            var cartId = _context.ShoppingCarts.Where(sc => sc.UserId == userName)
                                                .Select(c => c.CartId)
                                                .FirstOrDefault();
            
            var addition = _context.Additions.FirstOrDefault(a => a.Id == productId);

            if (cartId == 0)
            {
                var shoppingCart = new ShoppingCart()
                {
                    UserId = userName,
                    ProductId = productId,
                    ProductCount = 1,
                    ProductType = productType,
                    Price = addition.Price,
                    CreatedAt = DateTime.Now
                };

                _context.ShoppingCarts.Add(shoppingCart);
                _context.SaveChanges();

                var shoppingCartForUpdate = _context.ShoppingCarts.FirstOrDefault(u => u.UserId == userName);
                var id = shoppingCart.RecordId;

                shoppingCartForUpdate.CartId = id;

                _context.Update(shoppingCartForUpdate);
                _context.SaveChanges();

                return shoppingCartForUpdate.CartId;


            }
            else
            {
                var shoppingCartProducts = _context.ShoppingCarts.Where(c => c.CartId == cartId);

                if (shoppingCartProducts.Any(scp => scp.ProductId == productId && scp.ProductType == productType))
                {
                    var shoppingCartForUpdate = _context.ShoppingCarts.FirstOrDefault(scp =>
                        scp.ProductId == productId && scp.ProductType == productType);

                    shoppingCartForUpdate.ProductCount += 1;
                    shoppingCartForUpdate.Price += addition.Price;
                    
                    _context.Update(shoppingCartForUpdate);
                    _context.SaveChanges();
                    
                    return shoppingCartForUpdate.CartId;
                    
                }
                else
                {
                    var shoppingCart = new ShoppingCart()
                    {
                        CartId = shoppingCartProducts.FirstOrDefault(scp => scp.UserId == userName).CartId,
                        UserId = userName,
                        ProductId = productId,
                        ProductCount = 1,
                        ProductType = productType,
                        Price = addition.Price,
                        CreatedAt = shoppingCartProducts.FirstOrDefault(scp => scp.UserId == userName).CreatedAt
                    };

                    _context.ShoppingCarts.Add(shoppingCart);
                    _context.SaveChanges();

                    return shoppingCart.CartId;
                }
            }
            
            
        }
        
        return 0;
    }
}