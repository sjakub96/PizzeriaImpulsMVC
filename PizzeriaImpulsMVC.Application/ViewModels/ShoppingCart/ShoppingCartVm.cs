namespace PizzeriaImpulsMVC.Application.ViewModels.ShoppingCart;

public class ShoppingCartVm
{
    public int RecordId { get; set; }
    public string CartId { get; set; }
    public int UserId { get; set; }
    public int AdditionName { get; set; }
    public int DrinkName { get; set; }
    public int Pizza { get; set; }
    public int AdditionCount { get; set; }
    public int DrinkCount { get; set; }
    public int PizzaCount { get; set; }
    public decimal UnitPrice { get; set; }
}