namespace PizzeriaImpulsMVC.Domain.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int AdditionId { get; set; }
    public int DrinkId { get; set; }
    public int PizzaId { get; set; }
    public decimal UnitPrice { get; set; }
    public Order Order { get; set; }
    public Addition Addition { get; set; }
    public Drink Drink { get; set; }
    public Pizza Pizza { get; set; }
}