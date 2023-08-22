using System.ComponentModel.DataAnnotations;

namespace PizzeriaImpulsMVC.Domain.Models;

public class ShoppingCart
{
    [Key]
    public int RecordId { get; set; }
    public string CartId { get; set; }
    public string UserId { get; set; }
    public int AdditionId { get; set; }
    public int DrinkId { get; set; }
    public int PizzaId { get; set; }
    public int AdditionCount { get; set; }
    public int DrinkCount { get; set; }
    public int PizzaCount { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public Addition Addition { get; set; }
    public Drink Drink { get; set; }
    public Pizza Pizza { get; set; }
}