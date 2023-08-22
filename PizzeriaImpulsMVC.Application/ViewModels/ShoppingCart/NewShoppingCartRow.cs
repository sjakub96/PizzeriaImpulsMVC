namespace PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;

public class NewShoppingCartRow
{
    public string CartId { get; set; }
    public int UserId { get; set; }
    public int AdditionId { get; set; }
    public int DrinkId { get; set; }
    public int PizzaId { get; set; }
    public int AdditionCount { get; set; }
    public int DrinkCount { get; set; }
    public int PizzaCount { get; set; }
    public decimal UnitPrice { get; set; }
}